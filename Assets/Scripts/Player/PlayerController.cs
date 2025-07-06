using Player.States;
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

        private PlayerState _currentState;
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
            ChangeState(new IdleState(this));   
        }

        // Update is called once per frame
        private void Update()
        {
            _currentState?.Update();
        }

        // FixedUpdate is called at a fixed interval and is used for physics calculations
        private void FixedUpdate()
        {
            if (_currentState is MoveState)
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

        public void ChangeState(PlayerState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
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
