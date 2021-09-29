using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordPickup : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject tooltip;
    public float radius = 10f;

    public bool hasSword = false;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(playerTransform.position, this.transform.position);

        if (distance < radius)
        {
            tooltip.SetActive(true);
        }
        else
        {
            tooltip.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && distance < radius)
        {
            this.gameObject.SetActive(false);
            hasSword = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
