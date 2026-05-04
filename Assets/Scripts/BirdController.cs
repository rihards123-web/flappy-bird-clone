using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdRigidBody;

    [SerializeField] private Transform birdVisual;

    [SerializeField] private float jumpForce;

    [SerializeField] private float maxRotationAngle; // 25

    [SerializeField] private float rotationSpeed;

    [SerializeField] private Quaternion targetAngle;

    private Quaternion currentAngle;

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
            SoundController.Instance.BirdFlapsWing();

            birdRigidBody.linearVelocity = new Vector2(birdRigidBody.linearVelocity.x, 0f);

            birdRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);


            birdVisual.transform.rotation = Quaternion.Euler(0, 0, maxRotationAngle);
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
            currentAngle = birdVisual.transform.rotation;

            birdVisual.transform.rotation = Quaternion.RotateTowards(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        }
    }
}
