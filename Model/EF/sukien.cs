namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sukien")]
    public partial class sukien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sukien()
        {
            baocao_sukien = new HashSet<baocao_sukien>();
            sukien_lichtrinh = new HashSet<sukien_lichtrinh>();
            sukien_thanhvien = new HashSet<sukien_thanhvien>();
            baiviets = new HashSet<baiviet>();
            bosuutaps = new HashSet<bosuutap>();
            videos = new HashSet<video>();
            trangs = new HashSet<trang>();
        }

        public int id { get; set; }

        public long? anhbia_url { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        public int? diadiem_id { get; set; }

        [StringLength(255)]
        public string mota { get; set; }

        [Column(TypeName = "date")]
        public DateTime? batdau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ketthuc { get; set; }

        public int? nguoitao { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual anh anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baocao_sukien> baocao_sukien { get; set; }

        public virtual diadiem diadiem { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sukien_lichtrinh> sukien_lichtrinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sukien_thanhvien> sukien_thanhvien { get; set; }

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
