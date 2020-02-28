namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chude")]
    public partial class chude
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public chude()
        {
            chude1 = new HashSet<chude>();
            baiviets = new HashSet<baiviet>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string ten { get; set; }

        public int? parent_id { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chude> chude1 { get; set; }

        public virtual chude chude2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets { get; set; }
    }
}
