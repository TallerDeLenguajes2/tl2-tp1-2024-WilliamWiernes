namespace EspacioClases
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;

        public Cadeteria()
        {
            listaCadetes = new List<Cadete>();
        }

        public List<Cadete> VerLista
        {
            get { return listaCadetes; }
        }

        public string VerDatos
        {
            get { return $"{nombre} | {telefono}"; }
        }

        public void CargarDatosCadeteriaCSV(string nombreArchivo)
        {
            var arregloCadeteria = File.ReadAllText(nombreArchivo).Split(",");

            nombre = arregloCadeteria[0];
            telefono = arregloCadeteria[1];
        }

        public void CargarDatosCadetesCSV(string nombreArchivo)
        {
            var arregloLineas = File.ReadAllLines(nombreArchivo);

            foreach (var linea in arregloLineas)
            {
                var arregloCadete = linea.Split(",");

                var cadete = new Cadete(int.Parse(arregloCadete[0]), arregloCadete[1], arregloCadete[2], arregloCadete[3]);

                listaCadetes.Add(cadete);
            }
        }
    }
}