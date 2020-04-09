namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nguoidung_diadiem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int diadiem_id { get; set; }

        public int? loaidiadiem { get; set; }

        public int? baomat { get; set; }

        public int? baomat_chophep { get; set; }

        public int? baomat_chan { get; set; }

        public virtual chan_chiase chan_chiase { get; set; }

        public virtual chophep_chiase chophep_chiase { get; set; }

        public virtual diadiem diadiem { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
