using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] float maxRotationSpeed = 300f;
    [SerializeField] float acceleration = 20f; 
    [SerializeField] float moveForce = 2.5f;
    [SerializeField] float currentRotationSpeed = 0f; 
    float inputDirection = 0f;
    [SerializeField] float friction = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        WheelRotating();
    }

    void FixedUpdate()
    {
        WheelForce();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="dirt")
        {
            rb.sharedMaterial.friction = 1;
            friction = 1;
        }

        else if (collision.gameObject.tag=="sand") 
        {
            rb.sharedMaterial.friction = 0;
            friction = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        friction = 0;
    }

    void WheelRotating()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            inputDirection = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            inputDirection = -1f;
        else
            inputDirection = 0f;

        if (inputDirection != 0)
        {
            currentRotationSpeed += inputDirection * acceleration * Time.deltaTime;
            currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, -maxRotationSpeed, maxRotationSpeed);
        }
        else
        {
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, Time.deltaTime * 100);
        }

        transform.Rotate(0, 0, -currentRotationSpeed * Time.deltaTime);
    }

    void WheelForce()
    {
        float forwardMovement = currentRotationSpeed * moveForce *friction* Time.fixedDeltaTime;
        rb.AddForce(new Vector2(forwardMovement, 0), ForceMode2D.Force);
    }
}
