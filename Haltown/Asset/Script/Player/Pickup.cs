using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{

   public  GameObject pickupObj;
    private void Start()
    {
       
    }

    private void Update()
    {
        StartCoroutine(PickupMethod());
    }

    IEnumerator PickupMethod()
    {
        yield return new WaitForSeconds(40);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Gun.instance.currentAmmo += 20;
            Destroy(this.gameObject);
        }
    }
}

