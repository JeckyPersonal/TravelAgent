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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IVoucherService _voucherService;
        private readonly IMapper _autoMapper;
        private readonly InvoiceCreator _invoiceCreator;
        private readonly InvoiceGenerator _invoiceGenerator;

        public InvoiceController(IInvoiceService invoiceService, IVoucherService voucherService, IMapper autoMapper, InvoiceDBContext dbContext)
        {
            _invoiceService = invoiceService;
            _autoMapper = autoMapper;
            _voucherService = voucherService;
            _invoiceCreator = new InvoiceCreator(invoiceService, voucherService, dbContext, _autoMapper);
            _invoiceGenerator = new InvoiceGenerator(invoiceService, voucherService);
            
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

            List<VoucherMaster> vouchers = await this._voucherService.GetAllByInvoice(id);
            List<int> voucherIds = vouchers.Select(x => x.Id).ToList();

            InvoiceDto invoiceResponse = this._autoMapper.Map<InvoiceDto>(invoiceById);
            invoiceResponse.Vouchers.AddRange(voucherIds);

            return Ok(invoiceResponse);
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


        [HttpGet]
        [Route("get-all-pending-invoice/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<InvoiceDto>>> GetAllPendingInvoice([FromRoute]int customerId, [FromQuery] List<int> excludedInvoiceId)
        {
            List<Model.Invoice> pendingInvoice = await this._invoiceService.GetAllPendingInvoiceOfCustomer(customerId);

            if(pendingInvoice.Count == 0)
                return NoContent();

            List<Model.Invoice> invoiceAfterExcludsion = (excludedInvoiceId == null || excludedInvoiceId.Count ==0) ? pendingInvoice : pendingInvoice.Where(x => !excludedInvoiceId.Contains(x.Id)).ToList();

            if(invoiceAfterExcludsion.Count == 0) return NoContent();

            List<InvoiceDto> response =  invoiceAfterExcludsion.Select(x => this._autoMapper.Map<InvoiceDto>(x)).ToList();

            return Ok(response);
        }


        [HttpPost]
        [Route("print/{invoiceId:int}")]
        public async Task<ActionResult<bool>> Print(int invoiceId)
        {
            this._invoiceGenerator.Generate(invoiceId);

            return Created("", true);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceDto>> Add([FromBody] InvoiceDto invoiceDto)
        {
            //Model.Invoice invoiceMaster = this._autoMapper.Map<Model.Invoice>(invoiceDto);
            //invoiceMaster.Customer = null;
            //invoiceMaster.FinancialYear = null;
            //invoiceMaster.InvoiceNo = this._invoiceService.GetInvoiceNo();
            //invoiceMaster.StartingTime = DateTime.Now;
            //Model.Invoice response = await this._invoiceService.Add(invoiceMaster);
            //Model.Invoice voucherById = await this._invoiceService.Get(response.Id);

            Model.Invoice savedInvoice = await this._invoiceCreator.CreateNew(invoiceDto);
            return Created("", this._autoMapper.Map<InvoiceDto>(savedInvoice));
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
