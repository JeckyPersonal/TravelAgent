using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IService<Customer> _companyService;
        private readonly IMapper _autoMapper;

        [HttpPost]
        [Route("add")]
        public ActionResult<CustomerDto> Add([FromBody] CustomerDto company)
        {
            return null;
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public ActionResult<CustomerDto> Update(int id, [FromBody] CustomerDto company)
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            return null;
        }

        [HttpGet]
        [Route("get/{name:alpha}")]
        public ActionResult<CustomerDto> Get(string name)
        {
            return null;
        }

        [HttpGet]
        [Route("get-all")]
        public ActionResult<IEnumerable<CustomerDto>> GetAll()
        {
            return null;
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<CustomerDto> Delete(int id)
        {
            return null;
        }
    }
}
