using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text feedText;
    [SerializeField] TMP_Text heartText;

    public static Vector2 bottomLeft;
    public static float fishYPos = -2.0f;

    public static bool isGameOver = false;

    private static int heart = 5;
    private static int feed = 0;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }


    public void Feed()
    {
        feed++;
        feedText.text = " " + feed;
    }

    public void GainHeart()
    {
        if (heart < 5)
        {
            heart++;
        }
        heartText.text = " " + heart;

    }
    public void LoseHeart(int amount)
    {
        if (heart >= amount)
        {
            heart -= amount;
        }
        else
        {
            heart = 0;
        }
        heartText.text = " " + heart;

        if (heart < 1)
        {
            isGameOver = true;
        }

    }

}
