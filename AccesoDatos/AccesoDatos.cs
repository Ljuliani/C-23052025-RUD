using System.Text.Json;


namespace C_23052025_RUD.AccesoDatos
{
    public class AccesoDatos<t> : iAccesoDatos<t>
    {
        private string ruta;
        public AccesoDatos(string nombreArchivo)
        {
            ruta = $"Data/{nombreArchivo}.json";
        }
        private string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]"; // Retorna un JSON vacío si el archivo no existe
        }
        public List <t> Leer()
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
    }
}
