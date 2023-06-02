using Microsoft.EntityFrameworkCore;
using NWS_Api1.Models;


namespace NWS_Api1.Context
{
    public class AppDBContext : DbContext
    {
        // Ta Classe n'avait pas de constructeur par défaut. Le problème venait d'ici.
        // Un constructeur par défaut est un constructeur qui ne prend aucun argument.
        // Pour vérifier si une classe en possède un, tu as simplement à faire:
        // new TaClasse();
        // Si le compilateur te sors une erreur, c'est que tu n'en as pas :)
        public AppDBContext() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = "Server = localhost; Port = 3306; user = root; password = null; Database = NwsEffectif; Integrated Security = True; TrustServerCertificate = True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(str, ServerVersion.AutoDetect(str));
        }

        public DbSet<Nws> nws { get; set; }
    }
}
