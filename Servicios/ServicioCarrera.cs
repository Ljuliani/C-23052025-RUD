using System.Text.Json;
using System.IO;
using C_23052025_RUD.Models;

namespace C_23052025_RUD.Servicios
{
    public static class ServicioCarrera
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
    }
}
