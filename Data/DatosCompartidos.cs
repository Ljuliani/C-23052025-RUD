using C_23052025_RUD.Models;

namespace C_23052025_RUD.Data
{
    public class DatosCompartidos
    {
        public static List<Carrera> Carreras { get; set; } = new();
        public static List<Alumno> Alumnos { get; set; } = new();
        private static int ultimoId = 0;
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


        public static int ObtenerNuevoId(List<Alumno> Alumnos)
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

    }


}
