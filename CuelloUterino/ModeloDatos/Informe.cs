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
        [DisplayName("N�mero")]
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
        [DisplayName("Identificaci�n")]
        public string Identificacion { get; set; }

        public int HistoriaClinica { get; set; }

        [StringLength(12)]
        [DisplayName("Tel�fono convencional")]
        public string TelefonoConvencional { get; set; }

        [StringLength(12)]
        [DisplayName("Tel�fono celular")]
        public string TelefonoCelular { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Correo")]
        public string Correo { get; set; }

        [Required]
        [StringLength(120)]
        [DisplayName("Nombres y apellidos")]
        public string NombresApellidosReferencia { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Afinidad")]
        public string GradoAfinidad { get; set; }

        [StringLength(15)]
        [DisplayName("Tel�fono celular")]
        public string TelefonoCelularReferencia { get; set; }
        [DisplayName("� Terapia hormonal ?")]
        public bool TerapiaHormonal { get; set; }

        [Required]
        [StringLength(2000)]
        [DisplayName("Recomendaciones")]
        public string Recomendaciones { get; set; }

        [DisplayName("Material")]
        public int IdMaterial { get; set; }

        [DisplayName("Anticoncepci�n")]
        public int IdAnticoncepcion { get; set; }

        [DisplayName("Edades")]
        public int IdEdades { get; set; }

        [DisplayName("Paridad")]
        public int IdParidad { get; set; }

        [DisplayName("Diagnostico citol�gico")]
        public int IdDiagnosticoCitologico { get; set; }

        [DisplayName("Valoraci�n")]
        public int IdValoracion { get; set; }

        [DisplayName("Resultado prueba h�brida")]
        public int IdResultadoPruebaHibrida { get; set; }

        [DisplayName("Muestra")]
        public int IdMuestraPieza { get; set; }

        [DisplayName("Tipo histol�gico")]
        public int IdTipoHistologico { get; set; }

        [StringLength(12)]
        [DisplayName("Tel�fono convencional")]
        public string TelefonoConvencionalReferencia { get; set; }

        [DisplayName("� Citolog�a/VPH ?")]
        public bool CitologiaVPH { get; set; }

        [DisplayName("� Histopatolog�a ?")]
        public bool Histopatologia { get; set; }

        [DisplayName("� Coloscop�a ?")]
        public bool Coloscopia { get; set; }

        [DisplayName("� Biopsia ?")]
        public bool Biopsia { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("�ltima menstruaci�n")]
        public DateTime? UltimaMenstruacion { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("�ltimo parto")]
        public DateTime? UltimoParto { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("�ltima citolog�a")]
        public DateTime? UltimaCitologia { get; set; }

        public virtual Anticoncepcion Anticoncepcion { get; set; }

        public virtual DiagnosticoCitologico DiagnosticoCitologico { get; set; }

        public virtual Edades Edades { get; set; }

        public virtual Material Material { get; set; }

        public virtual MuestraPieza MuestraPieza { get; set; }

        public virtual Paridad Paridad { get; set; }

        public virtual ResultadoPruebaHibrida ResultadoPruebaHibrida { get; set; }

        public virtual TipoHistologico TipoHistologico { get; set; }

        public virtual TipoHistologico TipoHistologico1 { get; set; }

        public virtual Valoracion Valoracion { get; set; }
    }
}
