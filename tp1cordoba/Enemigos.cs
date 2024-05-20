namespace tp1 
{
    class Enemigos:Arma
    {
        public Enemigos(int x, int y, IMapa mapa, char dibujo, List<Enemigos> monda) : base(x, y, mapa, dibujo)
        {
            this.monda = monda;
        }
        
    }
}