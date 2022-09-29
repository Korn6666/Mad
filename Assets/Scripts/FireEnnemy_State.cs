using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnnemy_State : MonoBehaviour
{
    

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    
    

    // Start is called before the first frame upsdate
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
