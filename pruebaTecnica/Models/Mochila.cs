namespace pruebaTecnica.Models
{
    public class Mochila
    {
        public int PesoMaximo { get; set; }
        public int CaloriaMinima { get; set; }
        public List<Element>Elements { get; set; }
        public int Calorias { get; set; }
        public int Peso { get; set; }
        
        public Mochila(int pesoMaximo,int caloriaMinima)
        {
            this.PesoMaximo = pesoMaximo;
            this.CaloriaMinima = caloriaMinima;
            this.Elements = new List<Element>();
            Peso = 0;
            Calorias = 0;
        }
        public void añadirElemento(Element e)
        {
            Elements.Add(e);
            this.Peso = this.Peso + e.Peso;
            this.Calorias += e.Calorias;
        }
        public void limpiar()
        {
            Elements.Clear();
        }
        public void eliminarElemento(Element e)
        {
            Elements.Remove(e);
            this.Peso = this.Peso - e.Peso;
            this.Calorias -= e.Calorias;
        }
        public bool existeElemento(Element e)
        {
            bool verdadero = false;
            foreach (Element element in Elements)
            {
                if (element.Id == e.Id)
                {
                    verdadero = true;
                }
                
            }
            return verdadero;
        }
    }
}
