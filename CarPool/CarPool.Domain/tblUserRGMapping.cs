namespace CarPool.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUserRGMapping")]
    public partial class tblUserRGMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserRGId { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public int? RGroupId { get; set; }
    }
}
