using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.Instance.GameOver(); // setting isGameOver state to true.
        }
    }
}
