namespace RogueLibsCore
{
    public interface IItemTargetable
    {
        bool TargetFilter(PlayfieldObject target);
        bool TargetObject(PlayfieldObject target);
        CustomTooltip TargetCursorText(PlayfieldObject? target);
    }
}
