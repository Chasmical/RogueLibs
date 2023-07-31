using System.Collections;
using UnityEngine;

namespace RogueLibsCore
{
    public abstract class CustomUserInterface : CustomUiBase
    {
        public bool IsOpened => canvas.enabled;
        public virtual Vector2? CameraLock => Vector2.zero;

        public sealed override void Awake()
        {
            base.Awake();
            canvas.enabled = false;
            graphicRaycaster.enabled = false;
            canvasGroup.alpha = 0f;
            Setup();
        }
        public abstract void Setup();

        private Coroutine? animatingCoroutine;
        public void ShowInterface()
        {
            if (canvas.enabled) return;

            if (animatingCoroutine is not null)
                StopCoroutine(animatingCoroutine);
            animatingCoroutine = StartCoroutine(WrapShowAnimation());

            OnOpened();
        }
        public void HideInterface()
        {
            if (!canvas.enabled) return;

            if (animatingCoroutine is not null)
                StopCoroutine(animatingCoroutine);
            animatingCoroutine = StartCoroutine(WrapHideAnimation());

            OnClosed();
        }

        public abstract void OnOpened();
        public abstract void OnClosed();

        private IEnumerator WrapShowAnimation()
        {
            canvas.enabled = true;
            graphicRaycaster.enabled = false;
            yield return ShowAnimation();
            animatingCoroutine = null;
            graphicRaycaster.enabled = true;
        }
        private IEnumerator WrapHideAnimation()
        {
            canvas.enabled = true;
            graphicRaycaster.enabled = false;
            yield return HideAnimation();
            animatingCoroutine = null;
            canvas.enabled = false;
        }

        protected virtual IEnumerator ShowAnimation()
        {
            gc.audioHandler.Play(MainGUI.agent, "ShowInterface");

            float x = canvasGroup.alpha;
            while (x < 1f)
            {
                x = Mathf.Clamp01(x + 5f * Time.deltaTime);
                canvasGroup.alpha = x;
                rect.localScale = new Vector3(x, x, x);
                yield return null;
            }
        }
        protected virtual IEnumerator HideAnimation()
        {
            gc.audioHandler.Play(MainGUI.agent, "HideInterface");

            float x = canvasGroup.alpha;
            while (x > 0f)
            {
                x = Mathf.Clamp01(x - 5f * Time.deltaTime);
                canvasGroup.alpha = x;
                rect.localScale = new Vector3(x, x, x);
                yield return null;
            }
        }

    }
}
