using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Invoice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IService<Company> _companyService;
        private readonly IMapper _autoMapper;

        public CompanyController(IService<Company> companyService, IMapper autoMapper)
        {
            this._companyService = companyService;
            this._autoMapper = autoMapper;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CompanyDto>> Add([FromBody] CompanyDto company)
        {
            try
            {
                Company companyEntity = this._autoMapper.Map<Company>(company);
                Company response = await this._companyService.Add(companyEntity);
                return Created("", this._autoMapper.Map<CompanyDto>(response));
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
        public ActionResult<CompanyDto> Update(int id, [FromBody] CompanyDto company)
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<CompanyDto> Get(int id)
        {
            return null;
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            List<Company> companies = await this._companyService.GetAll();

            if (companies == null || companies.Count == 0)
                return NoContent();

            List<CompanyDto> companiesResposne = companies.Select(x => this._autoMapper.Map<CompanyDto>(x)).ToList();

            return Ok(companiesResposne);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<CompanyDto> Delete(int id)
        {
            return null;
        }
    }
}
