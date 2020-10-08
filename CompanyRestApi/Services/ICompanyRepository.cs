using CompanyRestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi.Services
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int companyId , Boolean returnTechnology);
        IEnumerable<Technology> GetTechnologies(int companyId);
        Technology GetTechnology(int companyId, int technologyId);
        bool isCompanyExist(int companyId);
    }
}
