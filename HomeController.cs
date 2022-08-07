using HtmlToPdfDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlToPdfDemo.Controllers
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

     public FileResult GeneratePdf(string html)
        {
            html = html.Replace("strtTag", "<").Replace("EndTag", ">");
            HtmlToPdf objhtml = new HtmlToPdf();
            PdfDocument objdoc = objhtml.ConvertHtmlString(html);
            byte[] pdf = objdoc.Save();
            objdoc.Close();
            return File(pdf,"application/pdf","HtmlContent.pdf");
        }
    }
}
