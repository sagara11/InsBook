namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congty")]
    public partial class congty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public congty()
        {
            nguoidung_congty = new HashSet<nguoidung_congty>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string ten { get; set; }

        public int? diadiem_id { get; set; }

        public virtual diadiem diadiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_congty> nguoidung_congty { get; set; }
    }
}
