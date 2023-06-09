namespace pruebaTecnica.Models
{
    //modelo que hace la simulacion de tener una mochila con elementos para escalar
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
        //limpia los elementos de la mochila, es como sacar todos los elementos de la mochila
        public void limpiar()
        {
            Elements.Clear();
        }
        public void eliminarElemento(Element e)
        {
            Elements.Remove(e);
            //Se quita el peso y la calorias del elemento quitado tambien podria ser tener peso y calorias como metodo que se calculen con los elementos de la mochila para no tener que quitarlos de esta manera
            this.Peso = this.Peso - e.Peso;
            this.Calorias -= e.Calorias;
        }
        //verifica si ese elemento ya esta dentro de la mochila, para eso cada elemento debe tener un identificador unico, para simular la existencia unica del elemento y no repetir valores
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
