using Comparador.Entidad;

namespace Comparador.ServicioLocal
{

    public interface IComparadorServicio
    {
        List<Comparador.Entidad.Comparador> ObtenerComparaciones();
        void AgregarComparacion(Comparador.Entidad.Comparador comparacion);
    }

    public class ComparadorServicio : IComparadorServicio
    {
        private List<Comparador.Entidad.Comparador> _comparador;
        public ComparadorServicio()
        {
            _comparador = new List<Comparador.Entidad.Comparador>();
        }

        public List<Comparador.Entidad.Comparador> ObtenerComparaciones()
        {
            return _comparador;
        }

        public void AgregarComparacion(Comparador.Entidad.Comparador comparacion)
        {
            _comparador.Add(comparacion);
        }

    }
}
