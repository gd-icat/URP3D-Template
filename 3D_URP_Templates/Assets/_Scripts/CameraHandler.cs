using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace sarbajit.icat
{
    [System.Serializable]
    public class MyCam
    {
        public string Name;
        public CinemachineVirtualCameraBase VCam;
        public int CamPriority;

        public MyCam(CinemachineVirtualCamera cam, int priority)
        {
            VCam = cam;
            CamPriority = priority;
            Name = cam.Name;
        }

        public void SetName()
        {
            if (Name != VCam.name)
            {
                Name = VCam.name;
            }
        }

        public void SetValues(int priority)
        {
            CamPriority = priority;
            VCam.Priority = CamPriority;
        }
    }

    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private List<MyCam> _cameras;
        [SerializeField] private bool _loaded = false;
        public int CamCount => _cameras.Count;
        [SerializeField]
        private int _lastCount, _lastIndex;
        //Called from editor script
        public void Setup()
        {
            if (!_loaded)
            {
                if (_cameras.Count > 0)
                {
                    foreach (var cam in _cameras)
                    {
                        cam?.SetName();
                        cam.VCam.Priority = cam.CamPriority;
                    }

                    Debug.Log(_cameras.Count + " Cams loaded");
                    _lastCount = _cameras.Count;
                    _loaded = true;
                }
            }
        }

        public void CheckLoaded()
        {
            if (_lastCount < _cameras.Count)
            {
                _loaded = false;
            }
        }

        public void SwitchCamNext(int index)
        {
            if (_cameras[index] != null || _cameras[index + 1] != null)
            {
                (_cameras[index + 1].VCam.Priority, _cameras[index].VCam.Priority) = (_cameras[index].VCam.Priority, _cameras[index + 1].VCam.Priority);
            }

            _lastIndex = index;
        }

        public void SwitchCamPrevious()
        {
            if (_cameras[_lastIndex] != null || _cameras[_lastIndex - 1] != null)
            {
                (_cameras[_lastIndex + 1].VCam.Priority, _cameras[_lastIndex].VCam.Priority) = (_cameras[_lastIndex].VCam.Priority, _cameras[_lastIndex + 1].VCam.Priority);
            }
        }
    }
}
