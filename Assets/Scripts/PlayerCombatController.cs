using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;
    
    private bool gotInput, isAttacking, isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;

    private Animator anim;

    public bool test = false;

    public bool FireEnable = false;

    public Fire FireScript;

    Vector3 offset = new Vector3(5,0,0);
    public Vector3 ProjectileTarget;

    private void Start()
    {
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
        
    }

    private void CheckCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (combatEnabled)
            {
                //Attempt combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && FireEnable == true)
        {
            ProjectileTarget = transform.position + offset;
            FireScript.Launch_Fire(ProjectileTarget, transform.position);
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            //Perform Attack1
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                CheckAttackHitBox();

            }
        }

        if(Time.time >= lastInputTime + inputTimer)
        {
            //Wait for new input
            gotInput = false;
            isAttacking = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);
        
        foreach (Collider2D collider in detectedObjects)
        {
            test = true;
            collider.transform.SendMessage("Damage", attack1Damage);
            //Instantiate hit particle
        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }


}
