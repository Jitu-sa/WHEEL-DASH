using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    void Update()
    {
        transform.position=new Vector3(wheel.transform.position.x,wheel.transform.position.y,-5);
    }
}
