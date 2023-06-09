using pruebaTecnica.Models;

namespace pruebaTecnica.Utilidades
{
    public class programa
    {
        public void Main()
        {
            // Definir la cantidad mínima de calorías requeridas y el peso máximo
            int caloriasMinimas = 1000;
            int pesoMaximo = 5;

            // Crear una lista de elementos disponibles
            List<Elemento> elementos = new List<Elemento>()
            {
                new Elemento() { Nombre = "E1", Calorias = 3, Peso = 5 },
                new Elemento() { Nombre = "E2", Calorias = 5, Peso = 3 },
                new Elemento() { Nombre = "E3", Calorias = 2, Peso = 5 },
                new Elemento() { Nombre = "E4", Calorias = 8, Peso = 1 },
                new Elemento() { Nombre = "E5", Calorias = 3, Peso = 2 },
            };

            // Encontrar el conjunto de elementos óptimos
            List<Elemento> elementosOptimos = EncontrarElementosOptimos(elementos, caloriasMinimas, pesoMaximo);

            // Mostrar el resultado
            Console.WriteLine("Conjunto de elementos óptimos:");
            foreach (var elemento in elementosOptimos)
            {
                Console.WriteLine($"- {elemento.Nombre}");
            }
        }

        public List<Elemento> EncontrarElementosOptimos(List<Elemento> elementos, int caloriasMinimas, int pesoMaximo)
        {
            // Algoritmo de selección de elementos óptimos basado en backtracking

            List<Elemento> conjuntoOptimo = null;
            int caloriasActuales = 0;
            int pesoActual = 0;

            EncontrarElementosRecursivo(elementos, caloriasMinimas, pesoMaximo, 0, new List<Elemento>(),  conjuntoOptimo,  caloriasActuales,  pesoActual);

            return conjuntoOptimo;
        }

        public void EncontrarElementosRecursivo(List<Elemento> elementos, int caloriasMinimas, int pesoMaximo, int indiceActual, List<Elemento> conjuntoActual,  List<Elemento> conjuntoOptimo,  int caloriasActuales,  int pesoActual)
        {
            if (caloriasActuales >= caloriasMinimas && (conjuntoOptimo == null || pesoActual < conjuntoOptimo.Count))
            {
                conjuntoOptimo = new List<Elemento>(conjuntoActual);
                return;
            }

            if (indiceActual >= elementos.Count)
                return;

            Elemento elementoActual = elementos[indiceActual];

            // Intentar agregar el elemento actual al conjunto
            if (pesoActual + elementoActual.Peso <= pesoMaximo)
            {
                conjuntoActual.Add(elementoActual);
                caloriasActuales += elementoActual.Calorias;
                pesoActual += elementoActual.Peso;

                EncontrarElementosRecursivo(elementos, caloriasMinimas, pesoMaximo, indiceActual + 1, conjuntoActual,  conjuntoOptimo,  caloriasActuales,  pesoActual);

                conjuntoActual.Remove(elementoActual);
                caloriasActuales -= elementoActual.Calorias;
                pesoActual -= elementoActual.Peso;
            }

            // No agregar el elemento actual al conjunto
            EncontrarElementosRecursivo(elementos, caloriasMinimas, pesoMaximo, indiceActual + 1, conjuntoActual,  conjuntoOptimo,  caloriasActuales,  pesoActual);
        }
    }
}
