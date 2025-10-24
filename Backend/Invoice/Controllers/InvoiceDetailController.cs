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
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IMapper _autoMapper;
        private readonly InvoiceDetailCreator _detailCreator;

        public InvoiceDetailController(InvoiceDBContext dbContext, IInvoiceDetailService invoiceDetailService, IVoucherDetailService voucherDetailService, IMapper autoMaper)
        {
            _invoiceDetailService = invoiceDetailService;
            _autoMapper = autoMaper;
            _detailCreator = new InvoiceDetailCreator(dbContext, invoiceDetailService, voucherDetailService);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvoiceDetailDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            InvoiceDetail detailById = await this._invoiceDetailService.Get(id);

            if (detailById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<InvoiceDetailDto>(detailById));
        }

        [HttpGet]
        [Route("get-all/{invoiceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VoucherDetailDto>>> GetAll(int invoiceId)
        {
            List<InvoiceDetail> invoieDetail = await this._invoiceDetailService.GetInvoiceDetail(invoiceId);

            if (invoieDetail.Count == 0) return NoContent();

            List<VoucherDetailDto> detailResponse = invoieDetail.Select(x => this._autoMapper.Map<VoucherDetailDto>(x)).ToList();

            return Ok(detailResponse);
        }


        [HttpPost]
        [Route("add/{invoiceId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceDetailDto>> Add(int invoiceId, [FromBody] InvoiceDetailDto invoiceDetail)
        {
            InvoiceDetail detail = this._autoMapper.Map<InvoiceDetail>(invoiceDetail);
            //detail.InvoiceId = invoiceId;
            //detail.Item = null;
            //detail.Invoice = null;
            //detail.VoucherDetail = null;
            //detail.VoucherDetailId = invoiceDetail.VoucherDetailId;
            //InvoiceDetail response = await this._invoiceDetailService.Add(detail);
            InvoiceDetail response = await this._detailCreator.CreateNew(invoiceId, detail);
            return Created("", this._autoMapper.Map<InvoiceDetailDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceDetailDto>> Update(int id, [FromBody] InvoiceDetailDto detailDto)
        {
            InvoiceDetail detail = this._autoMapper.Map<InvoiceDetail>(detailDto);
            detail.Item = null;
            detail.Invoice = null;
            detail.VoucherDetail = null;

            InvoiceDetail response = await this._invoiceDetailService.Update(detail);
            return Ok(this._autoMapper.Map<InvoiceDetail>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<CustomerDto> Delete(int id)
        {
            return null;
        }
    }
}
