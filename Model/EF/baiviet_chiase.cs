namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class baiviet_chiase
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long baiviet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung_id { get; set; }

        [StringLength(255)]
        public string tieude { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        public virtual baiviet baiviet { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
