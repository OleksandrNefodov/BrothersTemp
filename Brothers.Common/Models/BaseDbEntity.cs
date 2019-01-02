using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Brothers.Common.Models
{
    public class BaseDbEntity
    {
        public BaseDbEntity()
        {
            Created = DateTime.Now;
            Modified = Created;
        }

        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = "Test";

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; } = "Test";
    }
}