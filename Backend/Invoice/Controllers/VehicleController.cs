using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IService<Vehicle> _vehicleService;
        private readonly IMapper _autoMapper;

        public VehicleController(IService<Vehicle> vehicleService, IMapper autoMapper)
        {
            _vehicleService = vehicleService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Vehicle vehicleById = await this._vehicleService.Get(id);

            if (vehicleById == null)
                return NoContent();

            return Ok(vehicleById);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAll()
        {
            List<Vehicle> vehicles = await this._vehicleService.GetAll();

            if (vehicles.Count == 0) return NoContent();

            List<VehicleDto> vehicleResponse = vehicles.Select(x => this._autoMapper.Map<VehicleDto>(x)).ToList();

            return Ok(vehicleResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehicleDto>> Add([FromBody] VehicleDto vehicleDto)
        {
            Vehicle vehicleEntity = this._autoMapper.Map<Vehicle>(vehicleDto);
            Vehicle response = await this._vehicleService.Add(vehicleEntity);
            return Created("", this._autoMapper.Map<VehicleDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehicleDto>> Update(int id, [FromBody] VehicleDto vehicleDto)
        {
            Vehicle vehicleEntity = this._autoMapper.Map<Vehicle>(vehicleDto);
            vehicleEntity.Id = id;
            Vehicle response = await this._vehicleService.Update(vehicleEntity);
            return Ok(this._autoMapper.Map<VehicleDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<VehicleDto> Delete(int id)
        {
            return null;
        }
    }
}
