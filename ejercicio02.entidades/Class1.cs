namespace ejercicio02.entidades
{
    public struct Velocidad
    {
        public int KmH { get; }
        public double MillasH => KmH * 0.621371;

        public Velocidad(int kmh)
        {
            KmH = kmh;
        }
    }
}
