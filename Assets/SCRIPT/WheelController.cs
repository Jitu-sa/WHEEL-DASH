using Unity.VisualScripting;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 200f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Torque();
    }

    void Torque()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount * Time.deltaTime);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="default") 
        {
            rb.sharedMaterial.friction = 2;
            torqueAmount = 200;
            rb.drag = 0;
        }

        else if (collision.gameObject.tag == "slipper")
        {
            rb.sharedMaterial.friction =0;
            torqueAmount= 300;
            rb.drag = 0;
        }

        else if (collision.gameObject.tag == "Gummy")
        {
            rb.sharedMaterial.friction = 5;
            torqueAmount=100;
            rb.drag = 1;
        }
    }

}
