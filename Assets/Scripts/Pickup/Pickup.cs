using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
       transform.Rotate(0, rotationSpeed * Time.deltaTime, 0f);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollisionHandler>() != null)
        {
            OnPickup();
        }
    }

    protected abstract void OnPickup();
}