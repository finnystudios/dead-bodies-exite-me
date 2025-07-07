using Player.States;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;

        public PlayerInput InputManager { get; private set; }
        public readonly StateMachine<PlayerController> StateMachine = new();
        public bool IsGrounded => _controller.isGrounded;

        private CharacterController _controller;
        private Vector2 _moveInput;
        private Vector3 _velocity;

        // Variable initializations
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            InputManager = gameObject.GetComponent<PlayerInput>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            StateMachine.SetState(new IdleState(this));
        }

        // Update is called once per frame
        // Don't kill me for putting physics in Update, Unity recommends it for CharacterController.move
        private void Update()
        {
            // Movement logic
            Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            _controller.Move(move * (moveSpeed * Time.deltaTime));
            
            // Gravity
            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
            
            StateMachine.CurrentState?.Update();
        }
        
        // Get movement direction from input callback
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
    }
}
