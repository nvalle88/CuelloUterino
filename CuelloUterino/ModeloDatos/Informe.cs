namespace CuelloUterino
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Informe")]
    public partial class Informe
    {
        [Key]
        public int IdInforme { get; set; }

        [Required]
        [Display(Name ="Nombres (*)")]
        [StringLength(60)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(60)]
        public string Apellidos { get; set; }

        public int Edad { get; set; }

        public DateTime FechaMuestra { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificacion { get; set; }

        public int HistoriaClinica { get; set; }

        [StringLength(12)]
        public string TelefonoConvencional { get; set; }

        [StringLength(12)]
        public string TelefonoCelular { get; set; }

        [StringLength(60)]
        public string Correo { get; set; }

        [Required]
        [StringLength(120)]
        public string NombresApellidosReferencia { get; set; }

        [Required]
        [StringLength(15)]
        public string GradoAfinidad { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        public bool TerapiaHormonal { get; set; }

        [Required]
        [StringLength(150)]
        public string Recomendaciones { get; set; }

        public int IdEstudio { get; set; }

        public int IdMaterial { get; set; }

        public int IdAnticoncepcion { get; set; }

        public int IdEdades { get; set; }

        public int IdParidad { get; set; }

        public int IdFechas { get; set; }

        public int IdDiagnosticoCitologico { get; set; }

        public int IdValoracion { get; set; }

        public int IdResultadoPruebaHibrida { get; set; }

        public int IdMuestraPieza { get; set; }

        public int IdTipoHistologico { get; set; }

        public virtual Anticoncepcion Anticoncepcion { get; set; }

        public virtual DiagnosticoCitologico DiagnosticoCitologico { get; set; }

        public virtual Edades Edades { get; set; }

        public virtual EstudioSolicitado EstudioSolicitado { get; set; }

        public virtual Fechas Fechas { get; set; }

        public virtual Material Material { get; set; }

        public virtual MuestraPieza MuestraPieza { get; set; }

        public virtual Paridad Paridad { get; set; }

        public virtual ResultadoPruebaHibrida ResultadoPruebaHibrida { get; set; }

        public virtual TipoHistologico TipoHistologico { get; set; }

        public virtual TipoHistologico TipoHistologico1 { get; set; }

        public virtual Valoracion Valoracion { get; set; }
    }
}
