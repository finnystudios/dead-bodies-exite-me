namespace Player.States
{
    public abstract class PlayerState : State
    {
        protected readonly PlayerController Player;

        protected PlayerState(PlayerController player)
        {
            this.Player = player;
        }
    }
}