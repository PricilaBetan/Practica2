using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholemiaApi.Domain
{
    public record Bebidas(int idBebida, string Nombre, double Mililitros, double Grado);
}