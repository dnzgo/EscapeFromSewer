using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coke : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    private float obstacleHeight;
    private float angle;


    void Start()
    {
        obstacleHeight = GetComponent<CapsuleCollider2D>().size.y;
    }


    void Update()
    {
        float posY = transform.position.y - moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, posY);

        angle += moveSpeed * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (transform.position.y < GameManager.bottomLeft.y - obstacleHeight)
        {
            gameObject.SetActive(false);
        }

    }
}
