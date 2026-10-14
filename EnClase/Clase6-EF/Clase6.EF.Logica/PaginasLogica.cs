using Clase6.EF.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6.EF.Logica
{
    public interface IPaginasLogica
    {

        List<string> Dividir(string texto, int caracteresPorPagina = 2000);
    }

    public class PaginasLogica : IPaginasLogica
    {
        public List<string> Dividir(string texto, int caracteresPorPagina = 2000)
        {
            var paginas = new List<string>();
            int inicio = 0;

            while (inicio < texto.Length)
            {
                int largo = Math.Min(caracteresPorPagina, texto.Length - inicio);

                if (inicio + largo < texto.Length)
                {
                    int corte = texto.LastIndexOfAny(new[] { ' ', '\n' }, inicio + largo - 1, largo);
                    if (corte > inicio) largo = corte - inicio;
                }

                paginas.Add(texto.Substring(inicio, largo).Trim());
                inicio += largo;
            }

            return paginas;
        }
    }
}
