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
                //Setting GUIStyle for GUI style properties
                GUIStyle style = GUI.skin.button;
                style.fixedWidth = 200;
                style.alignment = TextAnchor.MiddleCenter;

                //Using style and text to create button
                if (GUILayout.Button("Setup Cams", style))
                {
                    //Calling Setup function, TBD event hookup
                    camHandler.CheckLoaded();
                    camHandler.Setup();
                }
            }
        }
    }
}
