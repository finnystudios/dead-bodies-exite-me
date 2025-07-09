namespace Player.States
{
    public class FallingState : PlayerState
    {
        public FallingState(PlayerController player) : base(player)
        {
        }

        public override void Update()
        {
            if (Player.IsGrounded) Player.StateMachine.SetState(new IdleState(Player));
        }
    }
}