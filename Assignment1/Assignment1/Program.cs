using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 targetposition; 
    public GameObject trail; 
    public float speed; // Speed of movement

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object away along the x-axis
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Instantiate the trail at the current position
        Instantiate(trail, transform.position, Quaternion.identity);
    }
}

