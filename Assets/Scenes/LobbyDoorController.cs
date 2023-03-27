using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyDoorController : MonoBehaviour
{
    [SerializeField] public Scene nextLevel;
    [SerializeField] public int nextLevel1;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("CultistHQ");
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
