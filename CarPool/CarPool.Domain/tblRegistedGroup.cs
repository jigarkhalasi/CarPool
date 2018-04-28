namespace CarPool.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRegistedGroup")]
    public partial class tblRegistedGroup
    {
        [Key]
        public int RGroupId { get; set; }

        public int? RGType { get; set; }

        [StringLength(1000)]
        public string RGName { get; set; }

        [StringLength(50)]
        public string StartFrom { get; set; }

        [StringLength(50)]
        public string EndFrom { get; set; }

        public string RGDesc { get; set; }

        public DateTime? RGCreatedDate { get; set; }

        public string RGImagePath { get; set; }

        public bool? IsAutoRegister { get; set; }

        [StringLength(50)]
        public string RGLink { get; set; }

        public int? IsRanking { get; set; }

        public int? City { get; set; }

        public int? Country { get; set; }

        public string GroupAdmin { get; set; }

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
