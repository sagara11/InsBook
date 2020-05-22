namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class baiviet_binhluan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public baiviet_binhluan()
        {
            baiviet_binhluan1 = new HashSet<baiviet_binhluan>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public int? nguoidung_id { get; set; }

        public long? baiviet_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public long? parent_id { get; set; }

        public virtual baiviet baiviet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_binhluan> baiviet_binhluan1 { get; set; }

        public virtual baiviet_binhluan baiviet_binhluan2 { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
