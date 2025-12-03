using AutoMapper;
using Invoice.DTO;
using Invoice.Handler;
using Invoice.Handler.Delete;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        private readonly IMapper _autoMapper;
        private readonly VoucherProcessor _voucherProcessor;
        private readonly DeleteVoucher _deleteHandler;

        public VoucherController(IVoucherService voucherService, IVoucherDetailService voucherDetailService, ICustomerService customerService, DeleteVoucher deleteHandler, IMapper autoMapper)
        {
            _voucherService = voucherService;
            _autoMapper = autoMapper;
            _deleteHandler = deleteHandler;
            _voucherProcessor = new VoucherProcessor(voucherDetailService, customerService);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VoucherMasterDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            VoucherMaster voucherById = await this._voucherService.Get(id);

            if (voucherById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<VoucherMasterDto>(voucherById));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VoucherMasterDto>>> GetAll()
        {
            List<VoucherMaster> configurations = await this._voucherService.GetAll();

            if (configurations.Count == 0) return NoContent();

            List<VoucherMasterDto> driverResponse = configurations.Select(x => this._autoMapper.Map<VoucherMasterDto>(x)).ToList();

            return Ok(driverResponse);
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoucherMasterDto>> Add([FromBody] VoucherMasterDto rateConfigDto)
        {
            VoucherMaster voucherMaster = this._autoMapper.Map<VoucherMaster>(rateConfigDto);
            voucherMaster.Customer = null;
            voucherMaster.FinancialYear = null;
            voucherMaster.Driver = null;
            voucherMaster.Vehicle = null;
            voucherMaster.VehicleDetail = null;
            voucherMaster.DriverId = rateConfigDto.DriverId == 0 ? null : rateConfigDto.DriverId;
            voucherMaster.VoucherNo = this._voucherService.GetVoucherNo();
            VoucherMaster response = await this._voucherService.Add(voucherMaster);
            VoucherMaster voucherById = await this._voucherService.Get(response.Id);
            return Created("", this._autoMapper.Map<VoucherMasterDto>(voucherById));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoucherMasterDto>> Update(int id, [FromBody] VoucherMasterDto voucherMasterDto)
        {
            VoucherMaster voucherMaster = this._autoMapper.Map<VoucherMaster>(voucherMasterDto);
            voucherMaster.Customer = null;
            voucherMaster.FinancialYear = null;
            voucherMaster.Driver = null;
            voucherMaster.Vehicle = null;
            voucherMaster.VehicleDetail = null;

            VoucherMaster response = await this._voucherService.Update(voucherMaster);
            VoucherMaster voucherById = await this._voucherService.Get(response.Id);
            return Ok(this._autoMapper.Map<VoucherMasterDto>(voucherById));
        }

        [HttpGet]
        [Route("get-all-pending-voucher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<VoucherMasterDto>>> GetPendingVoucherForCustomer([FromQuery(Name = "customerId")] int customerId)
        {
            List<VoucherMaster> voucherMasters = await this._voucherService.GetPendingVoucher(customerId);

            if (voucherMasters.Count == 0)
                return NoContent();

            List<VoucherMasterDto> response = voucherMasters.Select(x => this._autoMapper.Map<VoucherMasterDto>(x)).ToList();

            return Ok(response);
        }

        [HttpPost]
        [Route("process")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<InvoiceDetailDto>>> ProcessVouchers([FromBody] VoucherProcessDto voucherProcessDto)
        {
            if (voucherProcessDto.VoucherIds.Count == null || voucherProcessDto.VoucherIds.Count == 0)
            {
                return BadRequest();
            }

            List<InvoiceDetailDto> invouceDetailDto =  await this._voucherProcessor.Process(voucherProcessDto);
            if (invouceDetailDto.Count == 0) return NoContent();

            return Ok(invouceDetailDto);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoucherMasterDto>> Delete(int id)
        {
            ModelStateDictionary dic = new ModelStateDictionary();

            if (id <= 0)
            {
                dic.TryAddModelError("VoucherId", "VoucherId should be grater then zero. Please re-try with non zero id.");
            }

            if (dic.ErrorCount > 0)
                return BadRequest(new ValidationProblemDetails(dic));

            return Ok(await this._deleteHandler.Delete(id));
        }
    }
}
