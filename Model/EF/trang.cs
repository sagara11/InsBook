namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trang")]
    public partial class trang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trang()
        {
            baocao_trang = new HashSet<baocao_trang>();
            trang_vaitro = new HashSet<trang_vaitro>();
            baiviets = new HashSet<baiviet>();
            bosuutaps = new HashSet<bosuutap>();
            hangmuc_trang = new HashSet<hangmuc_trang>();
            tinnhans = new HashSet<tinnhan>();
            nhoms = new HashSet<nhom>();
            sukiens = new HashSet<sukien>();
            videos = new HashSet<video>();
        }

        public int id { get; set; }

        public int? nguoitao_id { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        [StringLength(255)]
        public string tennguoidung { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string web { get; set; }

        [StringLength(255)]
        public string sdt { get; set; }

        public long? anhdd { get; set; }

        public long? anhbia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(255)]
        public string mota { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual anh anh { get; set; }

        public virtual anh anh1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baocao_trang> baocao_trang { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trang_vaitro> trang_vaitro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap> bosuutaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hangmuc_trang> hangmuc_trang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tinnhan> tinnhans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhom> nhoms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sukien> sukiens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video> videos { get; set; }
    }
}
