namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nguoidung")]
    public partial class nguoidung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nguoidung()
        {
            baiviets = new HashSet<baiviet>();
            baiviet_binhluan = new HashSet<baiviet_binhluan>();
            baiviet_chiase = new HashSet<baiviet_chiase>();
            baiviet_luu = new HashSet<baiviet_luu>();
            banbes = new HashSet<banbe>();
            banbes1 = new HashSet<banbe>();
            banbes2 = new HashSet<banbe>();
            bosuutaps = new HashSet<bosuutap>();
            nguoidung_diadiem = new HashSet<nguoidung_diadiem>();
            nguoidung_tinhtrang = new HashSet<nguoidung_tinhtrang>();
            nguoidung_tinhtrang1 = new HashSet<nguoidung_tinhtrang>();
            nguoidung_truonghoc = new HashSet<nguoidung_truonghoc>();
            nguoidung_congty = new HashSet<nguoidung_congty>();
            baiviets1 = new HashSet<baiviet>();
            baiviets2 = new HashSet<baiviet>();
            baiviets3 = new HashSet<baiviet>();
            chan_chiase = new HashSet<chan_chiase>();
            chophep_chiase = new HashSet<chophep_chiase>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string ho { get; set; }

        [StringLength(255)]
        public string ten { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string matkhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

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
        public string bietdanh { get; set; }

        [StringLength(255)]
        public string loitrichdan { get; set; }

        [StringLength(100)]
        public string gioitinh { get; set; }

        public int? vaitro { get; set; }

        public int? soluongbanbe { get; set; }

        public long? soluongtheodoi { get; set; }

        public long? soluongbaiviet { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual anh anh { get; set; }

        public virtual anh anh1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_binhluan> baiviet_binhluan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_chiase> baiviet_chiase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet_luu> baiviet_luu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<banbe> banbes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<banbe> banbes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<banbe> banbes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bosuutap> bosuutaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_diadiem> nguoidung_diadiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_tinhtrang> nguoidung_tinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_tinhtrang> nguoidung_tinhtrang1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_truonghoc> nguoidung_truonghoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung_congty> nguoidung_congty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chan_chiase> chan_chiase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chophep_chiase> chophep_chiase { get; set; }
    }
}
