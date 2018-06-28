using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {
    public GameManager manager;
    public int ammoCapacity;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.Range(113, 425), 5, Random.Range(97, 415));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.AddAmmo(ammoCapacity);
            print("Got " + ammoCapacity + " ammo!");
            GameObject.Instantiate<AmmoPickup>(this);
            Destroy(gameObject);
        }
    }
}
