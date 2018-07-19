using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Everis.Teste.Infrastructure.DataContext
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<EverisContext>
    {
        public EverisContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EverisContext>();
            builder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=yourdatabase;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(EverisContext).GetTypeInfo().Assembly.GetName().Name));

            return new EverisContext(builder.Options);
        }
    }
}
