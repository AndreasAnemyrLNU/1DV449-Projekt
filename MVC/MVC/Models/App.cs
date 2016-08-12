using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class App
    {
        public int Id { get; set; }

        [DisplayName("Namn")]
        [StringLength(25, ErrorMessage = "Min 3 tecken, Max 25 tecken", MinimumLength = 3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Måste anges")]
        public string AppName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
 