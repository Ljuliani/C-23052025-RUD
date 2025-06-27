using C_23052025_RUD.Models;
using System.Text.Json;

namespace C_23052025_RUD.Servicios
//Metodos reflectivos, (metodos SetValue, GetProperty, getValue, typeof) para obtener el Id de la entidad y asignarle un nuevo Id.
{
    public class RepositorioCrudJson<t> where t : class
    {
        private string ruta;
        public RepositorioCrudJson(string nombreArchivo)
        {
            ruta = $"data/{nombreArchivo}.json";
        }
        public string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]"; // Retorna un JSON vacío si el archivo no existe
        }
        public List<t> ObtenerTodos()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<t>>(json);
            return lista ?? new List<t>();

        }
        public void Guardar(List<t> lista)
        {
            string textoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(ruta, textoJson);
        }

        //Métodos con reflexion.
        public int ObtenerNuevoId(List<t> lista)
        {
            int maxid = 0;
            foreach (var item in lista)
            {
                var propiedadId = typeof(t).GetProperty("Id");
                int id = (int)propiedadId.GetValue(item);

                if (id > maxid)
                {
                    maxid = id;
                }
            }
            return maxid + 1;
        }
        public void Agregar(t entidad)
        {
            var lista = ObtenerTodos();
            int nuevoId = ObtenerNuevoId(lista);
            //nuevaCarrera.Id = ObtenerNuevoId(entidad);
            var propiedadId = typeof(t).GetProperty("Id");
            propiedadId.SetValue(entidad, nuevoId);
            lista.Add(entidad);
            Guardar(lista);

        }
        private t? BuscarEnListaPorId(List<t> lista, int id)
        {
            var propiedadId = typeof(t).GetProperty("Id");
            foreach (var item in lista)
            {
                int valorId = (int)propiedadId.GetValue(item);
                if (valorId == id)
                {
                    return item;
                }
            }
            return null; // Retorna null si no se encuentra la carrera con el ID especificado
        }
        public t? BuscarPorId(int id)
        {
            var lista = ObtenerTodos();
            return BuscarEnListaPorId(lista, id);
        }
        public void EliminarPorId(int id)
        {
            var lista = ObtenerTodos();
            var itemEliminar = BuscarEnListaPorId(lista, id);
            if (itemEliminar != null)
            {
                lista.Remove(itemEliminar);
                Guardar(lista);
            }
        }
        public void Editar(t entidadNueva)
        {
            var lista = ObtenerTodos();
            var propiedadId = typeof(t).GetProperty("Id");
            int id = (int)propiedadId.GetValue(entidadNueva);
            var entidadExistente = BuscarEnListaPorId(lista, id);


            if (entidadExistente != null)
            {
                ActualizarPropiedades(entidadExistente, entidadNueva);
                Guardar(lista);
            }

        }
        private void ActualizarPropiedades(t entidadExistente, t entidadNueva)
        {
            var propiedades = typeof(t).GetProperties();
            foreach (var propiedad in propiedades)
            {
                if (propiedad.Name == "Id") continue; // No actualizar el Id
                var nuevoValor = propiedad.GetValue(entidadNueva);
                propiedad.SetValue(entidadExistente, nuevoValor);

            }
        }





    }
}
