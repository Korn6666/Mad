using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject ObjectToDestroy;

    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<AttackSteal>().AttackStealMan(transform.parent.gameObject.tag);
            Destroy(ObjectToDestroy);
            playerMovement.rb.AddForce(new Vector2(0f, 500));
        }
    }
}
