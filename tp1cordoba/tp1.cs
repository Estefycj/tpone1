namespace tp1
{
public class Program()
    {
        public static void Correr()
        {
            var juego = new Juego();
            juego.CorrerJuego();
        }
    }

    class Juego
    {
        int frame;
        Entidades jugador;
        Enemigos enemigos;
        List<Enemigos> monda;
        Arma arma;
        List<Arma> disparo;
        Habitacion habitacion;


        public void CorrerJuego()
        {
            
            Inicializacion();

            DibujarPantalla();

            
            while (true)
            {
            
                ConsoleKeyInfo? input = null;
                if (Console.KeyAvailable)
                    input = Console.ReadKey();

                ActualizarDatos(input);

                DibujarPantalla();

                Thread.Sleep(300);
            }
        }

        void Inicializacion()
        {
            frame = 0;
            habitacion = new Habitacion(15, 10);
            jugador = new Entidades(6, 7, habitacion, '^');
            disparo = new List<Arma>();
            
            monda = new List<Enemigos>();

            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {

                    int x = 5 + columna * 2; 
                    int y = 2 + fila * 2; 
                    
                    monda.Add(new Enemigos(x, y, habitacion, '=', monda));
                }
            }
           
        }

        void ActualizarDatos(ConsoleKeyInfo? input)
        {

            frame++;

            if (input.HasValue)
            {
                var tecla = input.Value.Key;

                if (tecla == ConsoleKey.RightArrow)
                    jugador.MoverHacia(1, 0);
                if (tecla == ConsoleKey.LeftArrow)
                    jugador.MoverHacia(-1, 0);
                if (tecla == ConsoleKey.Spacebar)
                    Disparar();
                
                if (tecla == ConsoleKey.Escape)
                    Environment.Exit(0);
            }

            void Disparar()
            {
                disparo.Add(new Arma(jugador.x, jugador.y -1, habitacion, '|'));
            }

            foreach (var disparo in disparo)
            {
                disparo.MoverHacia(0, -1);               

            }

            for (int i = disparo.Count - 1; i >= 0; i--)
            {
                if (disparo[i].y == 1)
                {
                    disparo.RemoveAt(i);
                }

                else
                {
                    for (int m = 0; m < monda.Count; m++)
                    {
                        if (disparo[i].ColisionaConMonda(monda[m]))
                        {
                            disparo.RemoveAt(i);
                            monda.RemoveAt(m);
                            break;
                        }

                    }
                }  
            }
        }

        void DibujarPantalla()
        {
            Lienzo lienzo = new Lienzo(15, 10);
            habitacion.Dibujar(lienzo);
            jugador.Dibujar(lienzo);
            
            // monda x aqui monda x alla
            foreach (var mondaEnemigo in monda)
            {
                mondaEnemigo.Dibujar(lienzo);
            }

            foreach (var disparoArma in disparo)
            {
                disparoArma.Dibujar(lienzo);
            }

            lienzo.MostrarEnPantalla();
            Console.WriteLine($"Frame: {frame}");
        }
    }

}