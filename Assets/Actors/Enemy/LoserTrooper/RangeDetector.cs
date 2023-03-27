using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{

    public bool PlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
            
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
