using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RandomPasscode.Controllers 
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("main")]
        public IActionResult Main(string passcode)
        {
            int? num = HttpContext.Session.GetInt32("num");
            if (num == null)
            {
                num = 0;
                HttpContext.Session.SetInt32("num", 0);
            }
            HttpContext.Session.SetInt32("num", (int)num);
            ViewBag.Count = num;
            ViewBag.Passcode = passcode;
            return View();
        }
        [HttpPost]
        [Route("randomize")]
        public IActionResult Randomize()
        {
            
            Random rand = new Random();
            string[] pool = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9"};
            string randomPasscode = "";
            string[] Char = new string[14];
            for (int i = 0; i < Char.Length; i++)
            {
                Char[i] = pool[rand.Next(0, pool.Length)];
            }
            foreach (string ii in Char)
            {
                randomPasscode += ii;
            }
            
            int? num = HttpContext.Session.GetInt32("num");
            num ++;
            HttpContext.Session.SetInt32("num", (int)num);
            return RedirectToAction("Main", new {passcode = randomPasscode});
        }
    }
}