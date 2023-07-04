namespace RogueLibsCore
{
    public interface IDoUpdate
    {
        void Update();
    }
    public interface IDoLateUpdate
    {
        void LateUpdate();
    }
    public interface IDoFixedUpdate
    {
        void FixedUpdate();
    }
}
