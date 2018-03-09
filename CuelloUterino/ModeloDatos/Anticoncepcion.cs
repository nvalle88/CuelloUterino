namespace CuelloUterino.ModeloDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anticoncepcion")]
    public partial class Anticoncepcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anticoncepcion()
        {
            Informe = new HashSet<Informe>();
        }

        [Key]
        public int IdAnticoncepcion { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informe> Informe { get; set; }
    }
}
