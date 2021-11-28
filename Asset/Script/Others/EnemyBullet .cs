using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public float speed=1;


    public static EnemyBullet instance;

    private void Start()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
   
    

}
