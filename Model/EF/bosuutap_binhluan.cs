namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bosuutap_binhluan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bosuutap_binhluan()
        {
            bosuutap_binhluan1 = new HashSet<bosuutap_binhluan>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public int? nguoidung_id { get; set; }

        public int? bosuutap_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public long? parent_id { get; set; }

        public virtual bosuutap bosuutap { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap_binhluan> bosuutap_binhluan1 { get; set; }

        public virtual bosuutap_binhluan bosuutap_binhluan2 { get; set; }
    }
}
