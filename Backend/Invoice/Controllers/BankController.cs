using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {

        private readonly IService<Bank> _bankService;
        private readonly IMapper _autoMapper;

        public BankController(IService<Bank> bankService, IMapper autoMapper)
        {
            _bankService = bankService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<BankDto>>> GetAll()
        {
            List<Bank> banks = await this._bankService.GetAll();

            if (banks.Count == 0) return NoContent();

            List<BankDto> bankResponse = banks.Select(x=> this._autoMapper.Map<BankDto>(x)).ToList();

            return Ok(bankResponse);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CompanyDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            Bank companyById = await this._bankService.Get(id);

            if (companyById == null)
                return NoContent();

            return Ok(companyById);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Add([FromBody] BankDto bankDto)
        {
            try
            {
                Bank bankEntity = this._autoMapper.Map<Bank>(bankDto);
                Bank response = await this._bankService.Add(bankEntity);
                return Created("", this._autoMapper.Map<BankDto>(response));
            }
            catch (SavedEntityException saveException)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", saveException.Message);
                return BadRequest(new ValidationProblemDetails(dic));
            }
            catch (DuplicateEntityException duplicateEntityException)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", duplicateEntityException.Message);
                return Conflict(new ValidationProblemDetails(dic));
            }
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Update(int id, [FromBody] BankDto bank)
        {
            try
            {
                Bank bankEntity = this._autoMapper.Map<Bank>(bank);
                bankEntity.Id = id;
                Bank response = await this._bankService.Update(bankEntity);
                return Ok(this._autoMapper.Map<BankDto>(response));
            }
            catch (SavedEntityException saveException)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", saveException.Message);
                return BadRequest(new ValidationProblemDetails(dic));
            }
            catch (DuplicateEntityException duplicateEntityException)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", duplicateEntityException.Message);
                return Conflict(new ValidationProblemDetails(dic));
            }
        }
    }
}
