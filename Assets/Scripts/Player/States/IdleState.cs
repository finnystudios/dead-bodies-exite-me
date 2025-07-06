using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : PlayerState
    {
        // Run superclass constructor
        public IdleState(PlayerController context) : base(context) { }

        public override void Update()
        {
            InputAction moveAction = Player.InputManager.actions["Move"];

            if (moveAction.IsPressed())
            {
                Player.StateMachine.SetState(new MoveState(Player));
            }
        }
    }
}