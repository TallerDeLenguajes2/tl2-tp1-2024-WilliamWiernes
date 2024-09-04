namespace EspacioClases
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cadete() { }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public string VerDatos
        {
            get { return $"{id} | {nombre} | {direccion} | {telefono}"; }
        }

        public int VerId
        {
            get { return id; }
            set { id = value; }
        }

        public string VerNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string VerDireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string VerTelefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}