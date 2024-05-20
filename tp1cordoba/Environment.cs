namespace tp1
{
    class Lienzo
        {
            private char[,] celdas;
            private int ancho, alto;

            public Lienzo(int ancho, int alto)
            {
                this.ancho = ancho;
                this.alto = alto;
                celdas = new char[ancho, alto];
            }

            public void Dibujar(int x, int y, char celda)
            {
                celdas[x, y] = celda;
            }

            public void MostrarEnPantalla()
            {

                Console.Clear();

                for (int y = 0; y < alto; y++)
                {
                    for (int x = 0; x < ancho; x++)
                    {
                        Console.Write(celdas[x, y]);
                    }
                    Console.Write("\n");
                }
            }
        }

        interface IMapa
        {
            bool EstaLibre(int x, int y);
        }

        class Habitacion : IMapa
        {
            private List<Fila> filas;

            public Habitacion(int ancho, int alto)
            {
                filas = new List<Fila>();

                filas.Add(new FilaBorde(ancho));
                for (int fila = 1; fila < alto - 1; fila++)
                {
                    filas.Add(new FilaMedia(ancho));
                }
                filas.Add(new FilaBorde(ancho));
            }

            public void Dibujar(Lienzo lienzo)
            {
                for (int y = 0; y < filas.Count(); y++)
                {
                    filas[y].Dibujar(lienzo, y);
                }
            }

            public bool EstaLibre(int x, int y)
            {
                return filas[y].EstaLibre(x);
            }
        }

        abstract class Fila
        {
            protected List<char> celdas;

            public Fila(int cantidadCeldas)
            {
                this.celdas = new List<char>();

                AgregarPunta();
                for (int i = 1; i < cantidadCeldas - 1; i++)
                {
                    AgregarMedio();
                }
                AgregarPunta();
            }

            protected abstract void AgregarMedio();
            protected abstract void AgregarPunta();

            public void Dibujar(Lienzo lienzo, int y)
            {
                for (int x = 0; x < celdas.Count(); x++)
                {
                    lienzo.Dibujar(x, y, celdas[x]);
                }
            }

            internal bool EstaLibre(int x)
            {
                return celdas[x] == ' ';
            }
        }

        class FilaMedia : Fila
        {
            public FilaMedia(int cantidadCeldas) : base(cantidadCeldas)
            {
            }

            protected override void AgregarMedio()
            {
                celdas.Add(' ');
            }
            protected override void AgregarPunta()
            {
                celdas.Add('#');
            }
        }

        class FilaBorde : Fila
        {
            public FilaBorde(int cantidadCeldas) : base(cantidadCeldas)
            {
            }

            protected override void AgregarMedio()
            {
                celdas.Add('#');
            }
            protected override void AgregarPunta()
            {
                celdas.Add('#');
            }
        }
}