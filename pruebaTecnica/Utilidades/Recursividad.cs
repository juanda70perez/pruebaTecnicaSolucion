using pruebaTecnica.Models;
using System.ComponentModel;

namespace pruebaTecnica.Utilidades
{
    public class Recursividad
    {


        public void llenarMochila(List<Element>elements,Mochila mochila,bool lleno, Mochila mochilaOptima)
        {
            // setencia para ver si la mochila se lleno para pasar a entrar a mirar las calorias y peso
            if (lleno)
            {
                //verifica que si la mochila del momento tiene mejor peso y caloria que nuestra mochila optima que teniamos, si se cumple entonces nuestra nueva mochila pasa a ser la optima
                if (mochila.Calorias >= mochilaOptima.Calorias && (mochilaOptima.Peso > -1))
                {
                    // lo separe porque lo que pasaba era que si habia mayor calorias pero no menor peso lo que hacia que no pasara el conjunto a la mochila optima
                    if ((mochila.Peso <= mochilaOptima.Peso))
                    {
                        mochilaOptima.limpiar();
                        //importante clonar la lista de elementos, lo hacia directamente pero guardaba era la posicion de memoria, entonces tenemos que clonar la lista
                        mochilaOptima.Elements = new List<Element>(mochila.Elements);
                        mochilaOptima.Calorias = mochila.Calorias;
                        mochilaOptima.Peso = mochila.Peso;
                    }
                    else
                    {

                        mochilaOptima.limpiar();
                        //importante clonar la lista de elementos, lo hacia directamente pero guardaba era la posicion de memoria, entonces tenemos que clonar la lista
                        mochilaOptima.Elements = new List<Element>(mochila.Elements);
                        mochilaOptima.Calorias = mochila.Calorias;
                        mochilaOptima.Peso = mochila.Peso;
                    }
                }

                //el -1 es importante porque puede existir una solucion con peso 0 que seria no tener elementos,sirve para saber que no hemos metido elementos entonces como es su primer llamado le ponemos lo que tenga la mochila actual cumpliendo con las condiciones minimas
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
                //aqui comienza el backtracking para ver todas las soluciones posibles
                for (int i=0;i < elements.Count;i++)
                {
                    //verificamos si ya metimos el elemento a la mochila ya que no existe un mismo elemento,aclarar que cuando se refiere un mismo elemento es al id, puede existir otro id diferente con el mismo nombre,peso y calorias
                    if (mochila.existeElemento(elements[i])==false)
                    {
                        //verifica que si añadimos el elemento no se vaya a pasar del peso maximo permitido
                        if (mochila.PesoMaximo >= mochila.Peso + elements[i].Peso)
                        {
                            mochila.añadirElemento(elements[i]);
                            //vuelve a llamar al metodo para hacer la recursividad diciendo que la mochila no esta llena para que intente añadir otro elemento
                            llenarMochila(elements, mochila, false,mochilaOptima);
                            //aqui es cuando se devuelve el algoritmo backtracking y elimina el elemento que añadimos para calcular las otras posibles soluciones con elementos distintos
                            mochila.eliminarElemento(elements[i]);
                        }
                        else
                        {
                            //Quiere decir que si añadimos el elemento actual la mochila se pasa del peso maximo permitido por lo cual pasamos con true que la mochila esta llena
                            llenarMochila(elements, mochila, true, mochilaOptima);
                        }
                    }
                    // caso de cuando la mochila aun tiene capacidad pero ya no hay elementos para añadir por lo tanto pasamos como verdadedo lleno para calcular las soluciones
                    else if (i == (elements.Count-1))
                    {
                        llenarMochila(elements, mochila, true, mochilaOptima);
                    }
                }
            }
          
        }

    }
}
