using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private float timeBtwShots;
    public int startTimeBtwShots = 2;

    public GameObject projectile;
    public Transform player;

    public float DetectionRange = 10;



    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < DetectionRange)
        {
            if (timeBtwShots <= 0)
            {

                Instantiate(projectile, transform.position, Quaternion.identity);

                timeBtwShots = startTimeBtwShots;

            }
            else
            {
                timeBtwShots -= Time.deltaTime;

            }
        }
    }
}