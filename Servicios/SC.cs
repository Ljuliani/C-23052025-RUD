using System.Text.Json;
using System.IO;
using C_23052025_RUD.Models;

namespace C_23052025_RUD.Servicios
{
    public static class Sc// ServicioCarrera
    {
        private static string ruta = "Data/carreras.json";
        public static string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]"; // Retorna un JSON vacío si el archivo no existe
        }


        public static List<Carrera> ObtenerCarreras()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<Carrera>>(json);
            return lista ?? new List<Carrera>();

        }

        private static Carrera? BuscarCarreraPorId(List<Carrera> lista, int id)
        {
            foreach (var carrera in lista)
            {
                if (carrera.Id == id)
                {
                    return carrera;
                }
            }
            return null; // Retorna null si no se encuentra la carrera con el ID especificado
        }


        public static void AgregarCarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarreras();
            nuevaCarrera.Id = ObtenerNuevoId(carreras);
            carreras.Add(nuevaCarrera);
            GuardarCarreras(carreras);

        }
        public static int ObtenerNuevoId(List<Carrera> Carreras)
        {
            int maxId = 0;
            foreach (var carrera in Carreras)
            {
                if (carrera.Id > maxId)
                {
                    maxId = carrera.Id;
                }
            }
            return maxId + 1;
        }
        public static void GuardarCarreras(List<Carrera> carreras)
        {
            string textoJson = JsonSerializer.Serialize(carreras);
            File.WriteAllText(ruta, textoJson);
        }
        public static Carrera? BuscarPorId(int id)
        {
            var lista = ObtenerCarreras();
            return BuscarCarreraPorId(lista, id);
        }
        public static void EliminarPorId(int id)
        {
            var lista = ObtenerCarreras();
            var carreraAEliminar = BuscarCarreraPorId(lista, id);
            if (carreraAEliminar != null)
            {
                lista.Remove(carreraAEliminar);
                GuardarCarreras(lista);
            }
        }
        public static void EditarCarrera(Carrera carreraEditada)
        {
            var lista = ObtenerCarreras();
            var carrera = BuscarCarreraPorId(lista, carreraEditada.Id);
             if (carrera != null)
             {
               carrera.Nombre = carreraEditada.Nombre;
               carrera.Modalidad = carreraEditada.Modalidad;
               carrera.Duracionaños = carreraEditada.Duracionaños;
               carrera.Titulootorgado = carreraEditada.Titulootorgado;
               GuardarCarreras(lista);
            }

        }
    }
}