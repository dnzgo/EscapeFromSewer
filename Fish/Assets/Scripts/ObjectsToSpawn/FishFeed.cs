using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFeed : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private float obstacleHeight;


    void Start()
    {
        obstacleHeight = GetComponent<CircleCollider2D>().radius * 2;
    }


    void Update()
    {
        float posY = transform.position.y - moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, posY);

        if (transform.position.y < GameManager.bottomLeft.y - obstacleHeight || GameManager.isGameOver)
        {
            gameObject.SetActive(false);
        }

    }
}
