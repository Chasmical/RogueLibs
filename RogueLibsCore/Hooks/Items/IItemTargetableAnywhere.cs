using UnityEngine;

namespace RogueLibsCore
{
    public interface IItemTargetableAnywhere
    {
        bool TargetFilter(Vector2 position);
        bool TargetObject(Vector2 position);
        CustomTooltip TargetCursorText(Vector2 position);
    }
}
