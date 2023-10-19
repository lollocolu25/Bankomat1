using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bankomat1
{
    //public partial class EsercitazioneEntities : DbContext
    //{
    //    public EsercitazioneEntities()
    //        : base("name=EsercitazioneEntities")
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        throw new UnintentionalCodeFirstException();
    //    }

    //    public virtual DbSet<Banche> Banches { get; set; }
    //    //public virtual DbSet<Banche_Funzionalita> Banche_Funzionalita { get; set; }
    //    //public virtual DbSet<ContiCorrente> ContiCorrentes { get; set; }
    //    //public virtual DbSet<Funzionalita> Funzionalitas { get; set; }
    //    //public virtual DbSet<Movimenti> Movimentis { get; set; }
    //    public virtual DbSet<Utenti> Utentis { get; set; }
    //}
   
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new EsercitazioneEntities();
            Interfaccia interfacciautente = new Interfaccia();
            interfacciautente.Esegui(ctx);
        }

    }
}
