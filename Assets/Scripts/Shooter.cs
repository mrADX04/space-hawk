using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring;

    Coroutine firingCouroutine;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCouroutine == null)
        {
            firingCouroutine = StartCoroutine(FireContinuously());    
        }
        else if (!isFiring && firingCouroutine != null)
        {
            StopCoroutine(firingCouroutine);
            firingCouroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
