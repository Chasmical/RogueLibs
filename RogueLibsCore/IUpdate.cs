using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace RogueLibsCore
{
	public interface IDoUpdate
	{
		void Update();
	}
	public interface IDoFixedUpdate
	{
		void FixedUpdate();
	}
}
