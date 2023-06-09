using pruebaTecnica.Models;
using System.ComponentModel;

namespace pruebaTecnica.Utilidades
{
    public class Recursividad
    {
        List<Element> elements = new List<Element>()
        {
            new Element(1,"E1",5,3),
            new Element(2,"E2",3,5),
            new Element(3,"E3",5,2),
            new Element(4,"E4",1,8),
            new Element(5,"E5",2,3),
            new Element(6,"E8",1,9),
        };
        Mochila mochila = new Mochila(10, 15);
        Mochila optima = new Mochila(10,15);
        
        bool primeravez = true;
        public void llenarMochila(List<Element>elements,Mochila mochila,bool lleno, Mochila mochilaOptima)
        {
            if (lleno)
            {


                if (mochila.Calorias > mochilaOptima.Calorias && (mochila.Peso <= mochilaOptima.Peso) && (mochilaOptima.Peso > -1))
                {
                    mochilaOptima.limpiar();
                    mochilaOptima.Elements = new List<Element>(mochila.Elements);
                    mochilaOptima.Calorias = mochila.Calorias;
                    mochilaOptima.Peso = mochila.Peso;
                }
                else if(mochilaOptima.Peso == -1 && mochila.Calorias>= mochila.CaloriaMinima && mochila.Peso<= mochila.PesoMaximo)
                {
                    mochilaOptima.limpiar();
                    mochilaOptima.Elements = new List<Element>(mochila.Elements);
                    mochilaOptima.Calorias = mochila.Calorias;
                    mochilaOptima.Peso = mochila.Peso;
                }

            }
            else
            {
                foreach (Element element in elements)
                {
                    if (mochila.existeElemento(element)==false)
                    {
                        if (mochila.PesoMaximo >= mochila.Peso + element.Peso)
                        {
                            mochila.añadirElemento(element);
                            llenarMochila(elements, mochila, false,mochilaOptima);
                            mochila.eliminarElemento(element);
                        }
                        else
                        {
                            llenarMochila(elements, mochila, true, mochilaOptima);
                        }
                    }
                   
                }
            }
          
        }
        public void main()
        {
           optima.Peso = -1;
           llenarMochila(elements,mochila, false,optima);
            var a = optima;
        }
    }
}
