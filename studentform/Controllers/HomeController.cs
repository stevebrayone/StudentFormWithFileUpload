using Microsoft.AspNetCore.Mvc;
using studentform.Models;
using System.Diagnostics;


namespace studentform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Student student, List<IFormFile> myfile)
        {
            var return_page = "Index";
            if (ModelState.IsValid)
            {
                if (myfile.Count == 0)
                {
                    ViewBag.UploadStatus = "no file selected";
                }

                try
                {
                    if (myfile.Count > 0)
                    {
                        ViewBag.UploadStatus += myfile.Count.ToString() + "";
                        foreach (var file in myfile)
                        {
                            string file_name = file.FileName;
                            file_name = Path.GetFileName(file_name);
                            string upload_folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploads");

                            if (!Directory.Exists(upload_folder))

                            {
                                Directory.CreateDirectory(upload_folder);
                            }
                            string upload_path = Path.Combine(upload_folder, file_name);
                            if (System.IO.File.Exists(upload_path))
                            {
                                ViewBag.UploadStatus += file_name + "-Already Exists";
                                Random file_number = new Random();
                                file_name = file_number.Next(10000).ToString() + file_name;
                                upload_path = Path.Combine(upload_folder, file_name);
                            }
                            else
                            {
                                ViewBag.UploadStatus += file.FileName + " Uploaded successfully\n";
                            }
                            var uploadsteam = new FileStream(upload_path, FileMode.Create);
                            file.CopyToAsync(uploadsteam);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.UploadStatus += $"Unable to upload file{ex.Message}";
                }
                ViewBag.finalcontent=student.Name;
                ViewBag.Success = "Successfully Registered";
                return_page = "Success";
            }
            return View(return_page);
        }
        public ActionResult Upload()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}