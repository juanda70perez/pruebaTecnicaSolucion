namespace pruebaTecnica.Models
{
    public class Element
    {
        public Element() { 
        }
        public Element(int id, string nombre, int peso, int calorias)
        {
            Id = id;
            Nombre = nombre;
            Peso = peso;
            Calorias = calorias;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Peso { get; set; }
        public int Calorias { get; set; }

    }
}
