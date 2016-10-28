using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maloncos.Models;
using System.IO;
using Maloncos.Areas.Admin.Models;
using System.Windows.Forms;



namespace Maloncos.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Admin/Article/
        private MaloncosEntities1 _db = new MaloncosEntities1();


        public ActionResult Index()
        {
            return View(_db.Articles.ToList());
        }

        //
        // GET: /Admin/Article/Create
        [HttpGet]
        public ActionResult CreateArticle()
        {
            var model = new ArticleModel();
            return View(model);
        } 

        //
        // POST: /Admin/Article/Create

        [HttpPost]
        public ActionResult CreateArticle(ArticleModel articleToCreate)
        {
            string image = SaveImage();

            if (!ModelState.IsValid)
                return View();

            var article = new Articles();
            article.Num_Articles = articleToCreate.Num_Articles;
            article.Libelle = articleToCreate.Libelle;
            article.Description = articleToCreate.Description;
            article.Composition = articleToCreate.Composition;
            article.Couleur = articleToCreate.Couleur;
            article.Taille = articleToCreate.Taille;
            article.Prix_Article = articleToCreate.Prix_Article;
            article.Image = image;
            article.Categorie = articleToCreate.Categorie;
            article.Type = articleToCreate.Type;
                             
            try
            {
                _db.AddToArticles(article);
                _db.SaveChanges();

                return RedirectToAction("Create_Article");
            }
            catch
            {
                return View();
            }
        }
        
             
        #region Méthode privée

        private string SaveImage()
        {
            string result= string.Empty;
           
            try
            {
                HttpPostedFileBase file;
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {

                    file = Request.Files[0] ;
                    if (file.ContentType.ToLower().Contains("image"))
                    {
                        string fileName = file.FileName;
                        string path = Path.Combine(Server.MapPath("~/Content/images/articles"), Path.GetFileName(fileName));
                        int i = 0;
                        while (System.IO.File.Exists(path))
                        {
                            i += 1;
                            fileName = i.ToString() + "-" + file.FileName;
                            path = Path.Combine(Server.MapPath("/Content/images/articles"), Path.GetFileName(fileName));
                        }

                        file.SaveAs(path);
                        result = "~/Content/images/articles/" + fileName;

                    }
                    else
                    {
                        ModelState.AddModelError("Image", "L'image de l'article est obligatoire.");
                    }

                }
                else
                {
                    ModelState.AddModelError("Image", "L'image de l'article est obligatoire.");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e);
            }

            return result;
        }

        #endregion
    //
        // GET: /Admin/Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
             var articleToEdit = (from m in _db.Articles
                       where m.Num_Articles == id
                       select m).First();
            return View(articleToEdit);
        }

        //
        // POST: /Admin/Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Articles articleToEdit)
        {
           
            if (!ModelState.IsValid)
                return View();

            try
            {   string image = SaveImageEdit();
            articleToEdit.Image = image;
                var originalArticle = (from m in _db.Articles
                                     where m.Num_Articles == articleToEdit.Num_Articles && m.Image == articleToEdit.Image
                                     select m).First();
                
                _db.ApplyCurrentValues(originalArticle.EntityKey.EntitySetName, articleToEdit);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
}
        private string SaveImageEdit()
        {
            string result =string.Empty ;

            try
            {
                HttpPostedFileBase file;
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {

                    file = Request.Files[1];
                    if (file.ContentType.ToLower().Contains("image"))
                    {
                        string fileName = file.FileName;
                        string path = Path.Combine(Server.MapPath("~/Content/images/articles"), Path.GetFileName(fileName));
                        int i = 0;
                        while (System.IO.File.Exists(path))
                        {
                            i += 1;
                            fileName = i.ToString() + "-" + file.FileName;
                            path = Path.Combine(Server.MapPath("/Content/images/articles"), Path.GetFileName(fileName));
                        }

                        file.SaveAs(path);
                        result = "~/Content/images/articles/" + fileName;

                    }
                    else
                    {
                        ModelState.AddModelError("Image", "L'image de l'article est obligatoire.");
                    }

                }
                else
                {
                    ModelState.AddModelError("Image", "L'image de l'article est obligatoire.");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e);
            }

            return result;
        }

        //
        // GET: /Admin/Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Articles articleTodelete)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


