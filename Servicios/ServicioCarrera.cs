using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;

namespace C_23052025_RUD.Servicios
{
    public class ServicioCarrera
    {
        private readonly iRepositorio<Carrera> _repo;
        public ServicioCarrera(iRepositorio<Carrera> repo)
        {
            _repo = repo;
        }
        public List<Carrera> Obtenertodos()
        {
            return _repo.Obtenertodos();
        }
        public Carrera? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Editar(Carrera carrera)
        {
            _repo.Editar(carrera);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }
        public void Agregar(Carrera carrera)
        {
            _repo.Agregar(carrera);
        }

    }
}
