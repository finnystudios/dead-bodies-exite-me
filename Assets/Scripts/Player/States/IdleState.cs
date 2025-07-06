using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : PlayerState
    {
        public IdleState(PlayerController player) : base(player) { }

        public override void Update()
        {
            InputAction moveAction = Player.InputManager.actions["Move"];

            if (moveAction.IsPressed())
            {
                Player.ChangeState(new MoveState(Player));
            }
        }
    }
}