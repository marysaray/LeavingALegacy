using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeavingALegacy.Models
{
    public class Location
    {
        [Key]
        public int SecId { get; set; }

        public string LocationName { get; set; }
    }
}
