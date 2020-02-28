namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nguoidung_truonghoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nguoidung_truonghoc()
        {
            nguoidung_truonghoc_chuyennganh = new HashSet<nguoidung_truonghoc_chuyennganh>();
        }

        public int id { get; set; }

        public int? truonghoc_id { get; set; }

        public int? nguoidung_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? batdau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ketthuc { get; set; }

        [StringLength(255)]
        public string mota { get; set; }

        public bool? totnghiep { get; set; }

        public int baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_truonghoc_chuyennganh> nguoidung_truonghoc_chuyennganh { get; set; }

        public virtual truonghoc truonghoc { get; set; }
    }
}
