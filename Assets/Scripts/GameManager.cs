using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Player player { get; private set; }
    public Brick[] bricks { get; private set; }
    public ScoreText scoreText { get; private set; }
    public LivesBar livesBar { get; private set; }
    public HoldScreen onHold { get; private set; }
    public Text ScoreText;
    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;

    }



    private void NewGame()
    {
        LoadLevel(this.level);
        for (int i = 0; i < this.bricks.Length; i++)
        {
            this.bricks[i].ResetBrick();
        }

    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.player = FindObjectOfType<Player>();
        this.bricks = FindObjectsOfType<Brick>();
        this.scoreText = FindObjectOfType<ScoreText>();
        this.livesBar = FindObjectOfType<LivesBar>();
        this.onHold = FindObjectOfType<HoldScreen>();
        updateUI();




    }


    private void LoadLevel(int level)
    {
        this.level = level;
        if (level > 2)
        {
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    public void Hit(Brick brick)
    {
        this.score += brick.point;
        scoreText.updateScore("" + this.score);
        if (IsLevelCleared())
        {
            LoadLevel(++this.level);
        }
    }

    public void OutOfBound()
    {
        this.lives--;
        this.livesBar.nowLives(this.lives);
        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    private void ResetLevel()
    {
        this.onHold.showOnHold();
        this.ball.ResetBall();
        this.player.ResetPosition();
        updateUI();

    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private bool IsLevelCleared()
    {


        for (int i = 0; i < this.bricks.Length; i++)
        {

            if (this.bricks[i].gameObject.activeInHierarchy)
            {
                if (this.bricks[i].unbreakable)
                {
                    continue;
                }
                return false;
            }
        }


        return true;

    }


    public void StartButton()
    {
        this.score = 0;
        this.lives = 3;
        this.level = 1;
        NewGame();
    }
    public void RetryButton()
    {
        this.score = 0;
        this.lives = 3;
        NewGame();
    }

    public void StartNewGameButton()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameManager");
    }

    private void updateUI()
    {
        // Debug.Log("call update : lives =" + this.lives + " : score =" + this.score);
        if (this.livesBar != null)
        {
            this.livesBar.nowLives(this.lives);
        }
        if (this.scoreText != null)
        {
            scoreText.updateScore("" + this.score);
        }
    }



}
