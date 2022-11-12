using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Protocol.Plugins;
using System;
using WebCRUDMVCSQL.Models;

namespace WebCRUDMVCSQL.Controllers
{
    public class User : Controller
    {

        private readonly Contexto _Contexto;
        public User(Contexto contexto)
        {
            _Contexto = contexto;
        }

        public IActionResult Index()
        {

            return View(_Contexto.Usuario.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.USUARIOS usuario)
        {

            if (ModelState.IsValid)
            {
                _Contexto.Usuario.Add(usuario);
                _Contexto.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }

        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USUARIOS _usuario)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                var l = _Contexto.Usuario.ToList();
                 var b = _Contexto.Usuario.First();

                var login = b.NOME_USUARIO;

                ViewBag.Funcionario = login.ToString();


                var v = l.Where(a => a.NOME_USUARIO.Equals(_usuario.NOME_USUARIO) && a.Equals(_usuario.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        //Session["usuarioLogadoID"] = v.Id.ToString();
                        //Session["nomeUsuarioLogado"] = v.NomeUsuario.ToString();
                        return RedirectToAction("Login");
                    }
                    return View("Login");
            
            }
           return View(_usuario);
        }
    }
}



