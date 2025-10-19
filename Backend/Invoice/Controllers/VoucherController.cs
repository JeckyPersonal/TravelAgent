using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        private readonly IMapper _autoMapper;

        public VoucherController(IVoucherService voucherService, IMapper autoMapper)
        {
            _voucherService = voucherService;
            _autoMapper = autoMapper;
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

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<VoucherMasterDto> Delete(int id)
        {
            return null;
        }
    }
}
