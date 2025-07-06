using Player.States;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float gravity = 9.8f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;

        public PlayerInput InputManager { get; private set; }
        public readonly StateMachine<PlayerController> StateMachine = new();
        
        private Rigidbody _rb;
        private Vector2 _moveInput;

        // Variable initializations
        private void Awake()
        {
            _rb = gameObject.GetComponent<Rigidbody>();
            InputManager = gameObject.GetComponent<PlayerInput>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            StateMachine.SetState(new IdleState(this));
        }

        // Update is called once per frame
        private void Update()
        {
            StateMachine.CurrentState?.Update();
        }

        // FixedUpdate is called at a fixed interval and is used for physics calculations
        private void FixedUpdate()
        {
            if (StateMachine.CurrentState is MoveState)
            {
                HandleMovement();
                ApplyGravity();
            }
        }
        
        // Get movement direction from input callback
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        
        // Applies forces to move player
        private void HandleMovement()
        {
            // Get movement direction
            Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            // Apply forces
            _rb.MovePosition(_rb.position + move * (moveSpeed * Time.fixedDeltaTime));
        }

        private void ApplyGravity()
        {
            // Apply gravity to the player
            _rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }
}
