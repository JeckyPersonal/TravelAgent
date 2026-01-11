using AutoMapper;
using Invoice.DTO;
using Invoice.Handler;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRateController : ControllerBase
    {
        private readonly IVehicleRateService _vehicleRateService;
        private readonly IMapper _autoMapper;
        private readonly RateInfoHandler _rateInfo;

        public CustomerRateController(IVehicleRateService vehicleRateService, IItemMasterService itemService, IMapper autoMapper)
        {
            _vehicleRateService = vehicleRateService;
            _autoMapper = autoMapper;
            _rateInfo = new RateInfoHandler(itemService, vehicleRateService);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerRateDto>> Get(int id)
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

            return Ok(this._autoMapper.Map<CustomerRateDto>(configById));
        }

        [HttpGet]
        [Route("get-all/{vehicleId:int}/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomerRateDto>>> GetAll(int vehicleId, int customerId)
        {
            List<VehicleRateConfiguration> configurations = await this._vehicleRateService.GetAllCustomerRates(vehicleId, customerId, ConfigurationType.Customer);

            if (configurations.Count == 0) return NoContent();

            List<CustomerRateDto> driverResponse = configurations.Select(x => this._autoMapper.Map<CustomerRateDto>(x)).ToList();

            return Ok(driverResponse);
        }

        [HttpGet]
        [Route("get/{customerId:int}/{vehicleId:int}/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerRateDto>> GetAll(int customerId, int vehicleId, int itemId)
        {
            VehicleRateConfiguration configurations = await this._vehicleRateService.GetCustomerRateForItem(customerId, vehicleId, itemId, ConfigurationType.Customer);

            if (configurations == null) return NoContent();

            CustomerRateDto response = this._autoMapper.Map<CustomerRateDto>(configurations);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-rate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RateInfoDto>> GetRate([FromQuery] int? customerId, [FromQuery] int? vehicleId, [FromQuery] int itemId)
        {
            RateInfoDto rateInfo = await this._rateInfo.GetRateInfo(itemId, customerId, vehicleId);

            if(rateInfo == null) return NoContent();

            return Ok(rateInfo);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerRateDto>> Add([FromBody] CustomerRateDto rateConfigDto)
        {
            VehicleRateConfiguration rateConfigEntity = this._autoMapper.Map<VehicleRateConfiguration>(rateConfigDto);
            rateConfigEntity.ItemMaster = null;
            rateConfigEntity.Customer = null;
            rateConfigEntity.Type = ConfigurationType.Customer;
            VehicleRateConfiguration response = await this._vehicleRateService.Add(rateConfigEntity);
            return Created("", this._autoMapper.Map<CustomerRateDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerRateDto>> Update(int id, [FromBody] CustomerRateDto rateConfigDto)
        {
            VehicleRateConfiguration rateConfigEntity = this._autoMapper.Map<VehicleRateConfiguration>(rateConfigDto);
            rateConfigEntity.Id = id;
            rateConfigEntity.ItemMaster = null;
            rateConfigEntity.Customer = null;
            rateConfigEntity.Type = ConfigurationType.Customer;
            VehicleRateConfiguration response = await this._vehicleRateService.Update(rateConfigEntity);
            return Ok(this._autoMapper.Map<CustomerRateDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<CustomerRateDto>> Delete(int id)
        {
            VehicleRateConfiguration response = await this._vehicleRateService.DeleteRate(id);
            return Ok(this._autoMapper.Map<CustomerRateDto>(response));
        }
    }
}
