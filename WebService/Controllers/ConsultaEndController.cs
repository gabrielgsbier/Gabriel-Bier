using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebService.Models;

//Gabriel Giuseppe Sahina Bier 1726478

namespace WebService.Controllers
{
    public class ConsultaEndController : Controller
    {
        private readonly Context _context;
        public ConsultaEndController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ConsultaEnd.ToList());
        }

        public IActionResult ConsultaEnd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConsultaEnd(string cep)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/" + cep + "/json/");
            ConsultaEnd cidade = JsonConvert.DeserializeObject<ConsultaEnd>(json);

            _context.Add(cidade);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}