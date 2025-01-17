using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float stumbleCooldown;
    [SerializeField] private float stumblePenaltySpeed = -2f;

    private LevelGenerator lg;
    private float _cooldownTimer = 0f;

    void Start()
    {
        lg = FindFirstObjectByType<LevelGenerator>();
    }
    
    void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (_cooldownTimer < stumbleCooldown) return;
        
        lg.UpdateChunkMoveSpeed(stumblePenaltySpeed);
        animator.SetTrigger("Hit");
        _cooldownTimer = 0f;
    }
}
