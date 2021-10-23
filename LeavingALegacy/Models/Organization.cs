using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeavingALegacy.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        public string Development { get; set; }

        public string Description { get; set; }

        public Administrator Manager { get; set; }
    }
}
