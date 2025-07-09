using Core.StateMachine;

namespace Player.States
{
    public abstract class PlayerState : State<PlayerController>
    {
        protected PlayerState(PlayerController player) : base(player)
        {
        }

        // Make an alias of Context called Player
        protected PlayerController Player => Context;
    }
}