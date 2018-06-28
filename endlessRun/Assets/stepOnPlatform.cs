using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepOnPlatform : MonoBehaviour {
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.tag.Equals("platform"))
        {
            //other.gameObject.GetComponent<deleteAtDistance>().SetPlayerStepped(true);
        }
    }
}
