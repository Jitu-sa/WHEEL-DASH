using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 200f;
    Rigidbody2D rb;
    float spawnx, spawny;

    void Start()
    {
        CheckPointStart();
    }

    void CheckPointStart()
    {
        spawnx = PlayerPrefs.GetFloat("SpawnX", spawnx);
        spawny = PlayerPrefs.GetFloat("SpawnY", spawny);
        transform.position = new Vector3(spawnx, spawny+5, 0);
        rb = GetComponent<Rigidbody2D>();
        print(spawnx);
        print(spawny);
    }

    void Update()
    {
        Torque();
        GameOver();
    }

    void GameOver()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
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
