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
        public int idInforme { get; set; }

        [Required]
        [StringLength(60)]
        public string nombres { get; set; }

        [Required]
        [StringLength(60)]
        public string apellidos { get; set; }

        public int edad { get; set; }

        public DateTime fecha_muestra { get; set; }

        [Required]
        [StringLength(30)]
        public string identificacion { get; set; }

        public int historia_clinica { get; set; }

        [StringLength(12)]
        public string telefono_convencional { get; set; }

        [StringLength(12)]
        public string telefono_celular { get; set; }

        [StringLength(60)]
        public string correo { get; set; }

        [Required]
        [StringLength(120)]
        public string nombres_apellidos_referencia { get; set; }

        [Required]
        [StringLength(15)]
        public string grado_afinidad { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        public bool terapia_hormonal { get; set; }

        [Required]
        [StringLength(150)]
        public string recomendaciones { get; set; }

        public int idEstudio { get; set; }

        public int idMaterial { get; set; }

        public int idAnticoncepcion { get; set; }

        public int idEdades { get; set; }

        public int idParidad { get; set; }

        public int idFechas { get; set; }

        public int idDiagnosticoCitologico { get; set; }

        public int idValoracion { get; set; }

        public int idResultadoPruebaHibrida { get; set; }

        public int idMuestraPieza { get; set; }

        public int idTipoHistologico { get; set; }

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
