using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float speedBonus = 3f;

    private LevelGenerator lg;

    void Start()
    {
        lg = FindFirstObjectByType<LevelGenerator>();
    }
    
    protected override void OnPickup()
    {
        lg.UpdateChunkMoveSpeed(speedBonus);
        Destroy(gameObject);
    }
}