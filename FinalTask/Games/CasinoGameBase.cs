
namespace FinalTask.Games
{
    public abstract class CasinoGameBase
    {

        public abstract void PlayGame();
        
        public event Delegate OnWin;
        public event Delegate OnLoose;
        public event Delegate OnDraw;

        protected void OnWinInvoke()
        { OnWin(); }
        protected void OnLooseInvoke()
        { OnLoose(); }
        protected void OnDrawInvoke()
        { OnDraw(); }

        public delegate void Delegate();
        protected abstract void FactoryMethod();

        //protected abstract void WriteResult();
        public CasinoGameBase()
        { FactoryMethod(); }




    }
}
