using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistLevelController : MonoBehaviour
{

    [SerializeField] public GameObject[] spawnPoints; // Implies spawn points have component SpawnController
    [SerializeField] public int maxEnemiesOnLevel = 10;
    [SerializeField] public float spawnCoolDownMax = 10.0f;
    [SerializeField] public float spawnCoolDownMin = 4.0f;
    [SerializeField] private List<GameObject> standardEnemies;
    private float currentCoolDown = 10.0f;
    private const float cadaverCleanUpTime = 25.0f;
    private float cadaverCooldown = cadaverCleanUpTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentCoolDown <= 0)
        {
            GameObject newGuy = spawnPoints[Random.Range(0, spawnPoints.Length)].GetComponent<SpawnController>().SpawnGuy();
            standardEnemies.Add(newGuy);
            currentCoolDown = spawnCoolDownMax;
        }

        if (cadaverCleanUpTime <= 0)
        {
            int numberOfCadaversToClean = 0;

            foreach (GameObject badGuy in standardEnemies)
            {
                if (badGuy.GetComponent<EnemyActivity>().dead) numberOfCadaversToClean++;
            }


            if (numberOfCadaversToClean > 0)
            {

                if (numberOfCadaversToClean == 1 || numberOfCadaversToClean == 2)
                {
                    foreach (GameObject badGuy in standardEnemies)
                    {
                        if (badGuy.GetComponent<EnemyActivity>().dead) Destroy(badGuy);

                    }

                }
                else if (numberOfCadaversToClean > 2)
                {
                    numberOfCadaversToClean = Random.Range(1, Mathf.FloorToInt(numberOfCadaversToClean / 2));
                    int cleaned = 0;

                    foreach (GameObject badGuy in standardEnemies)
                    {
                        if (badGuy.GetComponent<EnemyActivity>().dead && cleaned < numberOfCadaversToClean)
                        {
                            Destroy(badGuy);
                            cleaned++;

                        }
                    }
                }


            }

            cadaverCooldown = 10;

        }

        currentCoolDown -= Time.deltaTime;
        cadaverCooldown -= Time.deltaTime;
    }
}
