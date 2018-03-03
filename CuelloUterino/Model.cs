namespace CuelloUterino
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=CuelloUterino")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Anticoncepcion> Anticoncepcion { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DiagnosticoCitologico> DiagnosticoCitologico { get; set; }
        public virtual DbSet<Edades> Edades { get; set; }
        public virtual DbSet<EstudioSolicitado> EstudioSolicitado { get; set; }
        public virtual DbSet<Fechas> Fechas { get; set; }
        public virtual DbSet<Informe> Informe { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MuestraPieza> MuestraPieza { get; set; }
        public virtual DbSet<Paridad> Paridad { get; set; }
        public virtual DbSet<ResultadoPruebaHibrida> ResultadoPruebaHibrida { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoHistologico> TipoHistologico { get; set; }
        public virtual DbSet<Valoracion> Valoracion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anticoncepcion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Anticoncepcion>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Anticoncepcion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<DiagnosticoCitologico>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticoCitologico>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.DiagnosticoCitologico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Edades>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Edades>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Edades)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudioSolicitado>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<EstudioSolicitado>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.EstudioSolicitado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fechas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Fechas>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Fechas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.telefono_convencional)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.telefono_celular)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.nombres_apellidos_referencia)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.grado_afinidad)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.recomendaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MuestraPieza>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<MuestraPieza>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.MuestraPieza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paridad>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Paridad>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Paridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ResultadoPruebaHibrida>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ResultadoPruebaHibrida>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.ResultadoPruebaHibrida)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoHistologico>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoHistologico>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.TipoHistologico)
                .HasForeignKey(e => e.idTipoHistologico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoHistologico>()
                .HasMany(e => e.Informe1)
                .WithRequired(e => e.TipoHistologico1)
                .HasForeignKey(e => e.idTipoHistologico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .HasMany(e => e.Informe)
                .WithRequired(e => e.Valoracion)
                .WillCascadeOnDelete(false);
        }
    }
}
