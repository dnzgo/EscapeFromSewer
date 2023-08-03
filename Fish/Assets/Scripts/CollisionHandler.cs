using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.LoseHeart();
        }
        else if (collision.CompareTag("Feed"))
        {
            gameManager.Feed();
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Heart"))
        {
            gameManager.GainHeart();
            collision.gameObject.SetActive(false);
        }
    }
}
