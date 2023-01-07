using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool isGameStarted;
    public static bool isBallActive;
    public static int score;
    public static int highScore = 0;

    [SerializeField] private GameObject ball;
    private AudioSource sounds;
    public AudioClip ballSound;

    private void Start()
    {
        sounds = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        //to Save high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score",highScore);
            PlayerPrefs.Save();
        }
        
        //to Start Game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameStarted = true;
        }

        //to Finish Game
        if (ball.transform.position.y < 0.7f)
        {
            isGameStarted = false;
            isBallActive = false;
            //to Restart Game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                score = -1;
            }
        }
        else
        {
            isBallActive = true;
        }
        Score();
    }
    void Score()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            if (UIManager.isSoundsOpen)
                sounds.PlayOneShot(ballSound);
        }
    }
}
