using AuthPrestamos.Areas.Identity.Data;
using AuthPrestamos.Data;
using AuthPrestamos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthPrestamos.Controllers
{
    public class UsuarioPrestamoController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private readonly APrestamosContext _context;

        //constructor 
        public UsuarioPrestamoController(UserManager<ApplicationUser> userManager,APrestamosContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        //retorna vista de prestamos
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var age = (DateTime.Now - currentUser.FechaNacimientoUser).TotalDays / 360;

            List<int > amountsValid = new List<int>() { 1000, 2000, 3000};

            if (age > 30 && age < 50) {
                amountsValid.Add(4000);
                amountsValid.Add(5000);
            }

            ViewBag.AmountsValid = amountsValid;
  
            return View();
        }

        //http post Create un nuevo prestamo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync( Prestamo prestamo)
        {
            //validar edad del usuario activo 
            var user = await _userManager.GetUserAsync(User);
            var fechaNacimiento = user.FechaNacimientoUser;
          
            Console.Write($"fecha es  { fechaNacimiento} ");
            //fecha actual 
            DateTime now = DateTime.Today;
             
            //validacion lado servidor 
            if (ModelState.IsValid)
            { 
                _context.Prestamo.Add(prestamo);
                _context.SaveChanges();

                //use de TempData enviar un mensaje --obtenerlo en index
                TempData["mensaje"] = "Prestamo Autorizado...";
                return RedirectToAction("Index");
            }
            return View();
        }
         

        //retorna vista para solicitar un prestamo 
        public IActionResult Prestamos()
        {
            return View();
        }

        //vista que mostrara el saldo y el abono que deseara abonar
        public IActionResult Abonar()
        {
            


            return View();
        }


        //Mostrara el historial de pagos
        public IActionResult Movimientos()
        {
            return View();
        }


    }
}
