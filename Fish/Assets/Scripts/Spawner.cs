using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelayObstacle;
    [SerializeField] private float spawnDelayFishFeed;
    [SerializeField] private float spawnDelayHeart;

    private float maxXPos;
    private float obstacleTimer = 0.0f;
    private float fishFeedTimer = 0.0f;
    private float heartTimer = 0.0f;
    private float randomX;


    void Start()
    {
        maxXPos = -GameManager.bottomLeft.x - 0.75f;
    }


    void Update()
    {

        SpawnObstacle();
        SpawnFishFeed();
        SpawnHeart();

    }

    void SpawnObstacle()
    {
        obstacleTimer += Time.deltaTime;

        if (obstacleTimer >= spawnDelayObstacle && !GameManager.isGameOver)
        {
            GameObject obstacle = ObjectPool.instance.GetPooledObstacle();
            if (obstacle != null)
            {
                randomX = Random.Range(-maxXPos, maxXPos);
                obstacle.transform.position = new Vector2(randomX, transform.position.y);
                obstacle.SetActive(true);
            }

            obstacleTimer = 0.0f;
        }
    }

    void SpawnFishFeed()
    {
        fishFeedTimer += Time.deltaTime;

        if (fishFeedTimer >= spawnDelayFishFeed && !GameManager.isGameOver)
        {
            GameObject fishFeed = ObjectPool.instance.GetPooledFishFeed();
            if (fishFeed != null)
            {
                randomX = Random.Range(-maxXPos, maxXPos);
                fishFeed.transform.position = new Vector2(randomX, transform.position.y);
                fishFeed.SetActive(true);
            }

            fishFeedTimer = 0.0f;
        }
    }

    void SpawnHeart()
    {
        heartTimer += Time.deltaTime;

        if (heartTimer >= spawnDelayHeart && GameManager.heart < 4 && !GameManager.isGameOver)
        {
            GameObject heart = ObjectPool.instance.GetPooledHeart();
            if (heart != null)
            {
                randomX = Random.Range(-maxXPos, maxXPos);
                heart.transform.position = new Vector2(randomX, transform.position.y);
                heart.SetActive(true);
            }

            heartTimer = 0.0f;
        }

    }

}
