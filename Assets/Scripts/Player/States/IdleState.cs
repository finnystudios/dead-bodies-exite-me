namespace Player.States
{
    public class IdleState : PlayerState
    {
        // Run superclass constructor
        public IdleState(PlayerController player) : base(player)
        {
        }

        public override void Update()
        {
            var moveAction = Player.InputManager.actions["Move"];

            if (!Player.IsGrounded) Player.StateMachine.SetState(new FallingState(Player));

            if (moveAction.IsPressed()) Player.StateMachine.SetState(new MoveState(Player));
        }
    }
}