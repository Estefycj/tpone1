namespace tp1 
{
    class Arma:Entidades
    {  
        public List<Arma> disparo;
        
        public Arma(int x, int y, IMapa mapa, char dibujo) : base(x, y, mapa, dibujo)
        {
        }

        public List<Enemigos> monda;

        //colisiones que pasan entre los espectros
        public bool ColisionaConMonda(Arma arma)
        {
            foreach (var monda in monda)
            {
                if (this.x == monda.x && this.y == monda.y)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}