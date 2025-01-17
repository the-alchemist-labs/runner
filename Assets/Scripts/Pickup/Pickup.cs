using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollisionHandler>() != null)
        {
            Debug.Log(other.gameObject.name);
        }
    }
}