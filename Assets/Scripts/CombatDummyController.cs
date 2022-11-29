using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    
    public float maxHealth = 20f;
    public AttackSteal AttackStealScript;

    [SerializeField]
    private float currentHealth;

    
    public GameObject Enemy;
    

    private void Start()
    {
        currentHealth = maxHealth;
    }

 

    private void Damage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0.0f)
        {
            //Die
            Die();
        }
    }


    private void Die()
    {
        AttackStealScript.AttackStealMan(transform.parent.gameObject.GetComponent<Collider>().tag);
        Destroy(Enemy);
    }
}
