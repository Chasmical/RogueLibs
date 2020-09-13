using System;
using System.Collections.Generic;

namespace RogueLibsCore.Interactions
{
	public class ObjectInteraction
	{
		internal ObjectInteraction(string id, InteractionType type, CustomName name, bool original)
		{
			Id = id;
			Type = type;
			ButtonName = name;
			FromOriginalGame = original;
		}

		/// <summary>
		///   <para>Identifier of this <see cref="ObjectInteraction"/>.</para>
		/// </summary>
		public string Id { get; }
		/// <summary>
		///   <para><see cref="InteractionType"/> of this <see cref="ObjectInteraction"/>.</para>
		/// </summary>
		public InteractionType Type { get; set; }

		/// <summary>
		///   <para>Localizable name of this <see cref="ObjectInteraction"/>'s button.</para>
		/// </summary>
		public CustomName ButtonName { get; }
		
		/// <summary>
		///   <para>Method that will determine when this <see cref="ObjectInteraction"/> will be active for an object.</para>
		///   <para><see cref="Agent"/> arg1 is the interacting player;<br/><see cref="PlayfieldObject"/> arg2 is the object that is being interacted with.</para>
		/// </summary>
		public Func<Agent, PlayfieldObject, bool> Condition { get; set; }
		/// <summary>
		///   <para>Method that will determine the cost and the extra text for this <see cref="ObjectInteraction"/>'s button. Return <see langword="null"/> to not add anything.</para>
		///   <para><see cref="Agent"/> arg1 is the interacting player;<br/><see cref="PlayfieldObject"/> arg2 is the object that is being interacted with;<br/><see cref="ObjectInteractionInfo"/> result is a structure containing the cost and the extra text values.</para>
		/// </summary>
		public Func<Agent, PlayfieldObject, ObjectInteractionInfo?> GetButtonInfo { get; set; }
		/// <summary>
		///   <para>Method that will invoked when interacted with an object directly or via a button.</para>
		///   <para><see cref="Agent"/> arg1 is the interacting player;<br/><see cref="PlayfieldObject"/> arg2 is the object that is being interacted with;<br/><see cref="bool"/> result determines whether the interaction should be stopped after interacting.</para>
		/// </summary>
		public Func<Agent, PlayfieldObject, bool> Action { get; set; }

		public bool FromOriginalGame { get; }

	}
	public struct ObjectInteractionInfo
	{
		public ObjectInteractionInfo(int cost)
		{
			Cost = cost;
			ExtraText = string.Empty;
		}
		public ObjectInteractionInfo(string extraText)
		{
			Cost = 0;
			ExtraText = extraText;
		}
		public ObjectInteractionInfo(int cost, string extraText)
		{
			Cost = cost;
			ExtraText = extraText;
		}

		public int Cost { get; set; }
		public string ExtraText { get; set; }
	}
}
