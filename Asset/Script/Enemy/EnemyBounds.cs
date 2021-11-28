using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounds : MonoBehaviour
{
    public float bounds = -3.75f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Zombie")
        {
            if (collision.gameObject.transform.position.x <bounds)
            {
                Destroy(collision.gameObject);
            }

        }
    }
}
