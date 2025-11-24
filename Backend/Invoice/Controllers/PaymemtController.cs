using AutoMapper;
using Invoice.DTO;
using Invoice.Handler;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymemtController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly PaymetHandler _paymetHandler;

        public PaymemtController(IPaymentService paymentService, IInvoiceService invoiceService, IVoucherService voucherService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _paymentService = paymentService;
            _paymetHandler = new PaymetHandler(dbContext, paymentService, invoiceService, voucherService, mapper);
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> Add(int invoiceId, [FromBody] PaymentDto paymentDto)
        {

            if (invoiceId <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("InvoicecId", "InvoicecId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            PaymentReceived payloadEntity = this._mapper.Map<PaymentReceived>(paymentDto);

            PaymentReceived savedPayment = await this._paymentService.Add(payloadEntity);

            PaymentDto response = this._mapper.Map<PaymentDto>(savedPayment);

            return Created("", response);
        }

        [HttpPut]
        [Route("update/{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> Update(int paymentId, [FromBody] PaymentDto paymentDto)
        {
            if(paymentId <=0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("PaymentId", "PaymentId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            PaymentReceived paymentReceived = this._mapper.Map<PaymentReceived>(paymentDto);

            PaymentReceived savedPayment = await this._paymentService.Update(paymentReceived);

            PaymentDto response = this._mapper.Map<PaymentDto>(savedPayment);

            return Ok(response);
        }

        [HttpPut("remove-invoice/{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> RemoveInvoice([FromRoute]int paymentId, [FromQuery]int invoiceId)
        {
            ModelStateDictionary dic = new ModelStateDictionary();

            if (invoiceId <= 0)
            {
                dic.TryAddModelError("InvoicecId", "InvoicecId should be grater then zero. Please re-try with non zero id.");
            }

            if (paymentId <= 0)
            {
                dic.TryAddModelError("PaymentId", "PaymentId should be grater then zero. Please re-try with non zero id.");
            }

            if(dic.ErrorCount > 0)
                return BadRequest(new ValidationProblemDetails(dic));

            PaymentDto payment = await this._paymetHandler.Remove(invoiceId, paymentId);

            return Ok(payment);
        }

        [HttpPut("add-invoice/{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> AddInvoice([FromRoute] int paymentId, [FromQuery]int invoiceId)
        {
            ModelStateDictionary dic = new ModelStateDictionary();

            if (invoiceId <= 0)
            {
                dic.TryAddModelError("InvoicecId", "InvoicecId should be grater then zero. Please re-try with non zero id.");
            }

            if (paymentId <= 0)
            {
                dic.TryAddModelError("PaymentId", "PaymentId should be grater then zero. Please re-try with non zero id.");
            }

            if (dic.ErrorCount > 0)
                return BadRequest(new ValidationProblemDetails(dic));

            PaymentDto payment = await this._paymetHandler.Remove(invoiceId, paymentId);
            return Ok(payment);
        }
    }
}
