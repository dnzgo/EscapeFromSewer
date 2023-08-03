using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;

    private float maxXPos;
    private float timer = 0.0f;
    private float randomX;


    void Start()
    {
        maxXPos = -GameManager.bottomLeft.x - 0.75f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnDelay && !GameManager.isGameOver)
        {
            GameObject obstacle = ObjectPool.instance.GetPooledObject();
            if (obstacle != null)
            {
                randomX = Random.Range(-maxXPos, maxXPos);
                obstacle.transform.position = new Vector2(randomX, transform.position.y);
                obstacle.SetActive(true);
            }

            timer = 0.0f;
        }

    }
}
