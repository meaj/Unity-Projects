using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
    public GameManager manager;
    public int weaponLevel;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(113, 425), 5, Random.Range(97, 415));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (manager.weapon[weaponLevel - 1] == true)
            {
                manager.AddAmmo(weaponLevel * 5);
                print("Got " + weaponLevel * 5 + " ammo!");
                GameObject.Instantiate<WeaponPickup>(this);
                Destroy(gameObject);
            }
            else
            {
                manager.weapon[weaponLevel - 1] = true;
                print("Picked up weapon " + weaponLevel + "!");
                GameObject.Instantiate<WeaponPickup>(this);
                Destroy(gameObject);
            }
        }
    }
}
