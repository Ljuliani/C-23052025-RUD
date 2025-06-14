using C_23052025_RUD.Models;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;


namespace C_23052025_RUD.Servicios
{
    public class ServicioAlumno
    {
            private static string ruta = "Data/alumnos.json";
            public static string LeerTextoDelArchivo()
            {
                if (File.Exists(ruta))
                {
                    return File.ReadAllText(ruta);
                }
                return "[]"; // Retorna un JSON vacío si el archivo no existe
            }
            public static List<Alumno> ObtenerAlumnos()
            {
                string json = LeerTextoDelArchivo();
                var lista = JsonSerializer.Deserialize<List<Alumno>>(json);
                return lista ?? new List<Alumno>();

            }

            private static Alumno? BuscarAlumnosPorId(List<Alumno> lista, int id)
            {
                foreach (var alumno in lista)
                {
                    if (alumno.Id == id)
                    {
                        return alumno;
                    }
                }
                return null; // Retorna null si no se encuentra la carrera con el ID especificado
            }


        public static void AgregarAlumno(Alumno nuevoAlumno)
        {
            if (CDD(nuevoAlumno.Dni))
            {

                return;
                
            }

            var alumnos = ObtenerAlumnos();
            nuevoAlumno.Id = ObtenerNuevoId(alumnos);
            alumnos.Add(nuevoAlumno);
            GuardarAlumnos(alumnos);
        }

        public static int ObtenerNuevoId(List<Alumno> alumnos)
            {
                int maxId = 0;
                foreach (var alumno in alumnos)
                {
                    if (alumno.Id > maxId)
                    {
                        maxId = alumno.Id;
                    }
                }
                return maxId + 1;
            }
            public static void GuardarAlumnos(List<Alumno> alumnos)
            {
                string textoJson = JsonSerializer.Serialize(alumnos);
                File.WriteAllText(ruta, textoJson);
            }
            public static Alumno? BuscarPorId(int id)
            {
                var lista = ObtenerAlumnos();
                return BuscarAlumnosPorId(lista, id);
            }
            public static void EliminarPorId(int id)
            {
                var lista = ObtenerAlumnos();
                var alumnoAEliminar = BuscarAlumnosPorId(lista, id);
                if (alumnoAEliminar != null)
                {
                    lista.Remove(alumnoAEliminar);
                    GuardarAlumnos(lista);
                }
            }
            public static void EditarAlumno(Alumno alumnoEditado)
            {
                var lista = ObtenerAlumnos();
                var alumno = BuscarAlumnosPorId(lista, alumnoEditado.Id);
                if (alumno != null)
                {
                 alumno.Nombre = alumnoEditado.Nombre;
                 alumno.Apellido = alumnoEditado.Apellido;
                 alumno.Fn = alumnoEditado.Fn;
                 alumno.Ce = alumnoEditado.Ce;
                 alumno.Dni = alumnoEditado.Dni;
                 GuardarAlumnos(lista);
                }

            }
        public static bool CDD(int dni)
        {
            return ObtenerAlumnos().Any(alumno => alumno.Dni == dni && alumno.Dni > 0);
        }
    }
}

            






