using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    public GameObject[] lives;

    public void nowLives(int lives)
    {
        setAllHide();
        if (lives > 0)
        {
            for (int i = 0; i < lives; i++)
            {
                this.lives[i].SetActive(true);
            }
        }
    }

    private void setAllHide()
    {
        for (int i = 0; i < this.lives.Length; i++)
        {
            this.lives[i].SetActive(false);
        }
    }


}
