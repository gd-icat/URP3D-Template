using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraLook : MonoBehaviour
{
    [SerializeField]
    Vector2 _lookInput = Vector2.zero;
    [SerializeField]
    float _sensitivity = 5.0f;
    Camera _mainCam;
    [SerializeField]
    bool _invertX = false, _invertY = false;
    private void Awake()
    {
        /*Risky with Multiple Cameras, if stacked, better to assign somehow
         * or grab the transform reference directly. Can a require component be used? try. */
        _mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reading input
        _lookInput.x = Input.GetAxisRaw("Mouse X");

        if (_invertX)
        {
            _lookInput.x *= -1.0f;
        }
        
        _lookInput.y = Input.GetAxisRaw("Mouse Y");

        if (_invertY)
        {
            _lookInput.y *= -1.0f;
        }

        ////Constant polling, performance heavy
        //if (_lookInput != Vector2.zero)
        //{
        //    //typical pattern, read from read-only value
        //    Quaternion rotation = _mainCam.transform.rotation;

        //    //modify value
        //    rotation *= Quaternion.AngleAxis(_lookInput.x * _sensitivity, Vector3.up);
        //    rotation *= Quaternion.AngleAxis(_lookInput.y * _sensitivity, Vector3.right);

        //    //write back into read-only value
        //    _mainCam.transform.rotation = rotation;
        //}

        /* Constant polling, performance heavy. Seperated Axis for better control
         * necessary for prototyping. Optimized, but more is possible */
        
        if (_lookInput.x != 0)
        {
            //typical pattern, read from read-only value
            Quaternion hRotation = _mainCam.transform.rotation;

            //modify value
            hRotation *= Quaternion.AngleAxis(_lookInput.x * _sensitivity, Vector3.up);

            //write back into read-only value
            _mainCam.transform.rotation = hRotation;
        }

        ////the simple change to else if, forces EITHER vertical or horizontal Rotation, not both
        //else if (_lookInput.y != 0)
        //{
        //    //typical pattern, read from read-only value
        //    Quaternion vRotation = _mainCam.transform.rotation;

        //    //modify value
        //    vRotation *= Quaternion.AngleAxis(_lookInput.y * _sensitivity, Vector3.right);

        //    //write back into read-only value
        //    _mainCam.transform.rotation = vRotation;
        //}
    }
}
