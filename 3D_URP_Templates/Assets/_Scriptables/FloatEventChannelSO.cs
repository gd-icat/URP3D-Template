using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sarbajit.icat
{
    [CreateAssetMenu(menuName = "Event Channels/Numerical", fileName = "NEC_New", order = 1)]
    public class FloatEventChannelSO : EventChannelSOBase<float>
    {
        public override void RaiseSimpleEvent(float signal, float data)
        {
            OnEventRaised += FloatEventChannelSO_OnEventRaised;
        }

        private void FloatEventChannelSO_OnEventRaised(float obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
