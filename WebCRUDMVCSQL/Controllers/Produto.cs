using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
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
        public ActionResult GerarXML()
        {

            {  
                var all = _Contexto.Produto.ToList();
                XmlWriterSettings settings = new XmlWriterSettings();
                //StreamWriter sw = new StreamWriter("E:\\Test.txt");
                ////Write a line of text
                //sw.WriteLine("Hello World!!");
                ////Write a second line of text
                //sw.WriteLine("From the StreamWriter class");
                ////Close the file
                //sw.Close();

                using (XmlWriter writer =  XmlWriter.Create("E:\\Test.txt", settings))
                {
                    DataContractSerializer serializer = new DataContractSerializer(all.GetType());
                    serializer.WriteObject(writer, all);

                    writer.Close();                    

                    return View();
                }
            }
        }

        public FileResult Download(int id)
        {
            var caminhoDaImagem = "E:\\Test.txt";
            byte[] dadosArquivo = System.IO.File.ReadAllBytes(caminhoDaImagem);
            return File(dadosArquivo, System.Net.Mime.MediaTypeNames.Image.Jpeg, "meuarquivo.txt");
        }


    }
}
