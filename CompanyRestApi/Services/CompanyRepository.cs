using CompanyRestApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        CompanyContext _ctx;
        public CompanyRepository(CompanyContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Company> GetCompanies()
        {
            return _ctx.companies.ToList();
        }

        public Company GetCompany(int companyId , Boolean returnTechnology)
        {
            if (returnTechnology)
            {
                return _ctx.companies.Include(c => c.technologies).FirstOrDefault(c => c.Id == companyId);
            }
            return _ctx.companies.FirstOrDefault(c => c.Id == companyId);
        }

        public IEnumerable<Technology> GetTechnologies(int companyId)
        {
            return _ctx.technologies.Where(t => t.CompanyId == companyId);
        }

        public Technology GetTechnology(int companyId, int technologyId)
        {
            return _ctx.technologies.FirstOrDefault(t => t.CompanyId == companyId && t.Id == technologyId);
        }

        public bool isCompanyExist(int companyId)
        {
            return _ctx.companies.Any(c => c.Id == companyId);
        }
    }
}
