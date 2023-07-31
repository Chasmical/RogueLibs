namespace RogueLibsCore
{
    public abstract class CustomUserOverlay : CustomUiBase
    {
        public sealed override void Awake()
        {
            base.Awake();
            canvas.enabled = true;
            graphicRaycaster.enabled = true;
            canvasGroup.alpha = 1f;
            Setup();
        }
        public abstract void Setup();

    }
}
