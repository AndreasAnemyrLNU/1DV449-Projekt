using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
