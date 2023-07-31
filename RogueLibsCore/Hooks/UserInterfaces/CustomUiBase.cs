using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
    public abstract class CustomUiBase : CustomUiElement, IHook<MainGUI>
    {
        public MainGUI MainGUI { get; private set; } = null!;
        protected Canvas canvas { get; private set; } = null!;
        protected GraphicRaycaster graphicRaycaster {  get; private set; } = null!;
        protected CanvasGroup canvasGroup { get; private set; } = null!;

        object IHook.Instance => MainGUI;
        MainGUI IHook<MainGUI>.Instance => MainGUI;
        void IHook.Initialize(object _) { }

        public override void Awake()
        {
            MainGUI = gameObject.GetComponentInParent<MainGUI>();
            SetCenterPosition(gameObject, transform.parent, new Rect(960f, 540f, 1920f, 1080f));

            canvas = gameObject.AddComponent<Canvas>();
            graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

    }
}
