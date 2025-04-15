using UnityEngine;

public class ShipContainer : MonoBehaviour
{
    public int coinCount = 0;
    public int maxCoinsBeforeSink = 10;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);

            if (coinCount >= maxCoinsBeforeSink)
            {
                SinkShip();
            }
        }
    }

    void SinkShip()
    {
        if (animator != null)
        {
            animator.SetTrigger("Sink");
        }

        // Optionally disable collider or other visuals
        GetComponent<Collider2D>().enabled = false;
    }
}
