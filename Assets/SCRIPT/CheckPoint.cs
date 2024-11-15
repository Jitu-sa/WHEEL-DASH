using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    float spawnx, spawny;
    BoxCollider2D BoxCollider2D;

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Wheel")
        {
            spawnx = transform.position.x;
            spawny = transform.position.y;

            PlayerPrefs.SetFloat("SpawnX", spawnx);
            PlayerPrefs.SetFloat("SpawnY",spawny);

            BoxCollider2D.enabled = false;

            print("Collisson detected");
        }
    }
}
