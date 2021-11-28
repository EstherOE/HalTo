using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybullet : MonoBehaviour
{
    public GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            Instantiate(particles, transform.position, Quaternion.identity);
        }
       
    }
}
