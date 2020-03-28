namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bosuutap")]
    public partial class bosuutap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bosuutap()
        {
            baocao_bosuutap = new HashSet<baocao_bosuutap>();
            bosuutap_chiase = new HashSet<bosuutap_chiase>();
            bosuutap_binhluan = new HashSet<bosuutap_binhluan>();
            anhs = new HashSet<anh>();
            nguoidungs = new HashSet<nguoidung>();
            nguoidungs1 = new HashSet<nguoidung>();
            nhoms = new HashSet<nhom>();
            sukiens = new HashSet<sukien>();
            trangs = new HashSet<trang>();
        }

        public int id { get; set; }

        public int? nguoitao_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        public int? diadiem_id { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baocao_bosuutap> baocao_bosuutap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap_chiase> bosuutap_chiase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap_binhluan> bosuutap_binhluan { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual diadiem diadiem { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<anh> anhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhom> nhoms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sukien> sukiens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trang> trangs { get; set; }
    }
}
