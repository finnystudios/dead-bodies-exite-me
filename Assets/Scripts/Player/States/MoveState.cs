namespace Player.States
{
    public class MoveState : PlayerState
    {
        public MoveState(PlayerController player) : base(player)
        {
        }

        public override void Update()
        {
            var moveAction = Player.InputManager.actions["Move"];

            if (!Player.IsGrounded) Player.StateMachine.SetState(new FallState(Player));

            if (!moveAction.IsPressed()) Player.StateMachine.SetState(new IdleState(Player));
        }
    }
}