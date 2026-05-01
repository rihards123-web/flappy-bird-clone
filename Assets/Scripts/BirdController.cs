using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRigidBody;

    [SerializeField] private float jumpForce;

    private bool shouldJump = false;

    // Update is called once per frame
    void Update()
    {
        isSpacePressed();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    public void Jump()
    {
        if (shouldJump == true)
        {
            birdRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            shouldJump = false;
        }
    }

    private void isSpacePressed()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
             shouldJump = true;
        }
    }
}
