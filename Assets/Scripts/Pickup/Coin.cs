using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        Destroy(gameObject);
    }
}
