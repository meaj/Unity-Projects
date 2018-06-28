using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject zombieType;
    public GameManager manager;
    public GameObject player;
    public int spawnerLives;
    public int spawnLevel;
    public float spawnTime = 3f;
    private int spawnCount;
    private int cLevel;
    

    // Use this for initialization
    void Start () {
        cLevel = manager.GetLevel();
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        StartLevel();
        transform.position = new Vector3(Random.Range(113, 425), 5, Random.Range(97, 415));
	}

    // Update is called once per frame
    private void Update()
    {
        if (manager.GetPaused() == false)
        {
            if (spawnerLives < 0)
                Destroy(gameObject);

            if (manager.GetLevel() != cLevel)
            {
                cLevel = manager.GetLevel();
                StartLevel();
            }
            // needs to wait for spawnTime before executing conditional
            if (spawnCount > 0)
            {
                spawnCount--;
                Invoke("Spawn", spawnTime);
            }
        }
    }

    public void TakeDamage(int dam) {
        spawnerLives -= dam;
    }

    void StartLevel() {
        if (cLevel >= spawnLevel)
        {
            spawnCount = 10 + (cLevel - spawnLevel) * 5;
            print("Spawn count: " + spawnCount);
            manager.AddKillCount(spawnCount);
        }
    }

    void Spawn() {
        //Spawn if appropriate level reached and player has lives
        if (cLevel >= spawnLevel && manager.GetLives() > 0) {
            //generate spawn point within 10m of this objects
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 0.2f, transform.position.z + Random.Range(-10, 10));
            GameObject enemy = Instantiate(zombieType, pos, transform.rotation);
            enemy.GetComponent<EnemyManager>().target = player.transform;
            enemy.GetComponent<EnemyManager>().manager = manager;
        }
    }
}
