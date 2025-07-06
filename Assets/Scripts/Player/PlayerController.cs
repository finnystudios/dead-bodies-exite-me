using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    public PlayerInput InputManager { get; private set; }

    private PlayerState currentState;
    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        InputManager = gameObject.GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ChangeState(new IdleState(this));   
    }

    // Update is called once per frame
    private void Update()
    {
        currentState?.Update();
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    private void FixedUpdate()
    {
        if (currentState is MoveState)
        {
            HandleMovement();
            ApplyGravity();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void ChangeState(PlayerState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    private void HandleMovement()
    {
        // Get move direction
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        // Apply forces
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    private void ApplyGravity()
    {
        // Apply gravity to the player
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
}
