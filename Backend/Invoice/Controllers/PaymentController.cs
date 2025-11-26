using AutoMapper;
using Invoice.DTO;
using Invoice.Handler;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly PaymetHandler _paymetHandler;

        public PaymentController(IPaymentService paymentService, IInvoiceService invoiceService, IVoucherService voucherService, IInvoicePaymentService invoicePaymentService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _paymentService = paymentService;
            _paymetHandler = new PaymetHandler(dbContext, paymentService, invoiceService, voucherService, invoicePaymentService, mapper);
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> Add([FromBody] PaymentDto paymentDto)
        {

            //if (invoiceId <= 0)
            //{
            //    ModelStateDictionary dic = new ModelStateDictionary();
            //    dic.TryAddModelError("InvoicecId", "InvoicecId should be grater then zero. Please re-try with non zero id.");
            //    return BadRequest(new ValidationProblemDetails(dic));
            //}

            PaymentReceived payloadEntity = this._mapper.Map<PaymentReceived>(paymentDto);

            PaymentReceived savedPayment = await this._paymentService.Add(payloadEntity);

            PaymentDto response = this._mapper.Map<PaymentDto>(savedPayment);

            return Created("", response);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<PaymentDto>> GetAll()
        {
            List<PaymentReceived> payments = await this._paymentService.GetAll();

            if (payments.Count == 0) return NoContent();

            List<PaymentDto> resonse = payments.Select(x => this._mapper.Map<PaymentDto>(x)).ToList();

            return Ok(resonse);
        }

        [HttpGet]
        [Route("get-by-id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<PaymentDto>> Get(int id)
        {
            PaymentReceived paymentById = await this._paymentService.Get(id);

            return Ok(this._mapper.Map<PaymentDto>(paymentById));
        }

        [HttpPut]
        [Route("update/{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> Update(int paymentId, [FromBody] PaymentDto paymentDto)
        {
            if (paymentId <= 0)
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
        public async Task<ActionResult<PaymentDto>> RemoveInvoice([FromRoute] int paymentId, [FromQuery] int invoiceId)
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

        [HttpPut("add-invoice/{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentDto>> AddInvoice([FromRoute] int paymentId, [FromQuery] int invoiceId)
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

            PaymentDto payment = await this._paymetHandler.Received(invoiceId, paymentId);
            return Ok(payment);
        }
    }
}
