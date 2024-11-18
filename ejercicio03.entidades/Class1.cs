namespace ejercicio03.entidades
{
    public struct Persona
    {
        public string Nombre { get; }
        public int CantidadLetras => Nombre.Length;
        public int CantidadVocales => Nombre.Count(c => "AEIOU".Contains(char.ToUpper(c)));

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }
}
