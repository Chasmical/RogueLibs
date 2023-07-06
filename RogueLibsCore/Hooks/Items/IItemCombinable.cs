namespace RogueLibsCore
{
    public interface IItemCombinable
    {
        bool CombineFilter(InvItem other);
        bool CombineItems(InvItem other);
        CustomTooltip CombineCursorText(InvItem other);
        CustomTooltip CombineTooltip(InvItem other);
    }
}
