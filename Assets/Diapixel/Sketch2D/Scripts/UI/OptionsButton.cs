using UnityEngine;

namespace Diapixel.Sketch2D.UI
{
    [RequireComponent(typeof(Animator))]
    public class OptionsButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject optionsPanel = null;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        public void TriggerPanel()
        {
            bool optionsPanelActive = optionsPanel.activeSelf;
            optionsPanel.SetActive(!optionsPanelActive);

            if (optionsPanelActive)
            {
                animator.SetTrigger("Close");
            }
            else
            {
                animator.SetTrigger("Open");
            }
        }
    }
}
