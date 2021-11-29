using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed=1;

   
    public static BulletMovement instance;

    private void Start()
    {
        instance = this;
        count = 0;
       
    }
    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public  static int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Zombie")
        {
                Destroy(gameObject);
            
        }
        if(other.tag == "Chicken")
        {


            Destroy(this.gameObject);
        }
    }

}
