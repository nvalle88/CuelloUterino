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

        [DisplayName("Historia cl�nica")]
        public int? HistoriaClinica { get; set; }

        [StringLength(12)]
        [DisplayName("Tel�fono convencional")]
        public string TelefonoConvencional { get; set; }

        [StringLength(12)]
        [DisplayName("Tel�fono celular")]
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
        [DisplayName("Tel�fono celular")]
        public string TelefonoCelularReferencia { get; set; }

        [DisplayName("� Terapia hormonal ?")]
        public bool TerapiaHormonal { get; set; }

        [StringLength(2000)]
        [DisplayName("Recomendaciones")]
        public string Recomendaciones { get; set; }

        [DisplayName("Material")]
        public int IdMaterial { get; set; }

        [DisplayName("Anticoncepci�n")]
        public int IdAnticoncepcion { get; set; }

        [DisplayName("Edades")]
        public int IdEdades { get; set; }

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

        [DisplayName("�ltima menstruaci�n")]
        public string UltimaMenstruacion { get; set; }

        [DisplayName("�ltimo parto")]
        public string UltimoParto { get; set; }

        [DisplayName("�ltima citolog�a")]
        public string UltimaCitologia { get; set; }

        [DisplayName("# Partos")]
        public string NumeroPartos { get; set; }

        [DisplayName("# Abortos")]
        public string NumeroAbortos { get; set; }

        [DisplayName("# Gestaciones")]
        public string NumeroGestaciones { get; set; }

        [DisplayName("# Ces�reas")]
        public string NumeroCesareas { get; set; }

        [DisplayName("Descripci�n del material")]
        public string OtroMaterial { get; set; }

        [DisplayName("Descripci�n de la anticoncepci�n")]
        public string OtroAnticoncepcion { get; set; }

        [DisplayName("Descripci�n de las edades")]
        public string OtroEdades { get; set; }

        [DisplayName("Descripci�n de la valoraci�n")]
        public string DescripcionValoracion { get; set; }

        [DisplayName("Descripci�n de la anticoncepci�n")]
        public string AnticoncepcionOralInyectable { get; set; }

        [DisplayName("Descripci�n del diagnostico citol�gico")]
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
