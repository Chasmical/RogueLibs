namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that this hook class should be updated with Unity's FixedUpdate method.</para>
	/// </summary>
	public interface IDoFixedUpdate
	{
		/// <summary>
		///   <para>The Unity's FixedUpdate method, that is called approximately 60 times per second, or 100 times per second when everything's slowed down.</para>
		/// </summary>
		void FixedUpdate();
	}
}
