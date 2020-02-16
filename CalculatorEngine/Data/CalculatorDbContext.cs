using System;
using CalculatorEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorEngine
{
    // Interface for Db Context ------------------------------------------------
    public interface IDbContext
    {

        DbSet<Coefficient> Coefficients { get; set; }

    }

    // Db Context --------------------------------------------------------------
    public class ICalculatorDbContext : DbContext, IDbContext
    {
        public ICalculatorDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ICalculatorDbContext()
        {
        }


        public DbSet<Coefficient> Coefficients { get; set; }

    }

}
