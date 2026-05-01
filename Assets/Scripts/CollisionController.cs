using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TopPipe" || collision.gameObject.name == "BottomPipe")
        {
            hasCollided = true;
        }

        else
        {
            hasCollided = false;
        }
    }
}
