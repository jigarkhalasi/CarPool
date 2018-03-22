namespace CarPool.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUserRGDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GRId { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public int? RGroupId { get; set; }

        [StringLength(50)]
        public string JustificationDesc { get; set; }

        [MaxLength(50)]
        public byte[] ImagePath { get; set; }

        public bool? IsActivate { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
