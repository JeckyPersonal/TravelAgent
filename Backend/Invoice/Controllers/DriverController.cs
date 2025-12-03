using AutoMapper;
using Invoice.DTO;
using Invoice.Handler.Delete;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController :ControllerBase
    {
        private readonly IService<Driver> _driverService;
        private readonly IMapper _autoMapper;

        public DriverController(IService<Driver> driverService, IMapper autoMapper)
        {
            _driverService = driverService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Driver>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Driver driverById = await this._driverService.Get(id);

            if (driverById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<DriverDto>(driverById));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetAll()
        {
            List<Driver> drivers = await this._driverService.GetAll();

            if (drivers.Count == 0) return NoContent();

            List<DriverDto> driverResponse = drivers.Select(x => this._autoMapper.Map<DriverDto>(x)).ToList();

            return Ok(driverResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Add([FromBody] DriverDto driverDto)
        {
            Driver driverEntity = this._autoMapper.Map<Driver>(driverDto);
            Driver response = await this._driverService.Add(driverEntity);
            return Created("", this._autoMapper.Map<DriverDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Update(int id, [FromBody] DriverDto driverDto)
        {
            Driver driverEntity = this._autoMapper.Map<Driver>(driverDto);
            driverEntity.Id = id;
            Driver response = await this._driverService.Update(driverEntity);
            return Ok(this._autoMapper.Map<DriverDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<DriverDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("DriverId", "DriverId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Driver deletedDriver = await this._driverService.Delete(id);

            return Ok(this._autoMapper.Map<DriverDto>(deletedDriver));
        }
    }
}
