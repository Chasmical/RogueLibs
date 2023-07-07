using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace RogueLibsCore
{
    public sealed class HookEventDispatcher<T> where T : class
    {
        private bool isUpdating;
        private readonly List<WeakReference<T>> updateList = new();
        private readonly List<T> stagedToBeRemoved = new();

        public void Register(T hook)
            => updateList.Add(new WeakReference<T>(hook));
        public bool TryRegister(object target)
        {
            if (target is T hook)
            {
                Register(hook);
                return true;
            }
            return false;
        }

        public bool UnRegister(T hook)
        {
            int index = updateList.FindIndex(wr => wr.TryGetTarget(out T? target) && target == hook);
            if (index >= 0)
            {
                if (isUpdating) stagedToBeRemoved.Add(hook);
                else updateList.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool TryUnRegister(object target)
            => target is T hook && UnRegister(hook);

        public void DispatchEvent([InstantHandle] Action<T> dispatchEvent)
        {
            try
            {
                isUpdating = true;
                int index = 0;
                int count = updateList.Count;
                do
                {
                    while (index < count)
                        if (updateList[index++].TryGetTarget(out T? target))
                            dispatchEvent(target);
                    count = updateList.Count;
                }
                while (index < count);

                foreach (T hook in stagedToBeRemoved)
                {
                    int removeIndex = updateList.FindIndex(wr => wr.TryGetTarget(out T? target) && target == hook);
                    if (removeIndex >= 0) updateList.RemoveAt(removeIndex);
                }
                stagedToBeRemoved.Clear();
            }
            finally
            {
                isUpdating = false;
            }
        }

    }
}
