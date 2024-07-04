using System;
using UnityEngine;

namespace sarbajit.icat
{
    [CreateAssetMenu(menuName = "Even Channels/Void", fileName = "VEC_New", order = 0)]
    public class VoidChannelSO : ScriptableObject
    {
        public event Action OnEventRaised;

        public void RaiseSimpleEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}
