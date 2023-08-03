using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coke"))
        {
            gameManager.LoseHeart(1);
        }
        else if (collision.CompareTag("DeadFish"))
        {
            gameManager.LoseHeart(2);
        }
        else if (collision.CompareTag("Bomb"))
        {
            gameManager.LoseHeart(4);
        }
        else if (collision.CompareTag("Web"))
        {
            gameManager.LoseHeart(3);
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
