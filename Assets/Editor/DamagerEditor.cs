using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;


[CustomEditor(typeof(Damager))]
public class DamagerEditor : Editor {
    static BoxBoundsHandle s_BoxBoundsHandle = new BoxBoundsHandle();
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
    }
    private void OnSceneGUI() {
            Damager damager = (Damager)target;
            Matrix4x4 handleMatrix = damager.transform.localToWorldMatrix;
            if (!damager.enabled)
                return;
            handleMatrix.SetRow(0, Vector4.Scale(handleMatrix.GetRow(0), new Vector4(1f, 1f, 0f, 1f)));
            handleMatrix.SetRow(1, Vector4.Scale(handleMatrix.GetRow(1), new Vector4(1f, 1f, 0f, 1f)));
            handleMatrix.SetRow(2, new Vector4(0f, 0f, 1f, damager.transform.position.z));
            using (new Handles.DrawingScope(handleMatrix))
            {
                s_BoxBoundsHandle.center = damager.offset;
                s_BoxBoundsHandle.size = damager.size;

                s_BoxBoundsHandle.SetColor(Color.green);
                EditorGUI.BeginChangeCheck();
                s_BoxBoundsHandle.DrawHandle();
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(damager, "Modify Damager");

                    damager.size = s_BoxBoundsHandle.size;
                    damager.offset = s_BoxBoundsHandle.center;
                }
            }
            
        
    }
}