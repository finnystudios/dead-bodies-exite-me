using Core.StateMachine;

namespace Player.States
{
    public abstract class PlayerState : State<PlayerController>
    {
        // Make an alias of Context called Player
        protected PlayerController Player => Context;
        
        protected PlayerState(PlayerController context) : base(context) { }
    }
}