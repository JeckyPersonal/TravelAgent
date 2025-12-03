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
    public class ItemController : ControllerBase
    {
        private readonly IItemMasterService _itemService;
        private readonly IMapper _autoMapper;

        public ItemController(IItemMasterService companyService, IMapper autoMapper)
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

            return Ok(this._autoMapper.Map<ItemMasterDto>(customerById));
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
        public async Task<ActionResult<ItemMasterDto>> Add([FromBody] ItemMasterDto itemDto)
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
            return Ok(this._autoMapper.Map<ItemMasterDto>(response));
        }

        [HttpGet]
        [Route("get-all-interval")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ItemIntervalDto>>> GetAllItemInterval()
        {
            List<ItemInterval> itemIntervals = await this._itemService.GetAllIntervals();

            if (itemIntervals.Count == 0)
                return NoContent();

            List<ItemIntervalDto> intervalDto = itemIntervals.Select(x => this._autoMapper.Map<ItemIntervalDto>(x)).ToList();
            return Ok(intervalDto);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<ItemMasterDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("ItemId", "ItemId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            ItemMaster deletedItem = await this._itemService.Delete(id);

            return Ok(this._autoMapper.Map<ItemMaster>(deletedItem));
        }
    }
}
