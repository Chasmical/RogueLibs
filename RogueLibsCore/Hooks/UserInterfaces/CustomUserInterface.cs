using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
    public abstract class CustomUserInterface : CustomUiElement, IHook<MainGUI>
    {
        public MainGUI MainGUI { get; private set; } = null!;
        protected Canvas canvas { get; private set; } = null!;
        protected GraphicRaycaster graphicRaycaster { get; private set; } = null!;

        public bool IsOpened => canvas.enabled;
        public virtual bool LocksCamera => true;

        object IHook.Instance => MainGUI;
        MainGUI IHook<MainGUI>.Instance => MainGUI;
        void IHook.Initialize(object _) { }

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        public sealed override void Awake()
        {
            MainGUI = gameObject.GetComponentInParent<MainGUI>();
            SetNormalizedPosition(gameObject, transform.parent, new Rect(0f, 0f, 1920f, 1080f));

            canvas = gameObject.AddComponent<Canvas>();
            canvas.enabled = false;

            graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
            Setup();
        }
        public abstract void Setup();

        public void ShowInterface()
        {
            if (canvas.enabled) return;
            gc.audioHandler.Play(MainGUI.agent, "ShowInterface");
            canvas.enabled = true;
            OnOpened();
        }
        public void HideInterface()
        {
            if (!canvas.enabled) return;
            gc.audioHandler.Play(MainGUI.agent, "HideInterface");
            canvas.enabled = false;
            OnClosed();
        }

        public abstract void OnOpened();
        public virtual void OnClosed() { }

    }
    public abstract class CustomUiElement : MonoBehaviour
    {
        private RectTransform? _rect;
        public RectTransform rect => _rect ??= GetComponent<RectTransform>();

        public abstract void Awake();

        public static TElement Create<TElement>(Transform parent, string gameObjectName, Rect rectangle) where TElement : Component
        {
            GameObject go = new GameObject(gameObjectName, typeof(RectTransform));
            RectTransform rect = SetNormalizedPosition(go, parent, rectangle);
            return go.AddComponent<TElement>();
        }
        public static TImage Create<TImage>(Transform parent, string gameObjectName, Vector2 position, byte[] spriteData, float scale = 1f) where TImage : Image
        {
            Sprite sprite = RogueUtilities.ConvertToSprite(spriteData);
            TImage img = Create<TImage>(parent, gameObjectName, new Rect(position, sprite.rect.size * scale));
            img.sprite = sprite;
            return img;
        }

        protected static RectTransform SetNormalizedPosition(GameObject go, Transform parent, Rect rectangle)
        {
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.SetParent(parent);

            rect.localScale = Vector3.one;
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = new Vector2(rectangle.x, -rectangle.y);
            rect.sizeDelta = rectangle.size;

            return rect;
        }

    }
}
