namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("baiviet")]
    public partial class baiviet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public baiviet()
        {
            baiviet1 = new HashSet<baiviet>();
            baiviet_binhluan = new HashSet<baiviet_binhluan>();
            baiviet_chiase = new HashSet<baiviet_chiase>();
            baiviet_luu = new HashSet<baiviet_luu>();
            anhs = new HashSet<anh>();
            nguoidungs = new HashSet<nguoidung>();
            chudes = new HashSet<chude>();
            nguoidungs1 = new HashSet<nguoidung>();
            nguoidungs2 = new HashSet<nguoidung>();
            bosuutaps = new HashSet<bosuutap>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public int? nguoitao_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? batdau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? capnhat { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public int? diadiem_id { get; set; }

        public int? baiviet_hinhnen_id { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        public int? loaibaiviet { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public long? parent_id { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviet1 { get; set; }

        public virtual baiviet baiviet2 { get; set; }

        public virtual baiviet_hinhnen baiviet_hinhnen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_binhluan> baiviet_binhluan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_chiase> baiviet_chiase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_luu> baiviet_luu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<anh> anhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs { get; set; } //chia se

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chude> chudes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs1 { get; set; } //luu

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs2 { get; set; }//thich

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap> bosuutaps { get; set; }
    }
}
