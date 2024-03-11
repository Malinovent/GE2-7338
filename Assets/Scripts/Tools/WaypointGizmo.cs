using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour
{
    [SerializeField] private float gizmoRadius = 0.5f;
    [SerializeField] private float minimumWaypointHeight = 2;

    public void SendToGroud()
    {
        Debug.Log("Send to ground");
    }
    
    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, minimumWaypointHeight))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
        
        Gizmos.DrawSphere(this.transform.position, gizmoRadius);
        
        Gizmos.color = Color.black;
        Gizmos.DrawLine(this.transform.position, transform.position + Vector3.down * minimumWaypointHeight);
    }
    #endregion

}
