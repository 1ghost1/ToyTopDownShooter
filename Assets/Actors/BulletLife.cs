using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{

    //public static Object Instantiate(this Object myself, Object original, Vector3 position, Quaternion rotation, Transform parent, Vector3 destinationPosition)

    private Vector3 destination;
    private bool flying = false;
    private GameObject owner;
    private bool targetReached = false;
    [SerializeField] private int damage = 2;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void BulletFired(Vector3 destination, GameObject owner)
    {

        Debug.Log(destination);
        this.destination = destination;
        flying = true;
        this.owner = owner;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I collided");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.LogWarning(collider.gameObject.tag);

        if (collider.gameObject.tag == "Killable" && owner.tag != "Killable")
        {
            Debug.LogWarning("Hit killable");
            // If killable that means have EnemyActivity component within it
            collider.gameObject.GetComponent<EnemyActivity>().TakeDamage(damage);

        }

    }


    // Update is called once per frame
    void Update()
    {
       // Debug.LogWarning(Vector2.Distance(transform.position, destination));
        if (Vector2.Distance(transform.position, destination) != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, 10 * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }




    }

}