using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTheo : MonoBehaviour
{

    public Transform target;
    public float muot;

    Vector3 cam1;

    float lowY;
    // Start is called before the first frame update
    void Start()
    {
        cam1 = transform.position - target.position;

        lowY = transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Camtheo = target.position + cam1;

        transform.position = Vector3.Lerp(transform.position, Camtheo, muot * Time.deltaTime);

        if (transform.position.y < lowY)
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        if (transform.position.y > lowY)

            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        
    }
}
