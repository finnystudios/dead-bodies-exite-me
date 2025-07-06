using UnityEngine.InputSystem;

public class IdleState : PlayerState
{
    public IdleState(PlayerController player) : base(player) { }

    public override void Update()
    {
        InputAction moveAction = player.InputManager.actions["Move"];

        if (moveAction.IsPressed())
        {
            player.ChangeState(new MoveState(player));
        }
    }
}