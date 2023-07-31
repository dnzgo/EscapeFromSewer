using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float maxAngle;

    float angle;
    float limitX;
    float fishXSize;

    private void Start()
    {
        limitX = GameManager.bottomLeft.x;
        fishXSize = GetComponent<CapsuleCollider2D>().size.x;
        limitX += fishXSize / 2;
    }

    void Update()
    {
        FishMovement();
        FishRotation();
    }

    void FishMovement()
    {
        float newX = 0;

        if (Input.GetMouseButtonDown(0) || transform.position.x <= limitX || transform.position.x >= -limitX)
        {
            xSpeed *= -1f;
        }
        newX = transform.position.x + xSpeed * Time.deltaTime;
        //newX = Mathf.Clamp(newX, limitX, -limitX);

        Vector2 newPosition = new Vector2(newX, transform.position.y);
        transform.position = newPosition;
    }

    void FishRotation()
    {
        if (xSpeed < 0)
        {
            if (angle <= maxAngle)
            {
                if (transform.rotation.z < -1)
                {
                    angle += .8f;
                }
                else
                {
                    angle += .2f;
                }
            }
        }
        else if (xSpeed > 0)
        {
            if (angle >= -maxAngle)
            {
                if (transform.rotation.z > 1)
                {
                    angle -= .8f;
                }
                else
                {
                    angle -= .2f;
                }
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

}
