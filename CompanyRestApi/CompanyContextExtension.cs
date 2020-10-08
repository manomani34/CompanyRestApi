using CompanyRestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi
{
    public static class CompanyContextExtension
    {
        public static void EnsureSeedDataForContext(this CompanyContext context)
        {
            if(context.companies.Any())
            {
                return;
            }

            var companies = new List<Company>()
            {
                new Company
                {
                    Name = "Microsoft",
                    Description = "Microsoft Corporation is an amiracan Multinational technology company",
                    Founded = new DateTime(1975 , 4 , 4),
                    technologies = new List<Technology>()
                    {
                        new Technology
                        {
                            Name = "C#",
                            Description = "a multi-paradigm programming language.",
                            Appeared = new DateTime(2000 , 1 , 1)
                        },
                         new Technology
                        {
                            Name = "TypeScript",
                            Description = "this is a strict syntactical superset of javascript.",
                            Appeared = new DateTime(2012 , 1 , 1)
                        },
                          new Technology
                        {
                            Name = "F#",
                            Description = "a Strongly typed, multi-paradigm programming.",
                            Appeared = new DateTime(2005 , 1 , 1)
                        }
                    }
                },
                new Company()
                {
                     Name = "Apple",
                    Description = "Apple inc, is an american multinational technology company.",
                    Founded = new DateTime(1976 , 4 , 1),
                    technologies = new List<Technology>()
                    {
                        new Technology()
                        {
                            Name = "Objective-c",
                            Description = "this was the main programming.",
                            Appeared = new DateTime(2000 , 1 , 1)
                        },
                         new Technology
                        {
                            Name = "Swift",
                            Description = "this is a strict syntactical superset of javascript.",
                            Appeared = new DateTime(2014 , 1 , 1)
                        }
                    }
                }
            };
            context.companies.AddRange(companies);
            context.SaveChanges();
                
        }
    }
}
