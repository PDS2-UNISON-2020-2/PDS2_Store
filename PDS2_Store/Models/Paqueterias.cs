using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Paqueterias
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Paquete> pqt { get; set; }
        public virtual ICollection<Telefonos> tel { get; set; }
        public virtual ICollection<Correos> correo { get; set; }

        public virtual ICollection<Destinos> des { get; set; }

        public Paqueterias()
        {
            tel = new List<Telefonos>();
            correo = new List<Correos>();
            des = new List<Destinos>();
            pqt = new List<Paquete>();
        }
    }
    public class Paquete
    {
        [Key]
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public int DiasMin { get; set; }
        public int DiasMax { get; set; }
        public bool Express { get; set; }
        [ForeignKey("Paqueterias")]
        public int PaqueteriasId { get; set; }
        public virtual Paqueterias Paqueterias { get; set; }
    }

    public class Telefonos
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Paqueterias")]
        public int PaqueteriasId { get; set; }
        public string telefono { get; set; }
        public Paqueterias Paqueterias { get; set; }
    }

    public class Correos
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Paqueterias")]
        public int PaqueteriasId { get; set; }
        public string correo { get; set; }
        public Paqueterias Paqueterias { get; set; }
    }

    public class Destinos
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public ICollection<Paqueterias> paqueterias { get; set; }


        public Destinos()
        {
            this.paqueterias = new List<Paqueterias>();
        }
    }

   /* public class PaqueteriasDestinos
    {
        [Key, Column(Order = 0)]
        public int PaqueteriasId { get; set; }
        [Key, Column(Order = 1)]
        public int DestinosId { get; set; }
        public virtual Paqueterias Paqueterias { get; set; }
        public virtual Destinos Destinos { get; set; }
    }*/


    public class PaqueteriaCompraViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int PaquetesId { get; set; }
        public decimal Precio { get; set; }

        public int PaquetesExpressId { get; set; }
        public decimal PrecioEx { get; set; }
    }

    public class PaqueteriasContext : DbContext
    {
        public PaqueteriasContext()
            : base("DefaultConnection")
        {
            //this.Configuration.ProxyCreationEnabled = true;
            //this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Paqueterias> Paqueterias { get; set; }
        public DbSet<Paquete> Paquete { get; set; }

        public DbSet<Telefonos> Telefonos { get; set; }

        public DbSet<Correos> Correos { get; set; }

        public DbSet<Destinos> Destinos { get; set; }
        //public DbSet<Destinos> PaqueteriasDestinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Paqueterias>().HasKey(t => t.Id);
            
            modelBuilder.Entity<Paqueterias>()
                         .HasMany(u => u.pqt)
                         .WithRequired(a => a.Paqueterias)
                         .HasForeignKey(a => a.PaqueteriasId);

            modelBuilder.Entity<Paqueterias>()
                          .HasMany(u => u.tel)
                          .WithRequired(a => a.Paqueterias)
                          .HasForeignKey(a => a.PaqueteriasId);

            modelBuilder.Entity<Paqueterias>()
                          .HasMany(u => u.correo)
                          .WithRequired(a => a.Paqueterias)
                          .HasForeignKey(a => a.PaqueteriasId);

            modelBuilder.Entity<Paqueterias>()
                .HasMany<Destinos>(s => s.des)
                .WithMany(c => c.paqueterias)
                .Map(cs =>
                {
                    cs.MapLeftKey("PaqueteriasId");
                    cs.MapRightKey("DestinosId");
                    cs.ToTable("PaqueteriasDestinos");
                });
        }
    }
}