namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhomtinnhan")]
    public partial class nhomtinnhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhomtinnhan()
        {
            nhomtinnhan_nguoidung = new HashSet<nhomtinnhan_nguoidung>();
            tinnhans = new HashSet<tinnhan>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string tennhom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhomtinnhan_nguoidung> nhomtinnhan_nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tinnhan> tinnhans { get; set; }
    }
}
