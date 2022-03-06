using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    GameManager gameManager;
    public void OnClick()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        Debug.Log("RetryButton click!");
        this.gameManager.RetryButton();
    }
}
