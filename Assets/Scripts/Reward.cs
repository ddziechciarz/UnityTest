using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Reward : MonoBehaviour
{
    public int rewardValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.AddScore(rewardValue);
            Destroy(gameObject);
        }
    }
}
