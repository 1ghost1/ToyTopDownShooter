using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivity : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;


    private int hitPoints = 4;
    public bool dead = false;
    [SerializeField] private GameObject bloodSplatter;
    [SerializeField] private static float coveredInBloodDuration = 0.2f;
    [SerializeField] private Sprite deadBody;
    private float coveredInBloodRemaining = coveredInBloodDuration;
    private bool coveredInBlood = false;



    [SerializeField] private const float shootCooldown = 3.0f; // get this from editor
    private float currentShootCooldown = shootCooldown; // used in timer
    private bool madeShot = false;



    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject shootingRangeController;
    [SerializeField] private GameObject hearingRangeController;
    [SerializeField] private SpriteRenderer spriteController;


    private bool playerInShootingRange = false;
    private bool alerted = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {



    }

    public void TakeDamage(int incommingDamage)
    {
        if(hitPoints > 0)
        {
            hitPoints -= incommingDamage;
            coveredInBlood = true;
            alerted = true;
            spriteController.color = Color.red;
            Instantiate(bloodSplatter, transform.position, transform.rotation);
        }
        else if (hitPoints <= 0 && !dead)
        {
            dead = true;
            Debug.LogWarning("I just died :(");
            spriteController.color = Color.red;
            spriteController.sprite = deadBody;

        }

        //
    }

    private void UpdateCooldown(float timePassed)
    {
        if(currentShootCooldown > 0)
        {
            currentShootCooldown -= timePassed;
            Debug.Log(currentShootCooldown);
            
        }
        else
        {
            currentShootCooldown = shootCooldown;
            madeShot = false;

        }
    }


    private void ProcessAlertedLogic()
    {
        if (alerted)
        {
            if (playerInShootingRange)
            {

                if (!madeShot)
                {
                    madeShot = true;
                    var player = GameObject.FindGameObjectWithTag("Player");
                    var newBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                    newBullet.GetComponent<BulletLife>().BulletFired(player.transform.position, this.gameObject);
                    Debug.Log("FIRING!");
                }


            }
            else
            {
                Debug.Log("Chasing");
                agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

            }

        }
    }

    private void UpdateCoveredInBlood(float timePassed)
    {
        if(coveredInBloodRemaining > 0)
        {
            coveredInBloodRemaining -= timePassed;
            Debug.Log(coveredInBloodRemaining);
            spriteController.color = Color.red;

        }
        else
        {
            coveredInBloodRemaining = coveredInBloodDuration;
            coveredInBlood = false;
            spriteController.color = Color.white;
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (hearingRangeController.GetComponent<RangeDetector>().PlayerInRange && !alerted) alerted = true;
            if (madeShot) UpdateCooldown(Time.deltaTime);
            if (coveredInBlood) UpdateCoveredInBlood(Time.deltaTime);
            playerInShootingRange = shootingRangeController.GetComponent<RangeDetector>().PlayerInRange;

            ProcessAlertedLogic();
        }
        else
        {

        }




    }
}
