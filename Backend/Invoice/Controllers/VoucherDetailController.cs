using AutoMapper;
using Invoice.DTO;
using Invoice.Handler;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDetailController : ControllerBase
    {
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly DefaultVoucherDetailHandler _defaultVoucherDetailHandler;
        private readonly IMapper _autoMapper;

        public VoucherDetailController(IVoucherDetailService voucherDetailService, IVehicleRateService vehicleRateService, IMapper autoMapper)
        {
            this._voucherDetailService = voucherDetailService;
            this._defaultVoucherDetailHandler = new DefaultVoucherDetailHandler(vehicleRateService);
            this._autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VoucherDetailDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            VoucherDetail detailById = await this._voucherDetailService.Get(id);

            if (detailById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<VoucherDetailDto>(detailById));
        }

        [HttpGet]
        [Route("get-all/{voucherId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VoucherDetailDto>>> GetAll(int voucherId)
        {
            List<VoucherDetail> voucherDetail = await this._voucherDetailService.GetVoucherDetail(voucherId);

            if (voucherDetail.Count == 0) return NoContent();

            List<VoucherDetailDto> detailResponse = voucherDetail.Select(x => this._autoMapper.Map<VoucherDetailDto>(x)).ToList();

            return Ok(detailResponse);
        }

        [HttpGet]
        [Route("default-detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<VoucherDetailDto>>> GetDefaultVoucherDetail([FromQuery] int customerId, [FromQuery] int vehicleId, [FromQuery] int totalDays)
        {
            if (totalDays <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("TotalDays", "TotalDays should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            List<VoucherDetailDto> voucherDetails = await this._defaultVoucherDetailHandler.GetDefaultDetail(vehicleId, customerId, totalDays);

            if(voucherDetails.Count == 0) return NoContent();

            return Ok(voucherDetails);
        }


        [HttpPost]
        [Route("add/{voucherId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Add(int voucherId, [FromBody] VoucherDetailDto detailDto)
        {
            VoucherDetail detail = this._autoMapper.Map<VoucherDetail>(detailDto);
            detail.VoucherId = voucherId;
            detail.Item = null;
            detail.Voucher = null;
            VoucherDetail response = await this._voucherDetailService.Add(detail);
            return Created("", this._autoMapper.Map<VoucherDetailDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Update(int id, [FromBody] VoucherDetailDto detailDto)
        {
            VoucherDetail detail = this._autoMapper.Map<VoucherDetail>(detailDto);
            detail.Item = null;
            detail.Voucher = null;

            VoucherDetail response = await this._voucherDetailService.Update(detail);
            return Ok(this._autoMapper.Map<VoucherDetailDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<CustomerDto> Delete(int id)
        {
            return null;
        }
    }
}
