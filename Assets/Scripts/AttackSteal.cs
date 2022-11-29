using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSteal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    bool firstEnnemyDestroyd = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackStealMan(string EnnemyTag)
    {
        if (firstEnnemyDestroyd == false)
        {
            if (EnnemyTag == "Enemy")
            {
                Player.GetComponent<PlayerCombatController>().FireEnable = true;
            }
        }
        firstEnnemyDestroyd = true;

    }
}
