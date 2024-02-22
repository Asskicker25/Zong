using UnityEngine;
using DG.Tweening;

namespace Scripts.UI
{
    //The parent class used to inherit various different types of windows to be opened and closed
    [RequireComponent(typeof(CanvasGroup))]
    public class UIWindow : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        public bool awakeOnStart;
        public eUIWindowType windowType;

        protected UIWindowService windowService;


        protected virtual void Reset()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0;
        }

        public virtual void Open(float time = 0.5f)
        {
            _canvasGroup.DOFade(1, time);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public virtual void Close(float time = 0.5f)
        {
            _canvasGroup.DOFade(0, time);
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        public void SetWindowService(UIWindowService windowService )
        {
            this.windowService = windowService;
        }
    }

}
