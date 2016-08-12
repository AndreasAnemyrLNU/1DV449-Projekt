using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class AdminViewModel
    {
        [DisplayName("Appar")]
        public IEnumerable<App> Apps { get; set; }

        [DisplayName("Kategorier")]
        public  IEnumerable<Category> Categories { get; set; }

        [DisplayName("Platser")]
        public IEnumerable<Place> Places { get; set; }
    }
}
