using UnityEngine;
using System;

namespace sarbajit.icat
{
    public abstract class EventChannelSOBase<T> : ScriptableObject
    {
        public T Data;
        public event Action<T> OnEventRaised;

        public virtual void RaiseSimpleEvent(T signal, T data)
        {
            Data = data;
            OnEventRaised?.Invoke(signal);
        }
    }
}
