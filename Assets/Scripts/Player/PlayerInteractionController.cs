using Interactables;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float interactionRange = 3f;

        private Interactable _currentInteractable;

        private TextMeshProUGUI _interactionPrompt;

        private Interactable CurrentInteractable
        {
            get => _currentInteractable;
            set
            {
                _currentInteractable = value;
                _interactionPrompt.text = value ? value.prompt : string.Empty;
            }
        }

        private void Awake()
        {
            _interactionPrompt = GetComponentInChildren<HUDController>().InteractionPrompt;
        }

        private void Update()
        {
            // ReSharper disable PossibleLossOfFraction
            var ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            // ReSharper restore PossibleLossOfFraction

            // If nothing is in interaction range, set current interactable to null and return early
            // The out keyword lets a function return multiple separate values and makes the returned value a variable,
            // see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out for more info
            if (!Physics.Raycast(ray, out var hit, interactionRange))
            {
                CurrentInteractable?.DisableOutline();
                CurrentInteractable = null;
                return;
            }

            // If hit isn't interactable, return
            if (!hit.transform.TryGetComponent(out Interactable interactable) || !interactable.IsInteractable) return;

            if (interactable == CurrentInteractable) return;

            if (interactable.IsInteractable)
            {
                CurrentInteractable = interactable;
                CurrentInteractable?.EnableOutline();
            }
            else
            {
                CurrentInteractable = null;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed || !_currentInteractable) return;
            Debug.Log(
                $"<b>Player interacted with object</b> | " +
                $"Name: {_currentInteractable.name} | " +
                $"Type: {_currentInteractable.GetType()} | " +
                $"ID: {_currentInteractable.GetInstanceID()}"
            );

            CurrentInteractable?.Interact();
        }
    }
}