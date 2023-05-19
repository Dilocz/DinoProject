using DinoProject.Models.Repositories;
using DinoProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DinoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDinoRepository _dinoRepository;
        private readonly IWhenRepository _whenRepository;

        public HomeController(
            IDinoRepository dinoRepository,
            IWhenRepository whenRepository
            )
        {
            _dinoRepository = dinoRepository;
            _whenRepository = whenRepository;
        }
        public IActionResult Index()
        {
            ViewData["dinos"] = _dinoRepository.FindAll();

            return View("Views/Home/Index.cshtml");
        }
        public IActionResult Form()
        {
            ViewData["whens"] = _whenRepository.FindAll();

            return View("Views/Home/DinoForm.cshtml");
        }
        public IActionResult AddDina()
        {
            var name = (string)Request.Form["name"];
            var description = (string)Request.Form["popis"];
            var whenId = Convert.ToInt32(Request.Form["when"]);
            var when = _whenRepository.FindById(whenId);
            if (Request.Form.Files.Count > 0 && Request.Form.Files[0] != null)
            {
                var file = Request.Form.Files[0];
                var uploadPath = Path.GetRelativePath(".", "wwwroot/img/" + file.FileName);
                using (var stream = System.IO.File.Create(uploadPath))
                {
                    file.CopyTo(stream);
                }
                _dinoRepository.AddDina(name, file.FileName, description, when);
            } else
            {
                var file = "default.jpg";
                _dinoRepository.AddDina(name, file, description, when);
            }
            return new RedirectToRouteResult(new { controller = "Home", action = "Index" });
        }
        public IActionResult Del(int id, string photo)
        {
            var movie = _dinoRepository.FindById(id);

            if (movie != null)
            {
                if(photo != "default.jpg")
                {
                    var uploadPath = Path.GetRelativePath(".", "wwwroot/img/" + photo);
                    System.IO.File.Delete(uploadPath);
                }
                _dinoRepository.Del(movie);
            }

            return new RedirectToRouteResult(new { controller = "Home", action = "Index" });
        }
        //--EDIT--\\
        public IActionResult Edit(int id)
        {
            ViewData["dinos"] = _dinoRepository.FindById(id);
            ViewData["whens"] = _whenRepository.FindAll();

            return View("Views/Home/EditDana.cshtml");
        }
        public IActionResult EditDina(int id)
        {
            var name = (string)Request.Form["name"];
            var description = (string)Request.Form["popis"];
            var whenId = Convert.ToInt32(Request.Form["when"]);
            var when = _whenRepository.FindById(whenId);
            var dino = _dinoRepository.FindById(id);
            string Filee = null;
            if (Request.Form.Files.Count > 0 && Request.Form.Files[0] != null)
            {
                var photo = dino.Photo;
                if (photo != "default.jpg")
                {
                    var uploadPath1 = Path.GetRelativePath(".", "wwwroot/img/" + photo);
                    System.IO.File.Delete(uploadPath1);
                }
                var file = Request.Form.Files[0];
                var uploadPath = Path.GetRelativePath(".", "wwwroot/img/" + file.FileName);
                using (var stream = System.IO.File.Create(uploadPath))
                {
                    file.CopyTo(stream);
                }
                Filee = file.FileName;
            }
            dino.Name = name;
            dino.Description = description;
            dino.When = when;
            if (Filee != null)
            {
                dino.Photo = Filee;
            }

            _dinoRepository.Edit(dino);

            return new RedirectToRouteResult(new { controller = "Home", action = "Index" });
        }

    }
}