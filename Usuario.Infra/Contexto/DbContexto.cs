using Microsoft.EntityFrameworkCore;
using Usuario.Business.Entidade;

namespace Usuario.Infra.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
