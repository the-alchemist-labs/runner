using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float stumbleCooldown;
    
    private float _cooldownTimer = 0f;

    void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (_cooldownTimer < stumbleCooldown) return;
        animator.SetTrigger("Hit");
        _cooldownTimer = 0f;
    }
}
