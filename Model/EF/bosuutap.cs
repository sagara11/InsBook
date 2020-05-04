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
            baiviets = new HashSet<baiviet>();
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

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual diadiem diadiem { get; set; }

        public virtual diadiem diadiem1 { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiviet> baiviets { get; set; }
    }
}
