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
        if(Coin != null){
            Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);
        Instantiate(Coin, transform.position + randomOffset, Quaternion.identity);
        }
        else {
            Debug.LogWarning("Coin prefab is missing");
        }
        
    }
}