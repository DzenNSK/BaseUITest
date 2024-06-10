using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseUITest
{
    public class UIScreenBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup rootCanvasGroup;
        [SerializeField] protected RectTransform screenRoot;

        protected const float animationTime = 1f;

        private bool isActive;
        private Sequence sequence;

        public CanvasGroup RootCanvasGroup => rootCanvasGroup;
        public bool IsActive => isActive;

        public event Action onAnimationComplete;

        public virtual void InitScreen()
        {
            screenRoot?.gameObject.SetActive(false);
            rootCanvasGroup.alpha = 0f;
            screenRoot.anchoredPosition = new Vector2(0, screenRoot.rect.height);
        }

        public virtual void ResetScreen()
        {

        }

        public virtual void Show(bool animated = true)
        {
            if (isActive) return;
            screenRoot?.gameObject.SetActive(true);
            isActive = true;

            if(sequence != null)
            {
                sequence.Kill();
            }

            sequence = DOTween.Sequence();
            sequence.Append(screenRoot.DOAnchorPos(Vector2.zero, animationTime));
            sequence.Join(rootCanvasGroup.DOFade(1f, animationTime));
            sequence.AppendCallback(OnAnimationComplete);
            sequence.Play();
        }

        public virtual void Hide(bool animated = true)
        {
            if (!isActive) return;
            isActive = false;

            if (sequence != null)
            {
                sequence.Kill();
            }

            sequence = DOTween.Sequence();
            sequence.Append(screenRoot.DOAnchorPos(new Vector2(0, screenRoot.rect.height), animationTime));
            sequence.Join(rootCanvasGroup.DOFade(0f, animationTime));
            sequence.AppendCallback(OnAnimationComplete);
            sequence.Play();
        }

        protected void OnAnimationComplete()
        {
            sequence?.Kill();
            onAnimationComplete?.Invoke();
            screenRoot.gameObject.SetActive(isActive);
        }
    }
}
