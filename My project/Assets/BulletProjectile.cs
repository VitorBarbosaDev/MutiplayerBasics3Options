using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody _bulletRigidbody;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 10f;
        _bulletRigidbody.velocity = transform.forward *speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>() != null)
        {
            //Hit Target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            //Hit Something Else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);

        }
        Destroy(gameObject);
    }
}
