using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRigidBody;

    [SerializeField] private float jumpForce;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float targetAngle;

    private float currentAngle;

    private bool shouldJump = false;

    // Update is called once per frame
    void Update()
    {
        isSpacePressed();
        isTouchScreenPressed();
        RotateBird();
    }

    private void FixedUpdate()
    {
        Jump();
        
    }

    private void Jump()
    {
        if (!GameController.Instance.isGameOver && shouldJump == true)
        {
            birdRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            birdRigidBody.rotation = 25f;
            shouldJump = false;
        }  
    }

    private void isSpacePressed()
    {
        if (!GameController.Instance.isGameOver && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            shouldJump = true;
        }
    }

    private void isTouchScreenPressed()
    {
        if (!GameController.Instance.isGameOver && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            shouldJump = true;
        }
    }

    private void RotateBird()
    {
        if (!GameController.Instance.isGameOver)
        {
            currentAngle = birdRigidBody.rotation;
            

            birdRigidBody.rotation = Mathf.MoveTowards(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        }
    }
}
