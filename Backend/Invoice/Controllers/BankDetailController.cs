using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailController : ControllerBase
    {
        private readonly IBankDetailService _bankDetailService;
        private readonly IMapper _autoMapper;
        private readonly IAppContext _appContext;

        public BankDetailController(IBankDetailService bankService, IMapper autoMapper, IAppContext appContext)
        {
            _bankDetailService = bankService;
            _autoMapper = autoMapper;
            _appContext = appContext;
        }

        [HttpGet]
        [Route("get-all/{bankId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<BankDetailDto>>> GetAll(int bankId)
        {
            List<BankDetail> bankDetails = await this._bankDetailService.GetAll();

            if (bankDetails.Count == 0) return NoContent();

            List<BankDetailDto> bankResponse = bankDetails.Select(x => this._autoMapper.Map<BankDetailDto>(x)).ToList();

            return Ok(bankResponse);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankDetailDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            BankDetail companyById = await this._bankDetailService.Get(id);

            if (companyById == null)
                return NoContent();

            return Ok(companyById);
        }

        [HttpGet]
        [Route("getByBank/{bankId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BankDetailDto>> GetByBank(int bankId)
        {
            if (bankId <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            List<BankDetail> bankDetail = await this._bankDetailService.GetByBankId(bankId);

            if (bankDetail == null)
                return NoContent();

            return Ok(bankDetail);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDetailDto>> Add([FromBody] BankDetailDto bankDetailDto)
        {
            try
            {
                BankDetail bankDetailEntity = this._autoMapper.Map<BankDetail>(bankDetailDto);
                //bankDetailEntity.BankId = this._appContext.CompanyId;

                BankDetail response = await this._bankDetailService.Add(bankDetailEntity);
                return Created("", this._autoMapper.Map<BankDetailDto>(response));
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
        public async Task<ActionResult<BankDetailDto>> Update(int id, [FromBody] BankDetailDto bankDetailDto)
        {
            try
            {
                BankDetail bankDetailEntity = this._autoMapper.Map<BankDetail>(bankDetailDto);
                bankDetailEntity.Id = id;
                BankDetail response = await this._bankDetailService.Update(bankDetailEntity);
                return Ok(this._autoMapper.Map<BankDetailDto>(response));
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
