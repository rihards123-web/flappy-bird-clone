using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }


    [SerializeField] private Vector3 spawnLocation;

    [SerializeField] private GameObject Pipes;

    [SerializeField] private float spawnDelay; // 3.5 seconds.

    // offsets for pipes. 

    [SerializeField] private float minYPossition;
    [SerializeField] private float maxYPossition;

    [SerializeField] private Rigidbody2D birdRigidBody;

    [SerializeField] private GameObject restartGameButton;

    public bool isGameOver;

    private float timer;

    public int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject highScoreContainer;

    private int highScore; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            SpawnPipe();

            timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        if (!isGameOver)
        {
            float randomYOffset = Random.Range(minYPossition, maxYPossition);

            spawnLocation.y = randomYOffset;

            Instantiate(Pipes, spawnLocation, Quaternion.identity);
        }
    }


    public void UpdateScore()
    {
        score += 1;

        scoreText.SetText("" + score);

        SoundController.Instance.BirdGetsScore();
    }

    public void ResetScore()
    {
        score = 0;

        scoreText.SetText("" + score);
    }

    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.SetText("HighScore: " + highScore);

        highScoreContainer.SetActive(true);
    }

    public void GameOver() 
    {
        isGameOver = true;

        if (isGameOver)
        {
            SoundController.Instance.BirdCollidesWithPipe();

            SoundController.Instance.BirdDies();

            birdRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

            restartGameButton.SetActive(true);

            SetHighScore();
        }
    }

    // attached to restart game button in the scene. 
    public void RestartGame()
    {
        restartGameButton.SetActive(false);

        highScoreContainer.SetActive(false);

        birdRigidBody.transform.position = new Vector3(0, 0, 0);

        birdRigidBody.rotation = 0f;

        birdRigidBody.constraints = RigidbodyConstraints2D.None;

        // Find every active object in the current scene that has a PipeController component,
        // then store those PipeController components in an array called existingPipes.

        PipeController[] existingPipes = FindObjectsByType<PipeController>();

        foreach (PipeController pipeController in existingPipes)
        {
            Destroy(pipeController.gameObject);
        }

        timer = 0f;

        ResetScore();

        isGameOver = false;
    }
}
