using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArtApi.Domain;
using ArtApi.Infraestructure;

/*
Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre de la actividad: Actividad 2 (Resistencias)
Nombre del alumno: Pricila Abigail Bentancourt Lopez 
Cuatrimestre: 4
Grupo: C
Parcial: 2
*/

namespace ArtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll(){
            var repository = new ColorRepository();
            var colorines = repository.GetAll();
            return Ok(colorines);
        }
        [HttpGet]
        [Route("Calculo/{color1}/{color2}/{color3}/{color4}")]
        public IActionResult Calculo(string color1, string color2, string color3, string color4){
            var Mensaje = "";
            var Tole = "";
            var repository = new ColorRepository();
            var validacion = repository.ObtenerOhms(color1, color2, color3, color4);
            //Validaciones por banda
            if (validacion == -100){
                Mensaje = ($"El primer color ingresado: {color1} es incorrecto.");
                return Ok(Mensaje);
            }
            else if (validacion == -200){
                Mensaje = ($"El segundo color ingresado: {color2} es incorrecto.");
                return Ok(Mensaje);
            }
            else if (validacion == -300){
                Mensaje = ($"El tercer color ingresado: {color3} es incorrecto. Asegurate de poner colores diferentes a violeta, blanco y gris.");
                return Ok(Mensaje);
            }
            else if (validacion == -400){
                Mensaje = ($"El cuarto color ingresado: {color4} es incorrecto. Asegurate de usar el color dorado o plata");
                return Ok(Mensaje);
            }
            
            if (color4.ToLower() == "dorado"){
                Tole = "5%";
            }
            else {
                Tole = "10%";
            }
            var MensajeFinal = ($"El valor es de: {validacion}  y tiene una resistencia del {Tole}");
            return Ok(MensajeFinal);
            
        }
        
        
    }
}