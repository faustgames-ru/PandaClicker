namespace Engine.States
{
    public interface IState
    {
        void Start();
        void Update();
        void Finish();
    }
}
