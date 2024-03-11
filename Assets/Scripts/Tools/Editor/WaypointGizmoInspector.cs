using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointGizmo))]
public class WaypointGizmoInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        WaypointGizmo waypointGizmo = (WaypointGizmo)target;
        
        
        if(GUILayout.Button("Send to Ground"))
        {
            waypointGizmo.SendToGroud();
        }
    }
}
