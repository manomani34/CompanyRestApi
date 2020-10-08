using CompanyRestApi.Models;
using CompanyRestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi.Controllers
{
    [Route("api/companies/{companyId}/technologies")]
    public class TechnologiesController : ControllerBase
    {
        ICompanyRepository _companyRepository;
        public TechnologiesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetTechnologies(int companyId)
        {
            if (!_companyRepository.isCompanyExist(companyId))
            {
                return NotFound();
            }
            var techEntity = _companyRepository.GetTechnologies(companyId);
            var tech = new List<TechnologyDto>();
            foreach(var technology in techEntity)
            {
                tech.Add(new TechnologyDto()
                {
                    Id = technology.Id,
                    Name = technology.Name,
                    Description = technology.Description,
                    Appeared = technology.Appeared
                });
            }
            return Ok(tech);
        }
        [HttpGet("{id}")]
        public IActionResult GetTechnology(int companyId , int id)
        {
            if(!_companyRepository.isCompanyExist(companyId))
            {
                return NotFound();
            }
            var techEntity = _companyRepository.GetTechnology(companyId, id);
            if (techEntity == null)
            {
                return NotFound();
            }
            var tech = new TechnologyDto
            {
                Id = techEntity.Id,
                Name = techEntity.Name,
                Description = techEntity.Description,
                Appeared = techEntity.Appeared
            };
            return Ok(tech);
        }
    }
}
