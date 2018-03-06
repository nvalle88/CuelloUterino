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
        [Display(Name = "Número de tamizaje")]
        public int IdInforme { get; set; }

        [Required]
        [Display(Name ="Nombres * ")]
        [StringLength(60)]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos * ")]
        [StringLength(60)]
        public string Apellidos { get; set; }

        [Display(Name = "Edad * ")]
        public int Edad { get; set; }

        [Display(Name = "Fecha de la muestra * ")]
        public DateTime FechaMuestra { get; set; }

        [Required]
        [Display(Name = "Identificación * ")]
        [StringLength(30)]
        public string Identificacion { get; set; }

        [Display(Name = "História clínica * ")]
        public int HistoriaClinica { get; set; }

        [StringLength(12)]
        [Display(Name = "Teléfono convencional * ")]
        public string TelefonoConvencional { get; set; }

        [StringLength(12)]
        [Display(Name = "Teléfono celular * ")]
        public string TelefonoCelular { get; set; }

        [StringLength(60)]
        [Display(Name = "Correo * ")]
        public string Correo { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Nombres y apellidos * ")]
        public string NombresApellidosReferencia { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Afinidad * ")]
        public string GradoAfinidad { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Teléfono * ")]
        public string Telefono { get; set; }

        [Display(Name = "Terapia hormonal * ")]
        public bool TerapiaHormonal { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Recomendaciones * ")]
        public string Recomendaciones { get; set; }

        [Display(Name = "Estudio * ")]
        public int IdEstudio { get; set; }

        [Display(Name = "Material * ")]
        public int IdMaterial { get; set; }

        [Display(Name = "Anticoncepción * ")]
        public int IdAnticoncepcion { get; set; }

        [Display(Name = "Edades * ")]
        public int IdEdades { get; set; }

        [Display(Name = "Paridad * ")]
        public int IdParidad { get; set; }

        [Display(Name = "Fechas * ")]
        public int IdFechas { get; set; }

        [Display(Name = "Diagnostico citológico * ")]
        public int IdDiagnosticoCitologico { get; set; }

        [Display(Name = "Valoración * ")]
        public int IdValoracion { get; set; }

        [Display(Name = "Resultado prueba híbrida * ")]
        public int IdResultadoPruebaHibrida { get; set; }

        [Display(Name = "Muestra de la pieza * ")]
        public int IdMuestraPieza { get; set; }

        [Display(Name = "Tipo histológico * ")]
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
