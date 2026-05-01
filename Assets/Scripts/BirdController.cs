using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRigidBody;

    [SerializeField] private float jumpForce;

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    public void Jump()
    {
        if (Keyboard.current.spaceKey.isPressed) {
            birdRigidBody.AddForce(transform.up * jumpForce);
        }
    }
}
