using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotationSpeed = 10000f; 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Ship"))
        {
            Debug.Log("Coin collided with the ship!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime); 
    }
}
