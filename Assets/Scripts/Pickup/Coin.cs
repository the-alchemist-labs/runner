using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int coinScore = 100;
    private ScoreManager _sm;

    void Start()
    {
        _sm = FindFirstObjectByType<ScoreManager>();
    }
    protected override void OnPickup()
    {
        _sm.UpdateScore(coinScore);
        Destroy(gameObject);
    }
}
