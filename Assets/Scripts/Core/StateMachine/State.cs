namespace Core.StateMachine
{
    // <T> allows state to share a common context (context is things like a PlayerController, or EnemyAI)
    public abstract class State<T>
    {
        protected readonly T Context;

        protected State(T context)
        {
            Context = context;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}