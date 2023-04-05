using Microsoft.AspNetCore.Mvc;
using MyDemosMVC.Models;
using System.Diagnostics;

namespace MyDemosMVC.Controllers
{
    //sobrecarga de rotas
    [Route("")] //ao definir uma rota vazia há conflito com a rota de erro.
    [Route("gestao-clientes")] //altera a rota base para dominio/gestao-clientes
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        [Route("home")]//acrescenta o endereço na rota base: dominio/gestao-clientes/home
        [Route("home/{id:guid}/{categoria:int?}")] //determina os tipos dos parametros necessario na rota


        public IActionResult Index(Guid id, int categoria)
        {
            var filme = new Filme
            {
                Titulo = "Te",
                DataLancamento = DateTime.Now,
                Genero = "Action",
                Valor = 10000,
                Avaliacao = 10
            };
            return RedirectToAction("Privacy", filme); //redireciona a var filme para a acttion privacy
            //return View();
        }

        [Route("privacidade")]//acrescenta o endereço na rota base: dominio/gestao-clientes/privacidade
        [Route("politica-de-privacidade")]
        public IActionResult Privacy(Filme filme)
        {
            if (ModelState.IsValid) //verifica se o model é valido
            {

            }

            foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
            
            {
                Console.WriteLine(error.ErrorMessage); //recupera os erros caso algum dado nao esteja de acordo com o especificado na model      
            }

            return View();
            //retornando um arquivo JSON
            //return Json("{'Nome':'Marcos'}");

            //retornando um conteudo
            //return Content("Conteudo aleatorio");

            //retornando um arquivo txt
            /*var fileBytes = System.IO.File.ReadAllBytes(@"d:\arquivo.txt"); //selecionando arquivo no local fisico
            var fileName = "ola.txt"; //dando nome do arquivo quando for baixado
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);*/ //retorna o arquivo e o nome que ele tera.
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}