using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{
    public float Health; //Bow
    public Transform target;//set target from inspector instead of looking in Update
    public float speed;
    public float distance;
    public float agroRange;
    public GameObject deathEffect;
    public GameObject impactEffect;

    void Start()
    {

    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > distance)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject); //destroy self
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Arrow Collision (makes sure it was hit with an enemy arrow)
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            ArrowScript arrowScript = collision.GetComponent<ArrowScript>();

            Health -= arrowScript.damage;
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(arrowScript.gameObject);
        }
    }

}
