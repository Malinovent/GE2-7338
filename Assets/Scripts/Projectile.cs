using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float damage = 10;
    [SerializeField] private float lifeTime = 5;

    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    
    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
        
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
