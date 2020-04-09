namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("video")]
    public partial class video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public video()
        {
            baocao_video = new HashSet<baocao_video>();
            video_binhluan = new HashSet<video_binhluan>();
            video_chiase = new HashSet<video_chiase>();
            nhoms = new HashSet<nhom>();
            sukiens = new HashSet<sukien>();
            trangs = new HashSet<trang>();
            nguoidungs = new HashSet<nguoidung>();
            nguoidungs1 = new HashSet<nguoidung>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public long? baiviet_id { get; set; }

        public int? nguoitao_id { get; set; }

        [StringLength(255)]
        public string tieude { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(255)]
        public string video_url { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual baiviet baiviet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baocao_video> baocao_video { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video_binhluan> video_binhluan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video_chiase> video_chiase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhom> nhoms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sukien> sukiens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trang> trangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs1 { get; set; }
    }
}
