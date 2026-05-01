using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TopPipe" || collision.gameObject.name == "BottomPipe")
        {
            GameController.Instance.GameOver(); // setting isGameOver state to true.
        }
    }
}
