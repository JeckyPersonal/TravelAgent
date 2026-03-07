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
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;
        private readonly IMapper _autoMapper;

        public TenderController(ITenderService tenderService, IMapper autoMapper)
        {
            _tenderService = tenderService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TenderMasterDto>>> GetAll()
        {
            List<TenderMaster> tenders = await this._tenderService.GetAll();

            if (tenders.Count == 0) return NoContent();

            List<TenderMasterDto> itemResponse = tenders.Select(x => this._autoMapper.Map<TenderMasterDto>(x)).ToList();

            return Ok(itemResponse);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TenderMasterDto>> Get(int id)
        {

            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            TenderMaster tender = await this._tenderService.Get(id);

            if (tender == null) return NoContent();

            return Ok(this._autoMapper.Map<TenderMasterDto>(tender));
        }

        [HttpGet]
        [Route("getByCustomer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TenderMasterDto>> GetByCustomer(int customerId)
        {

            if (customerId <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            TenderMaster tender = await this._tenderService.GetByCustomerId(customerId);

            if (tender == null) return NoContent();

            return Ok(this._autoMapper.Map<TenderMasterDto>(tender));
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TenderMasterDto>> Add([FromBody] TenderMasterDto tenderDto)
        {
            TenderMaster tenderEntity = this._autoMapper.Map<TenderMaster>(tenderDto);
            TenderMaster response = await this._tenderService.Add(tenderEntity);
            return Created("", this._autoMapper.Map<TenderMasterDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TenderMasterDto>> Update(int id, [FromBody] TenderMasterDto itemDto)
        {
            TenderMaster tenderEntity = this._autoMapper.Map<TenderMaster>(itemDto);
            tenderEntity.Id = id;
            TenderMaster response = await this._tenderService.Update(tenderEntity);
            return Ok(this._autoMapper.Map<TenderMasterDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<TenderMasterDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("TenderId", "TenderId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            return Ok();
        }

    }
}
