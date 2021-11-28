using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    public float speed = 1;


    public static EnemyB instance;

    private void Start()
    {
        instance = this;

    }
    // Start is called before the first frame update
    public void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


}
