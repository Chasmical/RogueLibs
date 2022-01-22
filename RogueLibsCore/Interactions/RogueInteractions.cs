using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
    public static class RogueInteractions
    {

    }
    public interface IInteraction
    {
        PlayfieldObject Instance { get; set; }
        bool DetermineButton();
        void OnPressedButton();
        void CreateButton();
    }
    public interface ICustomInteraction : IInteraction
    {
		string Name { get; set; }
    }
    public abstract class CustomInteraction : ICustomInteraction
    {
		public string Name { get; internal set; }
        string ICustomInteraction.Name { get => Name; set => Name = value; }
		public PlayfieldObject Instance { get; private set; }
		PlayfieldObject IInteraction.Instance { get => Instance; set => Instance = value; }

        public abstract bool DetermineButton();
        public abstract void OnPressedButton();
        public virtual void CreateButton()
        {
            Instance.buttons.Add(Name);
            Instance.buttonsExtra.Add(string.Empty); // or ExtraInfo
			// Instance.buttonPrices
        }




    }
    public abstract class SimpleInteraction
    {
		public PlayfieldObject Instance { get; internal set; }

        public abstract bool DetermineButton();
        public abstract void OnPressed();
    }
    public abstract class CustomInteraction<T> : ICustomInteraction where T : PlayfieldObject
    {
        public string Name { get; internal set; }
        string ICustomInteraction.Name { get => Name; set => Name = value; }
        private PlayfieldObject instance;
		PlayfieldObject IInteraction.Instance { get => instance; set => instance = value; }
		public T Instance => (T)instance;

        bool IInteraction.DetermineButton() => instance is T && DetermineButton();
        public abstract bool DetermineButton();
        public abstract void OnPressedButton();
        public virtual void CreateButton()
        {
            Instance.buttons.Add(Name);
            Instance.buttonsExtra.Add(string.Empty); // or ExtraInfo
            // Instance.buttonPrices
        }




    }
}
