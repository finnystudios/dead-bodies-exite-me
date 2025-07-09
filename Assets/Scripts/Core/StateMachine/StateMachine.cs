namespace Core.StateMachine
{
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }

        public void SetState(State<T> state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}