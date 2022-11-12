using Microsoft.AspNetCore.Mvc;
using WebCRUDMVCSQL.Models;

namespace WebCRUDMVCSQL.Controllers
{
    public class Produto : Controller
    {

        

        private readonly Contexto _Contexto;
        public Produto(Contexto contexto)
        {
            _Contexto = contexto;
        }

        public IActionResult Index()
        {

            return View(_Contexto.Produto.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Produtos produto)
        {

            if (ModelState.IsValid)
            {
                _Contexto.Produto.Add(produto);
                _Contexto.SaveChanges();

           
                return RedirectToAction("Index");
            }
            else
            {
                return View(produto);
            }

        }
    }
}
