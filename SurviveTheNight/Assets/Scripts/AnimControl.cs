using UnityEngine;
using System.Collections;
public class AnimControl : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float movev = Input.GetAxis("Vertical");
        float moveh = Input.GetAxis("Horizontal");
        if (movev == 0 && moveh == 0)
            anim.SetBool("walk", false);
        else
        {
            anim.SetBool("walk", true);
            anim.SetFloat("speedh", moveh);
            anim.SetFloat("speedv", movev);
        }
    }
}
