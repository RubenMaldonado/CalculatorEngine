using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CalculatorEngine
{
    public class Calculator
    {
        private readonly IDbContext _context;

        public Calculator(IDbContext context)
        {
            _context = context;
        }
        
        public async Task<decimal> Calculate(int a, int b)
        {
            var coefficient = await _context.Coefficients.FirstOrDefaultAsync();

            return a + b * coefficient.CoefficientValue;
        }
    }
}