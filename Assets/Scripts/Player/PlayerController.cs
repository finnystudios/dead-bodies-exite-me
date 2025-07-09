using Core.StateMachine;
using Player.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")] [SerializeField]
        private float gravity = Physics.gravity.y;

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float sprintSpeedModifier = 1.5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float airborneMovementDampener = 0.5f;

        [Header("Debug Settings")] [SerializeField]
        private bool printStates;

        public readonly StateMachine<PlayerController> StateMachine = new();

        private CharacterController _controller;
        private Vector2 _moveInput;
        private Vector3 _velocity;

        public float MoveSpeed
        {
            // Ensure MoveSpeed isn't negative  
            get => moveSpeed;
            set => moveSpeed = value >= 0 ? value : moveSpeed;
        }

        public float SprintSpeedModifier => sprintSpeedModifier;

        public PlayerInput InputManager { get; private set; }
        public bool IsGrounded => _controller.isGrounded;

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
            var move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            _controller.Move(move * (moveSpeed * Time.deltaTime));

            // Gravity
            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);

            StateMachine.CurrentState?.Update();

            if (Time.frameCount % 20 == 0 && printStates)
                Debug.Log(StateMachine.CurrentState);
        }

        // Get movement direction from input callback
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = StateMachine.CurrentState is not FallState
                ? context.ReadValue<Vector2>()
                : context.ReadValue<Vector2>() * airborneMovementDampener;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (IsGrounded && context.performed) _velocity.y = jumpForce;
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (IsGrounded && context.performed) StateMachine.SetState(new SprintState(this));
            else if (context.canceled) StateMachine.SetState(new IdleState(this));
        }
    }
}