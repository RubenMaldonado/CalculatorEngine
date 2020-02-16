using System;
using System.Threading.Tasks;
using CalculatorEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorEngine.Tests
{
    public class DbContextHelper
    {
        public async Task<ICalculatorDbContext> GetCalculatorDbContext()
        {

            // Create an inMemoryDatabase in order to be used by our tests.
            var options = new DbContextOptionsBuilder<ICalculatorDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new ICalculatorDbContext(options);

            dbContext.Database.EnsureCreated();

            // Initialize Coefficients with incremental values 1,2,3l4
            if (await dbContext.Coefficients.CountAsync() <= 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    dbContext.Coefficients.Add(new Coefficient()
                    {
                        Id = Guid.NewGuid(),
                        CoefficientValue = i
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;
        }
    }
}