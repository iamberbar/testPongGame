using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGameButton : MonoBehaviour
{


    GameManager gameManager;
    public void OnClick()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.gameManager.StartNewGameButton();
    }
}
