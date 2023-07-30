using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private float sewerHeight;


    void Start()
    {
        sewerHeight = GetComponent<BoxCollider2D>().size.y;
    }


    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

        if (transform.position.y <= -sewerHeight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2 * sewerHeight);
        }
    }
}
