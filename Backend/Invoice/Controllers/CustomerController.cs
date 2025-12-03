using AutoMapper;
using Invoice.DTO;
using Invoice.Handler.Delete;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _autoMapper;
        private readonly DeleteCustomer _deleteHandler;

        public CustomerController(ICustomerService customerService, DeleteCustomer deletePayment, IMapper autoMapper)
        {
            _customerService = customerService;
            _autoMapper = autoMapper;
            _deleteHandler = deletePayment;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Customer customerById = await this._customerService.Get(id);

            if (customerById == null)
                return NoContent();

            return Ok(customerById);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            List<Customer> customer = await this._customerService.GetAll();

            if (customer.Count == 0) return NoContent();

            List<CustomerDto> customerResponse = customer.Select(x => this._autoMapper.Map<CustomerDto>(x)).ToList();

            return Ok(customerResponse);
        }


        [HttpGet]
        [Route("pending-voucher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomerWithPendingVoucher()
        {
            List<Customer> customers = await this._customerService.GetAllCustomerWithPendingVoucher();
            
            if(customers == null || customers.Count == 0)
                return NoContent();

            List<CustomerDto> customerDto = customers.Select(x => this._autoMapper.Map<CustomerDto>(x)).ToList();
            return Ok(customerDto);

        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerDto>> Add([FromBody] CustomerDto customerDto)
        {
            Customer customerEntity = this._autoMapper.Map<Customer>(customerDto);
            Customer response = await this._customerService.Add(customerEntity);
            return Created("", this._autoMapper.Map<CustomerDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerDto>> Update(int id, [FromBody] CustomerDto customerDto)
        {
            Customer customerEntity = this._autoMapper.Map<Customer>(customerDto);
            customerEntity.Id = id;
            Customer response = await this._customerService.Update(customerEntity);
            return Ok(this._autoMapper.Map<CustomerDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<CustomerDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("CustomerId", "CustomerId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            return Ok(await this._deleteHandler.Delete(id));

        }
    }
}
