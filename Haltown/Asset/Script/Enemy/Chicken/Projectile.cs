using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public float radius = 3;
    public int playerHealth = 10;
    private void OnCollisionEnter(Collision collision)
    {

       GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);

        Collider[] obj = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearobj in obj) {

            if(nearobj.tag=="Player")
            {
                StartCoroutine(FindObjectOfType<PlayerManager>().TakeDamage(playerHealth));
            }
        }

        Destroy(gameObject);
    }
}
