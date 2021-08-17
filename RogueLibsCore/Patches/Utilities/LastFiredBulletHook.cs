namespace RogueLibsCore
{
	internal class LastFiredBulletHook : HookBase<Agent>
	{
		public Bullet LastFiredBullet { get; set; }
		protected override void Initialize() { }
	}
}
