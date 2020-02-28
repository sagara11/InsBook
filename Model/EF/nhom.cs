namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhom")]
    public partial class nhom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhom()
        {
            baocao_nhom = new HashSet<baocao_nhom>();
            nhom_thanhvien = new HashSet<nhom_thanhvien>();
            baiviets = new HashSet<baiviet>();
            bosuutaps = new HashSet<bosuutap>();
            videos = new HashSet<video>();
            trangs = new HashSet<trang>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string tennhom { get; set; }

        public int? nguoitao_id { get; set; }

        [StringLength(255)]
        public string mota { get; set; }

        public bool? quyenriengtu { get; set; }

        public bool? annhom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        public long? anhbia_url { get; set; }

        public long? ghim_baiviet { get; set; }

        [StringLength(255)]
        public string duongdan_web { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual anh anh { get; set; }

        public virtual baiviet baiviet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baocao_nhom> baocao_nhom { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhom_thanhvien> nhom_thanhvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap> bosuutaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video> videos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trang> trangs { get; set; }
    }
}
