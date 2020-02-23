namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cauchuyen")]
    public partial class cauchuyen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public int? nguoitao_id { get; set; }

        public DateTime? batdau { get; set; }

        public DateTime? ketthuc { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
