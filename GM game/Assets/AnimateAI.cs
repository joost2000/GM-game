using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AnimateAI : MonoBehaviour
{
    public AIPath aipath;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal speed", aipath.desiredVelocity.x);
        animator.SetFloat("Vertical speed", aipath.desiredVelocity.y);
        animator.SetFloat("Speed", aipath.maxSpeed);
    }
}
