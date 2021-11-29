using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletobj;
    internal int currentAmmo;

    public int maxAmmo = 10;
    public int magazineSize=30;

    //USed to damage enemy
    public int damageEnemy = 10;
    EnemyHealth enemyObj;

    public float reloadTime = 2f;
    private bool isReloading;


    Animator anime;
    // Start is called before the first frame update


    private void Start()
    {
        enemyObj=FindObjectOfType<EnemyHealth>();
        anime = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo==0 && magazineSize==0)
        {
            anime.SetBool("isShooting", false);
           
        }
        
        if(currentAmmo ==0 && isReloading)
        {
            StartCoroutine(Reload());

        }

        if (Input.GetKeyDown(KeyCode.X)&& currentAmmo >0)
        {
            Shooting();

        }
    }

    private IEnumerator Reload()
    {
        anime.SetBool("isReloading", true);
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        if(magazineSize >=maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }

        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
    }

    void Shooting()
    {
        Instantiate(bulletobj, bulletPos.position, bulletobj.transform.rotation);
        currentAmmo--;
        enemyObj.Instance.KillEnemy(damageEnemy);

       
        
    }

    
}
    
