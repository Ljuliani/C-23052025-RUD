using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;

namespace C_23052025_RUD.Servicios
{
    public class ServicioAlumno
    {
        private readonly iRepositorio<Alumno> _repo;
        public ServicioAlumno(iRepositorio<Alumno> repo)
        {
            _repo = repo;
        }
        public List<Alumno> Obtenertodos()
        {
            return _repo.Obtenertodos();
        }
        public Alumno? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Editar(Alumno alumno)
        {
            _repo.Editar(alumno);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }
        public void Agregar(Alumno alumno)
        {
            _repo.Agregar(alumno);
        }
        public  bool CDD(int dni,int id)
        {
            return Obtenertodos().Any(alumno => alumno.Dni == dni && alumno.Dni > 0 && alumno.Id != id);
        }

    }
}