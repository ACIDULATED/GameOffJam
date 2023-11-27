using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera thecamera;
    // Start is called before the first frame update
    void Start()
    {
        thecamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thecamera.transform.position);
    }
}