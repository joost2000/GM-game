using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public swordPickup swordPickup;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("hasSword", swordPickup.hasSword);
    }
}

