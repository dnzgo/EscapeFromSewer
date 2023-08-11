using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject fishFeedPrefab;
    [SerializeField] private GameObject heartPrefab;

    public static ObjectPool instance;

    private List<GameObject> pooledObstacle = new List<GameObject>();
    private List<GameObject> pooledFishFeed = new List<GameObject>();
    private GameObject pooledHeart;

    private int randomObstacleIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            for (int j = 0; j < (i * 3 + 1); j++)
            {
                GameObject obstacle = Instantiate(obstaclePrefabs[i]);
                obstacle.SetActive(false);
                pooledObstacle.Add(obstacle);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject fishFeed = Instantiate(fishFeedPrefab);
            fishFeed.SetActive(false);
            pooledFishFeed.Add(fishFeed);
        }

        GameObject heart = Instantiate(heartPrefab);
        heart.SetActive(false);
        pooledHeart = heart;

    }

    public GameObject GetPooledObstacle()
    {
        for (int i = 0; i < pooledObstacle.Count; i++)
        {
            randomObstacleIndex = Random.Range(0, pooledObstacle.Count);

            if (!pooledObstacle[randomObstacleIndex].activeInHierarchy)
            {
                return pooledObstacle[randomObstacleIndex];
            }
        }

        return null;
    }

    public GameObject GetPooledFishFeed()
    {
        for (int i = 0; i < pooledFishFeed.Count; i++)
        {
            if (!pooledFishFeed[i].activeInHierarchy)
            {
                return pooledFishFeed[i];
            }
        }

        return null;
    }

    public GameObject GetPooledHeart()
    {
        if (!pooledHeart.activeInHierarchy)
        {
            return pooledHeart;
        }
        return null;
    }

}
