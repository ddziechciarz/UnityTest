using UnityEngine;
using System.Collections.Generic;

public class RewardSpawner : MonoBehaviour
{
    public GameObject rewardPrefab;
    public float spawnInterval = 2f;
    public int maxRewards = 3;
    public Vector2 spawnAreaSize = new Vector2(4f, 4f);

    private List<GameObject> spawnedRewards = new List<GameObject>();
    private float timer;

    void Update()
    {
        // Clean up destroyed rewards
        spawnedRewards.RemoveAll(r => r == null);

        timer += Time.deltaTime;
        if (spawnedRewards.Count < maxRewards && timer >= spawnInterval)
        {
            SpawnReward();
            timer = 0f;
        }
    }

    void SpawnReward()
    {
        Vector2 spawnPos = new Vector2(
            UnityEngine.Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            UnityEngine.Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
        );
        GameObject reward = Instantiate(rewardPrefab, spawnPos, Quaternion.identity);
        spawnedRewards.Add(reward);
    }
}
