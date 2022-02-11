namespace RogueLibsCore
{
    internal class LastFiredBulletHook : HookBase<PlayfieldObject>
    {
        public Bullet LastFiredBullet { get; set; }
        protected override void Initialize() { }
    }
}
