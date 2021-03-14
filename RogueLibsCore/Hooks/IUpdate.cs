using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Specifies that instances of the current type must be updated using the <see cref="Update"/> method.</para>
	/// </summary>
	public interface IDoUpdate
	{
		/// <summary>
		///   <para>Identical to Unity's Update method. Called once every frame.</para>
		/// </summary>
		void Update();
	}
	/// <summary>
	///   <para>Specifies that instances of the current type must be updated using the <see cref="FixedUpdate"/> method.</para>
	/// </summary>
	public interface IDoFixedUpdate
	{
		/// <summary>
		///   <para>Identical to Unity's FixedUpdate method. Called once every fixed frame-rate frame.</para>
		/// </summary>
		void FixedUpdate();
	}
}
