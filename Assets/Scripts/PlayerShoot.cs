using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    private Ray ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Quaternion rotation = Quaternion.identity;
        
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = hit.point - projectileSpawnPoint.position;
            rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            rotation = Quaternion.LookRotation(ray.direction);
        }

        
        Instantiate(projectilePrefab, projectileSpawnPoint.position, rotation);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 1000);
    }
}
