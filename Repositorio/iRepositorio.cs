
namespace C_23052025_RUD.Repositorio
 
{
    public interface iRepositorio <t> where t : class
    {
        List<t> Obtenertodos();
        t? BuscarPorId(int id);
        void Agregar(t? entidad);
        void Editar(t? entidad);
        void EliminarPorId(int id);

    }
}
