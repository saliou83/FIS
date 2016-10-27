using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Maloncos.Areas.Admin.Models
{
    public class TestModel
    {
        [Display(Name = "Fichier")]
        [Required(ErrorMessage = "Entrer le fichier à envoyer.")]
        public string file { get; set; }
    }
}