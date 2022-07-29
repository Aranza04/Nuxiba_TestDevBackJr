using Microsoft.AspNetCore.Mvc;
using Prueba_T2.Data;
using Prueba_T2.Models;

namespace Prueba_T2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly bd_pruebaContext _context;

        public UsuarioController(bd_pruebaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _context.TopTen().ToList();
            return View(usuarios);
        }

        public IActionResult TopTen()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        [HttpPost]
        public IActionResult EditUser(int idUsuario)
        {
            List<Empleado> empleado = _context.ConsultaEmpleadoUnico(idUsuario).ToList();
            return View(empleado);
        }

        [HttpPost]
        public IActionResult EditUserSalario(string salario, int idEmpleado)
        {
            double newSalario = Convert.ToDouble(salario);
            _context.EditSalario(newSalario, idEmpleado);

            return View();
        }
    }
}
