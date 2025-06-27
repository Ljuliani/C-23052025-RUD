using C_23052025_RUD.Models;

namespace C_23052025_RUD.Servicios
{
    public class ServicioCarrera
    {
        private readonly RepositorioCrudJson<Carrera> crud;
        public ServicioCarrera()
        {
          crud = new RepositorioCrudJson<Carrera>("carreras");
        }
        public List<Carrera> Obtenertodos()
        {
            return crud.ObtenerTodos();
        }
        public Carrera? BuscarPorId(int id)
        {
            return crud.BuscarPorId(id);
        }
        public void Editar(Carrera carrera)
        {
            crud.Editar(carrera);
        }
        public void EliminarPorId(int id)
        {
            crud.EliminarPorId(id);
        }
        public void Agregar(Carrera carrera)
        {
            crud.Agregar(carrera);
        }

    }
}
