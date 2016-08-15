using System;
using System.Collections.Generic;
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
        public string Name { get; set; }

        public string User { get; set; }

        public virtual ICollection<App> Apps { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
