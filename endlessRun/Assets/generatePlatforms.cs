using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatforms : MonoBehaviour
{
    public GameObject basePlatform;
    Vector3 currentPosition;
    public float distanceToInstantiate;

    void Awake()
    {

    }

    void Start()
    {
        distanceToInstantiate = 100;
        currentPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Camera.main.transform.position, currentPosition) < distanceToInstantiate)
        {
            Instantiate(basePlatform, currentPosition, transform.rotation);
            currentPosition += new Vector3(Random.Range(-3, 3), Random.Range(-1, 2), Random.Range(14,15));
        }
    }
}
