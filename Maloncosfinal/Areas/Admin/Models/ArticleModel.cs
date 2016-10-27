using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Maloncos.Areas.Admin.Models
{
    public class ArticleModel
    {
        public int Num_Articles { get; set; }
        
        [Display(Name = "Libelle de l'article")]
        [Required(ErrorMessage = "Le libelle est obligatoire.")]
        public String Libelle { get; set; }
        public String Description { get; set; }
        public String Composition { get; set; }
        [Display(Name = "taille de l'article")]
        [Required(ErrorMessage = "La taille est obligatoire.")]
        public int Taille { get; set; }
        public String Couleur { get; set; }
        public decimal Prix_Article { get; set; }


        [Display(Name = "Fichier")]
        [Required(ErrorMessage = "L'image est obligatoire.")]
        public String Image { get; set; }
        public String Categorie { get; set; }
        public String Type { get; set; }
    }

}
