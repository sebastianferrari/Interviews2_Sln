using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

namespace Interviews2.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Candidate.Any())
            {
                context.Candidate.Add(
                    new Candidate
                    {
                        Name = "Candidate 1",
                        EMail = "candidate1@email.com"
                    });

                context.Candidate.Add(
                    new Candidate
                    {
                        Name = "Candidate 2",
                        EMail = "candidate2@email.com"
                    });

                context.Candidate.Add(
                    new Candidate
                    {
                        Name = "Candidate 3",
                        EMail = "candidate3@email.com"
                    });
            }

            context.SaveChanges();
        }
    }
}
