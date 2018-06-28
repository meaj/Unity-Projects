using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAtDistance : MonoBehaviour {
    public float distance;
    //public bool playerStepped;


    private void Start()
    {
        distance = 100;
        //playerStepped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Camera.main.transform.position, transform.position) > distance /*&& playerStepped*/)
        {
            Destroy(this.gameObject);
        }
    }
    /*
    public void SetPlayerStepped(bool step)
    {
        playerStepped = step;
    }*/
}
