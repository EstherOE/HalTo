using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public  int enemyHealth = 100;
    internal EnemyHealth Instance;
    ChickenAI AI;
    public bool isEnemyDead;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

    }
    private void Start()
    {
        AI = GetComponent<ChickenAI>(); 
    }
    
    public void KillEnemy(int deductAmt)
    {

      if(!isEnemyDead)
        {

            enemyHealth -= deductAmt;

            if (enemyHealth <= 0)
            {
                Dead();
            }
        }

    }

   void Dead()
    {
        isEnemyDead = true;
        AI.Instance.enemyDeath();
        Destroy(gameObject,5);
        
    }
}
