using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Models
{
    public class ApproveUserRequestModel
    {
        public int GRId { get; set; }
        public int UserId { get; set; }
        public bool IsStatus { get; set; }
    }
}