using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCRUDMVCSQL.Models;


namespace WebCRUDMVCSQL.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _Contexto;
        public LoginController(Contexto contexto)
        {
            _Contexto = contexto;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string NOME_USUARIO, string senha)
        {

            var account = _Contexto.Usuario.ToList();
            string NOME_USUARIOX = account[0].NOME_USUARIO.ToString();
            var data = account.Where(s => s.NOME_USUARIO.Equals(NOME_USUARIO)).ToList();
            if (account != null)
            {

                HttpContext.Session.SetString("NOME_USUARIO", NOME_USUARIOX);

                return View( );

            }



            // var f_password = GetMD5(password);
            //var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
            //if (data.Count() > 0)
            //{
            //    //add session
            //    HttpContext.Session.SetString("Email", email);

            //       // = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
            //    //Session["Email"] = data.FirstOrDefault().Email;
            //    //Session["idUser"] = data.FirstOrDefault().idUser;
            //    return RedirectToAction("Index");
            //}

            //    else
            //    {
            //        ViewBag.error = "Login failed";
            //        return RedirectToAction("Login");
            //    }
            //}

            return View();
        }

        public IActionResult Administrador()
        {
            return View();
        }
        public IActionResult ProcessarLogin( USUARIOS _UsuarioModel)
        {

            var data = _Contexto.Usuario.Where(s => s.NOME_USUARIO.Equals(_UsuarioModel.NOME_USUARIO) && s.Senha.Equals(_UsuarioModel.Senha)).ToList();
            if ( data.Count > 0 )
            {
               ViewBag.UsuarioLogado = _UsuarioModel.NOME_USUARIO;
                return View("Administrador", _UsuarioModel);
            }
            ViewBag.msg = "Erro de login";
          
            return View("../Home/Index", _UsuarioModel);
        }


        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Login");
        }


    }
}
