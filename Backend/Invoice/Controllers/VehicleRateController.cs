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
    public class VehicleRateController : ControllerBase
    {
        private readonly IVehicleRateService _vehicleRateService;
        private readonly IMapper _autoMapper;

        public VehicleRateController(IVehicleRateService vehicleRateService, IMapper autoMapper)
        {
            _vehicleRateService = vehicleRateService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleRateDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            VehicleRateConfiguration configById = await this._vehicleRateService.Get(id);

            if (configById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<VehicleRateDto>(configById));
        }

        [HttpGet]
        [Route("get-itemInfo/{vehicleId:int}/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleRateDto>> Get(int vehicleId, int itemId)
        {
            VehicleRateConfiguration configById = await this._vehicleRateService.GetRateInfo(vehicleId, itemId);

            if (configById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<VehicleRateDto>(configById));
        }

        [HttpGet]
        [Route("get-all/{vehicleId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VehicleRateDto>>> GetAll(int vehicleId)
        {
            List<VehicleRateConfiguration> configurations = await this._vehicleRateService.GetAllRates(vehicleId, ConfigurationType.Vehicle);

            if (configurations.Count == 0) return NoContent();

            List<VehicleRateDto> driverResponse = configurations.Select(x => this._autoMapper.Map<VehicleRateDto>(x)).ToList();

            return Ok(driverResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Add([FromBody] VehicleRateDto rateConfigDto)
        {
            VehicleRateConfiguration rateConfigEntity = this._autoMapper.Map<VehicleRateConfiguration>(rateConfigDto);
            rateConfigEntity.ItemMaster = null;
            rateConfigEntity.Type = ConfigurationType.Vehicle;
            VehicleRateConfiguration response = await this._vehicleRateService.Add(rateConfigEntity);
            return Created("", this._autoMapper.Map<VehicleRateDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Update(int id, [FromBody] VehicleRateDto driverDto)
        {
            VehicleRateConfiguration rateConfigEntity = this._autoMapper.Map<VehicleRateConfiguration>(driverDto);
            rateConfigEntity.Id = id;
            rateConfigEntity.ItemMaster = null;
            rateConfigEntity.Type = ConfigurationType.Vehicle;
            VehicleRateConfiguration response = await this._vehicleRateService.Update(rateConfigEntity);
            return Ok(this._autoMapper.Map<VehicleRateDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<CustomerDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("VehicleRateConfigId", "VehicleRateConfigId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            VehicleRateConfiguration deletedRate = await this._vehicleRateService.Delete(id);

            return Ok(_autoMapper.Map<VehicleRateDto>(deletedRate));
        }
    }
}
