using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace sarbajit.icat
{
    [CustomEditor(typeof(CameraHandler))]
    public class CameraHandlerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CameraHandler camHandler = (CameraHandler)target;
            base.OnInspectorGUI();

            EditorGUILayout.Space(8);

            if (camHandler.CamCount > 0)
            {
                if (GUILayout.Button("Load Cameras"))
                {
                    camHandler.Setup();
                }
            }
        }
    }
}
