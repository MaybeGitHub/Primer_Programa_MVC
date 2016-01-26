using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {

        // En todos los campos indicamos que son requeridos y que si se dejan vacios, saque el mensaje indicado, ¿ donde lo saca ? si venimos de la vista RsvpForm, sabremos que hay un metodo @Html.ValidationSummary()
        // que recoge estos mensajes y los muestra en formato lista <ul><li>...</li></ul> con todos los errores que hayan dado de los atributos. En el caso del Email, ademas de comprobar que no esta vacio le indicamos
        // que tiene que comprobar tambien que se cumple esa expresion regular.

        [Required(ErrorMessage = "Please enter your name")]   
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please specify whether you'll attend")]
        public bool? WillAttend { get; set; } // Aqui si nos fijamos vemos que el bool tiene una ? al final, esto se usa para indicar que ademas de True o False, tambien puede ser Null ( en caso de no seleccionar nada en el dropDown )
    }
}