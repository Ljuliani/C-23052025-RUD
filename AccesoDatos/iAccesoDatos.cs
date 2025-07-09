namespace C_23052025_RUD.AccesoDatos
{
    public interface iAccesoDatos <t>
    {
        List<t> Leer();
        void Guardar(List<t> lista);
    }
}
