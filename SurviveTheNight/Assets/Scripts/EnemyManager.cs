using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {
    public GameManager manager;
    public Transform target;
    private NavMeshAgent agent; // this object's agent
    private Animator anim;
    public int health; // health of the enemy
    public int shambleSpeed; // public speed of enemy
    public int damPlayer; // public damage in lives


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = shambleSpeed;
        anim = GetComponent<Animator>();
    }


    private void Attack()
    {
        if (Vector3.Distance(transform.position, target.position)<6)
        {
            anim.SetBool("attacking", true);
            anim.SetBool("moving", false);
            agent.isStopped = true;
            manager.TakeLife(1);
        }
    }

    public void TakeDamage(int dam) {
        health -= dam;
        if (health <= 0) {
            Die();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetPaused() == false)
        {
            anim.speed = 1;
            agent.isStopped = false;
            agent.destination = target.position;
            if (agent.isStopped == true)
                anim.SetBool("moving", false);
            else
                anim.SetBool("moving", true);
            anim.SetBool("attacking", false);
            Attack();
            //call raycast function to check for player collision
        }
        else {
            agent.isStopped = true;
            anim.speed = 0;
        }
    }

    void Die() {
        manager.AddKill();
        print("Kills to go: " + manager.GetKills());
        anim.SetBool("dead", true);
        Destroy(gameObject);
    }
}
