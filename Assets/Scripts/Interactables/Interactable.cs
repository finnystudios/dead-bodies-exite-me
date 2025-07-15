using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Outline))]
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private bool isInteractable = true;
        public string prompt;

        private Outline _outline;

        public bool IsInteractable => isInteractable;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
            _outline.enabled = false;
        }

        public virtual void Interact()
        {
            gameObject.SetActive(false);
        }

        public void EnableOutline()
        {
            _outline.enabled = true;
        }

        public void DisableOutline()
        {
            _outline.enabled = false;
        }
    }
}