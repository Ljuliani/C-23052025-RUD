using C_23052025_RUD.Models;

namespace C_23052025_RUD.Servicios
{
    public class ServicioAlumno
    {
        private readonly RepositorioCrudJson<Alumno> crud;
        public ServicioAlumno()
        {
            crud = new RepositorioCrudJson<Alumno>("alumnos");
        }
        public List<Alumno> Obtenertodos()
        {
            return crud.ObtenerTodos();
        }
        public Alumno? BuscarPorId(int id)
        {
            return crud.BuscarPorId(id);
        }
        public void Editar(Alumno alumno)
        {
            crud.Editar(alumno);
        }
        public void EliminarPorId(int id)
        {
            crud.EliminarPorId(id);
        }
        public void Agregar(Alumno alumno)
        {
            crud.Agregar(alumno);
        }
    }
}