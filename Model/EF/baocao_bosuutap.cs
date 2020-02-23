namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class baocao_bosuutap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bosuutap_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoibaocao_id { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public virtual bosuutap bosuutap { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
