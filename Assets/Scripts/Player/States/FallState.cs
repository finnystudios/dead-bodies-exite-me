namespace Player.States
{
    public class FallState : PlayerState
    {
        public FallState(PlayerController player) : base(player)
        {
        }

        public override void Update()
        {
            if (Player.IsGrounded) Player.StateMachine.SetState(new IdleState(Player));
        }
    }
}