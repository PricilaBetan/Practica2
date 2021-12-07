using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlcoholemiaApi.Infraestructure;
using AlcoholemiaApi.Domain;

/*
Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre de la actividad: Actividad 3 (Alcoholemia)
Nombre del alumno: Pricila Abigail Betancourt
Cuatrimestre: 4
Grupo: C
Parcial: 2
*/

namespace AlcoholemiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlcoholemiaController : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new BebidaRepository();
            var drinks = repository.GetAll();
            return Ok(drinks);
        }
        
        [HttpGet]

        [Route("ExamenAlcoholemia/{nombre}/{cantidad}/{peso}")]
        public IActionResult TestAlcoholemia(string nombre, int cantidad, int peso)
        {
            var Mensaje = "";
            var repository = new BebidaRepository();
            var validacion = repository.ObtenerMililitros(nombre, cantidad, peso);
            if (validacion == -100){
                Mensaje = ($"La bebida ingresada {nombre} es incorrecta.");
            }
            else if(validacion > 0.8){
                Mensaje = ($"Tiene una cantidad de alcohol en la sangre de {validacion.ToString("##,##0.0000")},sr conductor usted no puede manejar ");
            }
            else{
                Mensaje = ($"Tenga un excelente viaje!");
            }
            return Ok(Mensaje);
        }
    }
}