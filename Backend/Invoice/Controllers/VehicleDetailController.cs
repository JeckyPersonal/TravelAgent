using AutoMapper;
using Invoice.DTO;
using Invoice.Handler.Delete;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailController : ControllerBase
    {
        private readonly IVehicleDetailService _vehicleDetailService;
        private readonly IMapper _autoMapper;
        private readonly DeleteVehicle _deleteHandler;

        public VehicleDetailController(IVehicleDetailService vehicleService, DeleteVehicle deleteHandler, IMapper autoMapper)
        {
            _vehicleDetailService = vehicleService;
            _autoMapper = autoMapper;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDetailDto>> Get(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", "Id should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            VehicleDetail vehicleDetail = await this._vehicleDetailService.Get(id);

            if (vehicleDetail == null)
                return NoContent();

            return Ok(vehicleDetail);
        }

        [HttpGet]
        [Route("get-all/{vehicleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VehicleDetailDto>>> GetAll(int vehicleId)
        {
            List<VehicleDetail> vehicleDetails = await this._vehicleDetailService.GetByVehicleId(vehicleId);

            if (vehicleDetails.Count == 0) return NoContent();

            List<VehicleDetailDto> vehicleResponse = vehicleDetails.Select(x => this._autoMapper.Map<VehicleDetailDto>(x)).ToList();

            return Ok(vehicleResponse);
        }

        [HttpPost]
        [Route("add/{vehicleId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehicleDetailDto>> Add(int vehicleId, [FromBody] VehicleDetailDto vehicleDetailDto)
        {
            VehicleDetail vehicleDetailEntity = this._autoMapper.Map<VehicleDetail>(vehicleDetailDto);
            vehicleDetailEntity.VehicleId = vehicleId;
            VehicleDetail response = await this._vehicleDetailService.Add(vehicleDetailEntity);
            return Created("", this._autoMapper.Map<VehicleDetailDto>(response));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehicleDetailDto>> Update(int id, [FromBody] VehicleDetailDto vehicleDto)
        {
            VehicleDetail vehicleEntity = this._autoMapper.Map<VehicleDetail>(vehicleDto);
            vehicleEntity.Id = id;
            VehicleDetail response = await this._vehicleDetailService.Update(vehicleEntity);
            return Ok(this._autoMapper.Map<VehicleDetailDto>(response));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<VehicleDetailDto>> Delete(int id)
        {
            if (id <= 0)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("VehicleDetailId", "VehicleDetailId should be grater then zero. Please re-try with non zero id.");
                return BadRequest(new ValidationProblemDetails(dic));
            }

            return Ok(await this._deleteHandler.DeleteVehicleDetail(id));
        }
    }
}
