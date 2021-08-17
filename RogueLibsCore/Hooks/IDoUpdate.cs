namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that this hook class should be updated with Unity's Update method.</para>
	/// </summary>
	public interface IDoUpdate
	{
		/// <summary>
		///   <para>The Unity's Update method, that is called once per frame.</para>
		/// </summary>
		void Update();
	}
}
