using UnityEngine.InputSystem;

namespace Player.States
{
    public class MoveState : PlayerState
    {
        public MoveState(PlayerController player) : base(player) { }

        public override void Update()
        {
            InputAction moveAction = Player.InputManager.actions["Move"];

            if (!moveAction.IsPressed())
            {
                Player.StateMachine.SetState(new IdleState(Player));
            }
        }
    }
}