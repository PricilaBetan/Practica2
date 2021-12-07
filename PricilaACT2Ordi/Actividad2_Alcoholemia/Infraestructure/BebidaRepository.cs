using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using AlcoholemiaApi.Domain;

namespace AlcoholemiaApi.Infraestructure
{
    public class BebidaRepository
    {
        List<Bebidas> _bebidas;
        public BebidaRepository()
        {
            var fileName = "dummy.data.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _bebidas = JsonSerializer.Deserialize<IEnumerable<Bebidas>>(json).ToList();
            }
        }

        public IEnumerable<Bebidas> GetAll()
        {
            var query = _bebidas.Select(be => be);
            return query;
        }
        public double ObtenerMililitros(string nombre, int cantidad, int peso)
        {
            var obtener = _bebidas.FirstOrDefault(be => be.Nombre == nombre.ToLower());
            double Alcoholemia;

            if(obtener == null){ 
                Alcoholemia = -100; 
            }
            else{
                double TotalAlcohol = obtener.Mililitros*cantidad;
                double PorCerveza = obtener.Grado*TotalAlcohol;
                double DirectoSangre = 0.15*PorCerveza;
                double Etanol = 0.789*DirectoSangre;
                double VolumenPeso = 0.08*peso;
                Alcoholemia = Etanol/VolumenPeso;
            }
            
            
            return Alcoholemia;
        }
        

    }
}