using System;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
   [SerializeField] private AudioSource sound;
   [SerializeField] private float shakeModifier = 10f;
   [SerializeField] private ParticleSystem collisionParticles;
   [SerializeField] private CinemachineImpulseSource impulseSource;
   [SerializeField] private float collisionCooldown = 1f;

   private float _collisionTimer = 1f;
   void Update()
   {
      _collisionTimer += Time.deltaTime;
   }
   
   private void OnCollisionEnter(Collision other)
   {
      if (_collisionTimer < collisionCooldown) return;
      FireImpulse();
      CollisionFX(other);
      _collisionTimer = 0f;
   }

   private void FireImpulse()
   {
      float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
      float shakeIntensity = Mathf.Min(1f / distance * shakeModifier, 1f);
      impulseSource.GenerateImpulse(shakeIntensity);
   }

   private void CollisionFX(Collision other)
   {
      ContactPoint contact = other.contacts[0];
      collisionParticles.transform.position = contact.point;
      collisionParticles.Play();
      sound.Play();
   }
}
