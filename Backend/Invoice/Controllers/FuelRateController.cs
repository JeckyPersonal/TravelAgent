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
    public class FuelRateController : Controller
    {
        private readonly ITenderFuelService _tenderFuelService;
        private readonly IMapper _autoMapper;

        public FuelRateController(ITenderFuelService tenderFuelService, IMapper autoMapper)
        {
            _tenderFuelService = tenderFuelService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FuelRateDto>>> GetAll()
        {
            List<FuelRate> fuelRates = await this._tenderFuelService.GetAll();

            if (fuelRates.Count == 0) return NoContent();

            List<FuelRateDto> itemResponse = fuelRates.Select(x => this._autoMapper.Map<FuelRateDto>(x)).ToList();

            return Ok(itemResponse);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FuelRateDto>> Get(int id)
        {

            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            FuelRate fuleRate = await this._tenderFuelService.Get(id);

            if (fuleRate == null) return NoContent();

            return Ok(this._autoMapper.Map<FuelRateDto>(fuleRate));
        }

        [HttpGet]
        [Route("getByTender/{tenderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FuelRateDto>>> GetbyTender(int tenderId)
        {

            if (tenderId <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            List<FuelRate> customerFuleRates = await this._tenderFuelService.GetByTenderId(tenderId);

            if (customerFuleRates == null) return NoContent();
            List<FuelRateDto> customerFuelRateResponse = customerFuleRates.Select(x => this._autoMapper.Map<FuelRateDto>(x)).ToList();

            return Ok(customerFuelRateResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FuelRateDto>> Add([FromBody] FuelRateDto fuelRateDto)
        {
            FuelRate fuelRateEntity = this._autoMapper.Map<FuelRate>(fuelRateDto);
            FuelRate response = await this._tenderFuelService.Add(fuelRateEntity);
            return Created("", this._autoMapper.Map<FuelRateDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FuelRateDto>> Update(int id, [FromBody] FuelRateDto fuleRateDto)
        {
            FuelRate fuleRateEntity = this._autoMapper.Map<FuelRate>(fuleRateDto);
            fuleRateEntity.Id = id;
            FuelRate response = await this._tenderFuelService.Update(fuleRateEntity);
            return Ok(this._autoMapper.Map<FuelRateDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<FuelRateDto>> Delete(int id)
        {
            FuelRate response = await this._tenderFuelService.Delete(id);
            return Ok(this._autoMapper.Map<FuelRateDto>(response));
        }

    }
}
