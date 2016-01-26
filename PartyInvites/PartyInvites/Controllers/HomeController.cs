using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home   Pagina principal que introduce en el Objeto ViewBag un atributo Greeting creado por nosotros ( ese atributo no existe hasta que no se lo indicamos ) al que le mete un String diferente dependiendo de la hora del dia
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();  // Carga la pagina Index.cshtml
        }
        
        [HttpGet] // Indicamos que este metodo se ejecutara cuando se realice una peticion a este controlador y a la vista RsvpForm usando el metodo Get
        public ViewResult RsvpForm()
        {
            return View(); // Carga la pagina RsvpForm.cshtml 
        }

        [HttpPost] // Si el cliente en vez de pedir la pagina RsvpForm con el metodo Get, lo pide por Post ( metodo por defecto de los HTML.BeginForm() ) entrara por aqui en vez de por arriba
        public ViewResult RsvpForm(GuestResponse guest) // Indicamos que cuando llamemos a esta View usando este controlador, pasaremos un Modelo GuestResponse ( que si recordamos era el que bindeabamos para rellenar en la View )
        {
            // Aqui deberia ir el metodo de mandar Email que tenemos escrito en la pagina Thanks.cshtml
            if (ModelState.IsValid) // Esta sentencia recoge el estado de todos los atributos con campo Required del modelo GuestResponse que, al bindear usando la View, ya saben si validan o no, y este metodo los comprueba siendo True en caso de que todas las validaciones sean correctas.
            {
                return View("Thanks", guest); // Cargamos la pagina Thanks ( si queremos cargar una pagina en concreto, le pasamos un String con el nombre sin extension al View ) y le damos el modelo que lo recibe como Object la View 
                                              // ( si nos fijamos en thanks indicamos con @model que el modelo que le pasamos es GuestResponse, para entendernos, es como si al entrar en la View, 
                                              // la propia View le hiciera un Cast para poder trabajar con el modelo GuestResponse mediante la clase Model sin tener que hacerselo nosotros )
            }                                 
            else
            {
                return View();
            }
            
        }
    }
}