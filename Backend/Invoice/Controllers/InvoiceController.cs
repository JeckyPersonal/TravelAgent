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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _autoMapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper autoMapper)
        {
            _invoiceService = invoiceService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvoiceDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Model.Invoice invoiceById = await this._invoiceService.Get(id);

            if (invoiceById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<InvoiceDto>(invoiceById));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            List<Model.Invoice> invoices = await this._invoiceService.GetAll();

            if (invoices.Count == 0) return NoContent();

            List<InvoiceDto> invoiceDto = invoices.Select(x => this._autoMapper.Map<InvoiceDto>(x)).ToList();

            return Ok(invoiceDto);
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceDto>> Add([FromBody] InvoiceDto invoiceDto)
        {
            Model.Invoice voucherMaster = this._autoMapper.Map<Model.Invoice>(invoiceDto);
            voucherMaster.Customer = null;
            voucherMaster.FinancialYear = null;
            voucherMaster.InvoiceNo = this._invoiceService.GetInvoiceNo();
            Model.Invoice response = await this._invoiceService.Add(voucherMaster);
            Model.Invoice voucherById = await this._invoiceService.Get(response.Id);
            return Created("", this._autoMapper.Map<InvoiceDto>(voucherById));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceDto>> Update(int id, [FromBody] InvoiceDto invoiceDto)
        {
            Model.Invoice invoice = this._autoMapper.Map<Model.Invoice>(invoiceDto);
            invoice.Customer = null;
            invoice.FinancialYear = null;

            Model.Invoice response = await this._invoiceService.Update(invoice);
            Model.Invoice invoicecById = await this._invoiceService.Get(response.Id);
            return Ok(this._autoMapper.Map<VoucherMasterDto>(invoicecById));
        }

        //[HttpGet]
        //[Route("get-all-pending-voucher")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<List<VoucherMasterDto>>> GetPendingVoucherForCustomer([FromQuery(Name = "customerId")] int customerId)
        //{
        //    List<VoucherMaster> voucherMasters = await this._voucherService.GetPendingVoucher(customerId);

        //    if (voucherMasters.Count == 0)
        //        return NoContent();

        //    List<VoucherMasterDto> response = voucherMasters.Select(x => this._autoMapper.Map<VoucherMasterDto>(x)).ToList();

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("process")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<List<InvoiceDetailDto>>> ProcessVouchers([FromBody] List<int> voucherIds)
        //{
        //    if (voucherIds.Count == null || voucherIds.Count == 0)
        //    {
        //        return BadRequest();
        //    }

        //    List<InvoiceDetailDto> invouceDetailDto = this._voucherProcessor.Process(voucherIds);
        //    if (invouceDetailDto.Count == 0) return NoContent();

        //    return Ok(invouceDetailDto);
        //}

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<VoucherMasterDto> Delete(int id)
        {
            return null;
        }
    }
}
