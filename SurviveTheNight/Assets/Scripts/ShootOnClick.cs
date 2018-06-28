using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnClick : MonoBehaviour {
    public GameManager manager;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Ray bulletRay = new Ray(transform.position+transform.up*0.75f, Vector3.forward);
        float distance;
        Vector3 forward = transform.TransformDirection(Vector3.forward*100);

        Debug.DrawRay(transform.position, forward, Color.red);
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (manager.GetAmmo() > 0 && manager.weapon[manager.GetDamage()-1] == true && manager.GetPaused() == false)
            {
                print("Shot fired!");
                if (Physics.Raycast(transform.position, forward, out hit))
                {
                    manager.playShot(manager.GetDamage());
                    distance = hit.distance;
                    if (hit.collider.tag == "Enemy")
                    {
                        print("Hit enemy " + hit.collider.gameObject.name + " at " + distance + "m away!");
                        EnemyManager enemy = hit.collider.GetComponent<EnemyManager>();
                        // TODO: impart damage depending on current weapon
                        enemy.TakeDamage(manager.GetDamage());
                    }
                    if (hit.collider.tag == "Barrel")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    if (hit.collider.tag == "Spawner")
                    {
                        ZombieSpawner spawn = hit.collider.GetComponent<ZombieSpawner>();
                        spawn.TakeDamage(manager.GetDamage());
                    }
                    manager.UseAmmo();
                    print(manager.GetAmmo() + " shots left!");
                }
            }
            else {
                if(manager.GetAmmo() == 0)
                    print("Out of ammo!");
                if (manager.weapon[manager.GetDamage() - 1] == false)
                    print("Weapon " + manager.GetDamage() + " not equipped!");
                if (manager.GetPaused() == true)
                    print("Game Paused!");
            }
        }
    }
}
