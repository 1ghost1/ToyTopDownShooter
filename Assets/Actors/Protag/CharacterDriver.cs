using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDriver : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Camera mainCam;
    int colliderNumber = 0;
    private Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Im cracked");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Kek " + colliderNumber);
        colliderNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newMotion = new Vector3();



        if (Input.GetKey(KeyCode.W))
        {
            newMotion.y = 5.0f * Time.deltaTime;

        }


        if (Input.GetKey(KeyCode.S))
        {
            newMotion.y = -(5.0f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {
            newMotion.x = -(5.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            newMotion.x = (5.0f * Time.deltaTime);
        }
        transform.Translate(newMotion.x, newMotion.y, newMotion.z);
        //rigidBody.velocity = newMotion * 200;
        // mainCam.transform.position = transform.position;
        mainCam.transform.position = transform.position + new Vector3(0.0f, 0.0f, -3.0f);



        // HANDLE MOUSE 

        var mouse = Input.mousePosition;
        var screenPoint = mainCam.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mouseInWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
            var newBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<BulletLife>().BulletFired(mouseInWorld, this.gameObject);

        }

    }
}
