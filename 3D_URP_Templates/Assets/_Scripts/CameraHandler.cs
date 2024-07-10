using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace sarbajit.icat
{
    //public class MyCams
    //{
    //    public string Name;
    //    public CinemachineVirtualCameraBase VCam;
    //    public int Priority;

    //    public MyCams(CinemachineVirtualCamera cam, int priority)
    //    {
    //        VCam = cam;
    //        Priority = priority;
    //        Name = cam.Name;
    //    }
    //}

    [System.Serializable]
    public class MyCam
    {
        public string Name;
        [SerializeField]
        private CinemachineVirtualCameraBase VCam;
        [SerializeField]
        private int Priority;

        public MyCam(CinemachineVirtualCamera cam, int priority)
        {
            VCam = cam;
            Priority = priority;
            Name = cam.Name;
        }

        public void SetName()
        {
            if (Name != VCam.name)
            {
                Name = VCam.name;
            }
        }
    }

    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private List<MyCam> _cameras;
        [SerializeField] private List<CinemachineVirtualCamera> _allCameras;
        [SerializeField] private bool _loaded = false;
        public int CamCount => _allCameras.Count;

        public void Setup()
        {
            _cameras.Clear();
            int index = 0;

            foreach (var cam in _allCameras)
            {
                _cameras.Add(new MyCam(cam, index));
                cam.Priority = index;
                index++;
            }

            _allCameras.Clear();
            _loaded = true;
        }
    }
}
