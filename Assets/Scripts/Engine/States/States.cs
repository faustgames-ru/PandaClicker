namespace Engine.States
{
    public class States
    {
        public void Update()
        {
            _current.Update();
        }

        public void NextState(IState state)
        {
        }

        void SetState(IState state)
        {
            _current?.Finish();
            _current = state;
            _current?.Start();
        }

        IState _current;
    }
}
