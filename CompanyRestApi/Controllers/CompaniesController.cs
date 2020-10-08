using CompanyRestApi.Models;
using CompanyRestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi.Controllers
{ 
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companiesEntity = _companyRepository.GetCompanies();
            var companies = new List<CompanyDto>();

            foreach (var company in companiesEntity)
            {
                var tech = _companyRepository.GetTechnologies(company.Id);
                var techToAdd = new List<TechnologyDto>();
                foreach(var technology in tech)
                {
                    techToAdd.Add(new TechnologyDto()
                    {
                        Id = technology.Id,
                        Name = technology.Name,
                        Description = technology.Description,
                        Appeared = technology.Appeared
                    });
                    companies.Add(new CompanyDto()
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Description = company.Description,
                        Founded = company.Founded,
                        Technologies = techToAdd
                    });

                }                
            }
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id , Boolean returnTechnology = false )
        {
            var companyEntity = _companyRepository.GetCompany(id, returnTechnology);
            if (companyEntity == null)
            {
                return NotFound();
            }
            if (returnTechnology)
            {
                var company = new CompanyDto()
                {
                    Id = companyEntity.Id,
                    Name = companyEntity.Name,
                    Description = companyEntity.Description,
                    Founded = companyEntity.Founded
                };
                foreach (var tech in companyEntity.technologies)
                {
                    company.Technologies.Add(new TechnologyDto()
                    {
                        Id = tech.Id,
                        Name = tech.Name,
                        Description = tech.Description,
                        Appeared = tech.Appeared
                    });
                }
                return Ok(company);
            }

            var companyNoTech = new CompanyNoTechDto()
            {
                Id = companyEntity.Id,
                Name = companyEntity.Name,
                Description = companyEntity.Description,
                Founded = companyEntity.Founded
            };
            return Ok(companyNoTech);
        }
        
    }
}
