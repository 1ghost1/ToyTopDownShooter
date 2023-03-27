using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        collider.attachedRigidbody.velocity = Vector2.zero;
        
        Debug.Log(collider.name + " " + collider.attachedRigidbody.velocity);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.attachedRigidbody.velocity = Vector2.zero;
        Debug.Log(collider.name + " " + collider.attachedRigidbody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
