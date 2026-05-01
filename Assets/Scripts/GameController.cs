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

    public bool isGameOver;

    private float timer;

  

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


    public void GameOver() 
    {
        isGameOver = true;

        if (isGameOver)
        {
            birdRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
}
