namespace Player.States
{
    public class SprintState : PlayerState
    {
        private float _moveSpeed;

        public SprintState(PlayerController player) : base(player)
        {
        }

        public override void Enter()
        {
            _moveSpeed = Player.MoveSpeed;
            Player.MoveSpeed *= Player.SprintSpeedModifier;
        }

        public override void Exit()
        {
            Player.MoveSpeed = _moveSpeed;
        }
    }
}