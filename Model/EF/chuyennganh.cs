namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chuyennganh")]
    public partial class chuyennganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public chuyennganh()
        {
            chuyennganh1 = new HashSet<chuyennganh>();
            nguoidung_truonghoc_chuyennganh = new HashSet<nguoidung_truonghoc_chuyennganh>();
            truonghocs = new HashSet<truonghoc>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        public int? parent_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyennganh> chuyennganh1 { get; set; }

        public virtual chuyennganh chuyennganh2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_truonghoc_chuyennganh> nguoidung_truonghoc_chuyennganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<truonghoc> truonghocs { get; set; }
    }
}
