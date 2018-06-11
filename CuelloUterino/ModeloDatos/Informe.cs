namespace CuelloUterino.ModeloDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Informe")]
    public partial class Informe
    {
        [Key]
        [DisplayName("Número")]
        public int IdInforme { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Edad")]
        public int Edad { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de la muestra")]
        public DateTime FechaMuestra { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }

        [DisplayName("Historia clínica")]
        public int? HistoriaClinica { get; set; }

        [StringLength(12)]
        [DisplayName("Teléfono convencional")]
        public string TelefonoConvencional { get; set; }

        [StringLength(12)]
        [DisplayName("Teléfono celular")]
        public string TelefonoCelular { get; set; }

        [StringLength(60)]
        [DisplayName("Correo")]
        public string Correo { get; set; }

        [StringLength(120)]
        [DisplayName("Nombres y apellidos")]
        public string NombresApellidosReferencia { get; set; }

        [StringLength(15)]
        [DisplayName("Afinidad")]
        public string GradoAfinidad { get; set; }

        [StringLength(15)]
        [DisplayName("Teléfono celular")]
        public string TelefonoCelularReferencia { get; set; }

        [DisplayName("¿ Terapia hormonal ?")]
        public bool TerapiaHormonal { get; set; }

        [StringLength(2000)]
        [DisplayName("Recomendaciones")]
        public string Recomendaciones { get; set; }

        [DisplayName("Material")]
        public int IdMaterial { get; set; }

        [DisplayName("Anticoncepción")]
        public int IdAnticoncepcion { get; set; }

        [DisplayName("Edades")]
        public int IdEdades { get; set; }

        [DisplayName("Diagnostico citológico")]
        public int IdDiagnosticoCitologico { get; set; }

        [DisplayName("Valoración")]
        public int IdValoracion { get; set; }

        [DisplayName("Resultado prueba híbrida")]
        public int IdResultadoPruebaHibrida { get; set; }

        [DisplayName("Muestra")]
        public int IdMuestraPieza { get; set; }

        [DisplayName("Tipo histológico")]
        public int IdTipoHistologico { get; set; }

        [StringLength(12)]
        [DisplayName("Teléfono convencional")]
        public string TelefonoConvencionalReferencia { get; set; }

        [DisplayName("¿ Citología/VPH ?")]
        public bool CitologiaVPH { get; set; }

        [DisplayName("¿ Histopatología ?")]
        public bool Histopatologia { get; set; }

        [DisplayName("¿ Coloscopía ?")]
        public bool Coloscopia { get; set; }

        [DisplayName("¿ Biopsia ?")]
        public bool Biopsia { get; set; }

        [DisplayName("Última menstruación")]
        public string UltimaMenstruacion { get; set; }

        [DisplayName("Último parto")]
        public string UltimoParto { get; set; }

        [DisplayName("Última citología")]
        public string UltimaCitologia { get; set; }

        [DisplayName("# Partos")]
        public string NumeroPartos { get; set; }

        [DisplayName("# Abortos")]
        public string NumeroAbortos { get; set; }

        [DisplayName("# Gestaciones")]
        public string NumeroGestaciones { get; set; }

        [DisplayName("# Cesáreas")]
        public string NumeroCesareas { get; set; }

        [DisplayName("Descripción del material")]
        public string OtroMaterial { get; set; }

        [DisplayName("Descripción de la anticoncepción")]
        public string OtroAnticoncepcion { get; set; }

        [DisplayName("Descripción de las edades")]
        public string OtroEdades { get; set; }

        [DisplayName("Descripción de la valoración")]
        public string DescripcionValoracion { get; set; }

        [DisplayName("Descripción de la anticoncepción")]
        public string AnticoncepcionOralInyectable { get; set; }

        [DisplayName("Descripción del diagnostico citológico")]
        public string OtroDiagnosticoCitologico { get; set; }

        public virtual Anticoncepcion Anticoncepcion { get; set; }

        public virtual DiagnosticoCitologico DiagnosticoCitologico { get; set; }

        public virtual Edades Edades { get; set; }

        public virtual Material Material { get; set; }

        public virtual MuestraPieza MuestraPieza { get; set; }

        public virtual ResultadoPruebaHibrida ResultadoPruebaHibrida { get; set; }

        public virtual TipoHistologico TipoHistologico { get; set; }

        public virtual TipoHistologico TipoHistologico1 { get; set; }

        public virtual Valoracion Valoracion { get; set; }
    }
}
