namespace ejercicio01.entidades
{
    public struct VectorDatos
    {
        private int[] numAzar;

        public VectorDatos(int tamaño)
        {
            numAzar = new int[tamaño];
        }

        public void GenerarElementos(Random random)
        {
            for (int i = 0; i < numAzar.Length; i++)
            {
                numAzar[i] = random.Next(1, 99);
            }
        }

        public int[] ObtenerElementos() => numAzar;

        public void OrdenarVector() => Array.Sort(numAzar);

        public bool EstaVacio() => numAzar.Length == 0 || numAzar.All(x => x == 0);

        public bool EsPar(int v) => v % 2 == 0;

        public bool EsPrimo(int v)
        {
            if (v <= 1) return false;
            if (v == 2) return true;
            if (v % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(v); i += 2)
            {
                if (v % i == 0) return false;
            }
            return true;
        }

        public int MenorElemento() => numAzar.Min();

        public int MayorElemento() => numAzar.Max();

        public double MediaElementos() => numAzar.Average();
    }
}
