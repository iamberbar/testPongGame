using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obZone : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball" || collision.gameObject.name == "PowerBall")
        {
            FindObjectOfType<GameManager>().OutOfBound();

        }
    }
}
