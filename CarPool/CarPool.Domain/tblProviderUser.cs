namespace CarPool.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProviderUser")]
    public partial class tblProviderUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProviderId { get; set; }

        public string UserId { get; set; }

        public int? TotalYearExp { get; set; }

        [StringLength(50)]
        public string CarModel { get; set; }

        [StringLength(50)]
        public string RegistrationNo { get; set; }

        [StringLength(50)]
        public string StartPoint { get; set; }

        [StringLength(50)]
        public string EndPoint { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
