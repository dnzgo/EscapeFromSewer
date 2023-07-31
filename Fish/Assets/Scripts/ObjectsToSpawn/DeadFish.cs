using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFish : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    private float angle;
    private float limitX;
    private float obstacleHeight;
    private float obstacleWeight;


    void Start()
    {
        obstacleHeight = GetComponent<CapsuleCollider2D>().size.y;
        obstacleWeight = GetComponent<CapsuleCollider2D>().size.x;
        limitX = GameManager.bottomLeft.x + obstacleWeight / 2;
    }


    void Update()
    {
        float posY = transform.position.y - moveSpeed * Time.deltaTime;

        if (transform.position.x <= limitX || transform.position.x >= -limitX)
        {
            xSpeed *= -1f;
        }

        float posX = transform.position.x - xSpeed * Time.deltaTime;
        transform.position = new Vector2(posX, posY);

        angle += moveSpeed * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (transform.position.y < GameManager.bottomLeft.y - obstacleHeight)
        {
            gameObject.SetActive(false);
        }

    }
}
