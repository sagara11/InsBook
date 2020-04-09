namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nguoidung_tinhtrang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung2 { get; set; }

        [StringLength(100)]
        public string loaitinhtrang { get; set; }

        public bool? xacnhan { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        public virtual nguoidung nguoidung3 { get; set; }
    }
}
