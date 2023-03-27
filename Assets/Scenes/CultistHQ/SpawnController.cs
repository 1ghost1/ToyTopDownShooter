using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] public GameObject guyToSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject SpawnGuy()
    {
        return (GameObject)Instantiate(guyToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
