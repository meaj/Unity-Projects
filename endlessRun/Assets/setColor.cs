using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour {
    public Color myColor;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().materials[0].color = myColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
