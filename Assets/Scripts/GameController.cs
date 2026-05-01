using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Vector3 spawnLocation;

    [SerializeField] private GameObject Pipes;

    [SerializeField] private float spawnDelay; // 3.5 seconds.

    private float timer;

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
        Instantiate(Pipes, spawnLocation, Quaternion.identity);
    }

}
