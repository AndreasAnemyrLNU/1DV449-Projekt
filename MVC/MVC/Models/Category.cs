using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Category
    {
        public Category()
        {
            this.Apps = new HashSet<App>();
            this.Places = new HashSet<Place>();
        }

        public int Id { get; set; }

        [DisplayName("Namn")]
        [StringLength(25, ErrorMessage = "Min 3 tecken, Max 25 tecken", MinimumLength = 3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Måste anges")]
        public string Name { get; set; }

        public string User { get; set; }

        public virtual ICollection<App> Apps { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
