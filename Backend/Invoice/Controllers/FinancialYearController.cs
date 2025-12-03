using AutoMapper;
using Invoice.DTO;
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
    public class FinancialYearController : ControllerBase
    {
        private readonly IFinancialYearService _financialYearService;
        private readonly IMapper _autoMapper;

        public FinancialYearController(IFinancialYearService financialYearService, IMapper autoMapper)
        {
            _financialYearService = financialYearService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FinancialYear>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            FinancialYear FinancialYearById = await this._financialYearService.Get(id);

            if (FinancialYearById == null)
                return NoContent();

            return Ok(this._autoMapper.Map<FinancialYearDto>(FinancialYearById));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FinancialYearDto>>> GetAll()
        {
            List<FinancialYear> financialYears = await this._financialYearService.GetAll();

            if (financialYears.Count == 0) return NoContent();

            List<FinancialYearDto> financialYearResponse = financialYears.Select(x => this._autoMapper.Map<FinancialYearDto>(x)).ToList();

            return Ok(financialYearResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FinancialYearDto>> Add([FromBody] FinancialYearDto financialYearDto)
        {
            FinancialYear financialYearEntity = this._autoMapper.Map<FinancialYear>(financialYearDto);
            FinancialYear response = await this._financialYearService.Add(financialYearEntity);
            return Created("", this._autoMapper.Map<FinancialYearDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDto>> Update(int id, [FromBody] FinancialYearDto financialYearDto)
        {
            FinancialYear financialYearEntity = this._autoMapper.Map<FinancialYear>(financialYearDto);
            financialYearEntity.Id = id;
            FinancialYear response = await this._financialYearService.Update(financialYearEntity);
            return Ok(this._autoMapper.Map<CustomerDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<CustomerDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("FinancialYear", "FinancialYear should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            FinancialYear deletedYear = await this._financialYearService.Delete(id);

            return Ok(this._autoMapper.Map<FinancialYearDto>(deletedYear));
        }
    }
}
