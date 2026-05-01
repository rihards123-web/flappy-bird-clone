using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Vector3 spawnLocation;

    [SerializeField] private GameObject Pipes;

    [SerializeField] private float spawnDelay; // 3.5 seconds.

    // offsets for pipes. 

    [SerializeField] private float minYPossition;
    [SerializeField] private float maxYPossition;

    [SerializeField] private Rigidbody2D birdRigidBody;

    private bool isGameOver;

    private float timer;

    private CollisionController collisionController;

    private void Awake()
    {
        collisionController = FindAnyObjectByType<CollisionController>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            SpawnPipe();

            timer = 0f;
        }

        GameOver();
    }

    private void SpawnPipe()
    {
        isGameOver = collisionController.hasCollided;

        if (!isGameOver)
        {
            float randomYOffset = Random.Range(minYPossition, maxYPossition);

            spawnLocation.y = randomYOffset;

            Instantiate(Pipes, spawnLocation, Quaternion.identity);
        }
    }


    private void GameOver()
    {
        isGameOver = collisionController.hasCollided;

        if (isGameOver)
        {
            birdRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
