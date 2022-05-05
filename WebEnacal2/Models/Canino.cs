using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEnacal2.Models
{
    public class Canino
    {
        [Key]
        public int Id { get; set; }
        public string NombreCanino { get; set; }
        public string Raza { get; set; }
        public int EdadCanina { get; set; }
    }
}
