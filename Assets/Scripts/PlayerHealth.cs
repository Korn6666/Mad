using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float incibilityTime = 3f;
    public float invicibilityFlashDelay = 0.15f;
    public bool isInvicible = false;

    public GameObject Player;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

        if ( currentHealth <= 0 )
        {
            Destroy(Player);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(InvicibiltyFlash());
            StartCoroutine(HandleInvicibiltyDelay());
            

        }

    }

    public IEnumerator InvicibiltyFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 0f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 0f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
        graphics.color = new Color(1f, 1f, 1f, 1f);
    }

    public IEnumerator HandleInvicibiltyDelay()
    {
        yield return new WaitForSeconds(incibilityTime);
        isInvicible = false;
    }

    
}
