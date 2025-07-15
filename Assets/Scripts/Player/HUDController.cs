using TMPro;
using UnityEngine;

namespace Player
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI interactionPrompt;

        public TextMeshProUGUI InteractionPrompt
        {
            get => interactionPrompt;
            set => interactionPrompt = value;
        }

        private void Awake()
        {
            if (interactionPrompt == null)
                Debug.LogError($"Missing Interaction Prompt reference on {gameObject.name}", this);
        }
    }
}