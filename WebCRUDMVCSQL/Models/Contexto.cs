using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;


namespace WebCRUDMVCSQL.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {


        }

        public DbSet<USUARIOS>  Usuario { get; set; }
        public DbSet<Produtos> Produto { get; set; }

      
    }
}
