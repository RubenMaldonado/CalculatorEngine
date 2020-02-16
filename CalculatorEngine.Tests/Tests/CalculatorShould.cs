using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorEngine.Tests
{
    public class CalculatorShould
    {
        private readonly DbContextHelper _dbContextHelper;

        public CalculatorShould()
        {
            _dbContextHelper = new DbContextHelper();
        }

        [Fact]
        public async Task CalculateUsingTheFirstCoefficient()
        {
            //Arrange
            var dbContext = await _dbContextHelper.GetCalculatorDbContext();
            Calculator sut = new Calculator(dbContext);

            //Act
            var calculation = await sut.Calculate(2, 2);

            //Assert
            Assert.Equal(4, calculation);

        }

    }
}
