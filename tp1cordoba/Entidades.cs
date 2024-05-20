namespace tp1
{
    class Entidades
    {
        public int x;
        public int y;
        private IMapa mapa;
        private char dibujo;
                
        public Entidades(int x, int y, IMapa mapa, char dibujo) 
        {
            this.x = x;
            this.y = y;
            this.mapa = mapa;
            this.dibujo = dibujo;
            
        }

        public void MoverHacia(int x, int y)
        {
            var nuevoX = this.x + x;
            var nuevoY = this.y + y;

            if (mapa.EstaLibre(nuevoX, nuevoY))
            {
                this.x = nuevoX;
                this.y = nuevoY;
            }
        }

        public void Dibujar(Lienzo lienzo)
        {
            lienzo.Dibujar(x, y, dibujo);
        }

    }
}