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
    public class ItemController : ControllerBase
    {
        private readonly IService<ItemMaster> _itemService;
        private readonly IMapper _autoMapper;

        public ItemController(IService<ItemMaster> companyService, IMapper autoMapper)
        {
            _itemService = companyService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ItemMasterDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            ItemMaster customerById = await this._itemService.Get(id);

            if (customerById == null)
                return NoContent();

            return Ok(customerById);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ItemMasterDto>>> GetAll()
        {
            List<ItemMaster> items = await this._itemService.GetAll();

            if (items.Count == 0) return NoContent();

            List<ItemMasterDto> itemResponse = items.Select(x => this._autoMapper.Map<ItemMasterDto>(x)).ToList();

            return Ok(itemResponse);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankDto>> Add([FromBody] ItemMasterDto itemDto)
        {
            ItemMaster itemEntity = this._autoMapper.Map<ItemMaster>(itemDto);
            ItemMaster response = await this._itemService.Add(itemEntity);
            return Created("", this._autoMapper.Map<ItemMasterDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ItemMasterDto>> Update(int id, [FromBody] ItemMasterDto itemDto)
        {
            ItemMaster itemEntity = this._autoMapper.Map<ItemMaster>(itemDto);
            itemEntity.Id = id;
            ItemMaster response = await this._itemService.Update(itemEntity);
            return Ok(this._autoMapper.Map<BankDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<ItemMasterDto> Delete(int id)
        {
            return null;
        }
    }
}
