using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float pipeMoveSpeed;

    [SerializeField] private float minXPosition; // -10 for example


    void Update()
    {
        MovePipe();
    }

    public void MovePipe()
    {
        if (!GameController.Instance.isGameOver)
        {
            // moves pipe to the left, with the speed of 5 unity units per second. 
            this.transform.Translate(Vector3.left * pipeMoveSpeed * Time.deltaTime);

            if (this.transform.position.x < minXPosition)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
