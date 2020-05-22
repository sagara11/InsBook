namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("truonghoc")]
    public partial class truonghoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public truonghoc()
        {
            nguoidung_truonghoc = new HashSet<nguoidung_truonghoc>();
            chuyennganhs = new HashSet<chuyennganh>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        public int? diadiem_id { get; set; }

        [StringLength(255)]
        public string anh_url { get; set; }

        public int? loaitruong { get; set; }

        public virtual diadiem diadiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_truonghoc> nguoidung_truonghoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyennganh> chuyennganhs { get; set; }
    }
}
