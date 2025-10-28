using AutoMapper;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymemtController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IMapper _mapper;

        public PaymemtController(IPaymentService paymentService, IMapper mapper)
        {
            this.paymentService = paymentService;
            this._mapper = mapper;
        }
    }
}
