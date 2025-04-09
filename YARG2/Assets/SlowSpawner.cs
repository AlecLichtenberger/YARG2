using UnityEngine;

public class SlowSpawner : MonoBehaviour
{
    public GameObject Coin;           // Assign your coin prefab (must have Rigidbody & Collider)
    public float spawnRate = 1f;            // Coins per second

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 1f / spawnRate)
        {
            SpawnCoin();
            spawnTimer = 0f;
        }
    }

    void SpawnCoin()
    {
        Instantiate(Coin, transform.position, Quaternion.identity);
    }
}