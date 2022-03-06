
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText { get; private set; }



    private void Awake()
    {
        this.scoreText = GetComponent<Text>();
    }

    public void updateScore(string text)
    {
        this.scoreText.text = text;
    }
}
