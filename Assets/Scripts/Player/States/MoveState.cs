using UnityEngine.InputSystem;

public class MoveState : PlayerState
{
    public MoveState(PlayerController player) : base(player) { }

    public override void Update()
    {
        InputAction moveAction = player.InputManager.actions["Move"];

        if (!moveAction.IsPressed())
        {
            player.ChangeState(new MoveState(player));
        }
    }
}