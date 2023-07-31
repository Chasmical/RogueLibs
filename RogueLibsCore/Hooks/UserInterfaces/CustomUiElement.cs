using UnityEngine;

namespace RogueLibsCore
{
    public abstract class CustomUiElement : MonoBehaviour
    {
        private RectTransform? _rect;
        public RectTransform rect => _rect ??= GetComponent<RectTransform>();

        public abstract void Awake();

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        public GameObject CreateElement(string gameObjectName, Vector2 position)
            => CreateElement(transform, gameObjectName, position);
        public GameObject CreateElement(string gameObjectName, Rect rectangle)
            => CreateElement(transform, gameObjectName, rectangle);
        public static GameObject CreateElement(Transform parent, string gameObjectName, Vector2 position)
            => CreateElement(parent, gameObjectName, new Rect(position, new Vector2(100f, 100f)));
        public static GameObject CreateElement(Transform parent, string gameObjectName, Rect rectangle)
        {
            GameObject go = new GameObject(gameObjectName, typeof(RectTransform));
            SetTopLeftCornerPosition(go, parent, rectangle);
            return go;
        }

        public TElement CreateElement<TElement>(string gameObjectName, Vector2 position) where TElement : Component
            => CreateElement<TElement>(transform, gameObjectName, position);
        public TElement CreateElement<TElement>(string gameObjectName, Rect rectangle) where TElement : Component
            => CreateElement<TElement>(transform, gameObjectName, rectangle);
        public static TElement CreateElement<TElement>(Transform parent, string gameObjectName, Vector2 position) where TElement : Component
            => CreateElement<TElement>(parent, gameObjectName, new Rect(position, new Vector2(100f, 100f)));
        public static TElement CreateElement<TElement>(Transform parent, string gameObjectName, Rect rectangle) where TElement : Component
            => CreateElement(parent, gameObjectName, rectangle).AddComponent<TElement>();

        protected static void SetTopLeftCornerPosition(GameObject go, Transform parent, Rect rectangle)
        {
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.SetParent(parent);

            rect.localScale = Vector3.one;
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = new Vector2(rectangle.x, -rectangle.y);
            rect.sizeDelta = rectangle.size;
        }
        protected static void SetCenterPosition(GameObject go, Transform parent, Rect rectangle)
        {
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.SetParent(parent);

            rect.localScale = Vector3.one;
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(rectangle.x, -rectangle.y);
            rect.sizeDelta = rectangle.size;
        }

    }
}
