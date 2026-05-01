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
        this.transform.Translate(Vector3.left * pipeMoveSpeed * Time.deltaTime);

        if (this.transform.position.x < minXPosition)
        {
            Destroy(this.gameObject);
        }
    }
}
