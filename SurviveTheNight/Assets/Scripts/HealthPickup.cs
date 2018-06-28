using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
    public GameManager manager;
    public int health;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(Random.Range(113, 425), 5, Random.Range(97, 415));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.GiveLife(health);
            print("Got " + health + " health!");
            GameObject.Instantiate<HealthPickup>(this);
            Destroy(gameObject);
        }
    }
}
