using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChickenAI : MonoBehaviour
{
   
    NavMeshAgent agent;
    Transform target;
    Animator anime;
    [SerializeField]float chaseRange;
 
internal  ChickenAI Instance;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float playerDamage=0;
    bool isDead;
    public bool canAttack = true;
    [SerializeField] float attackTime = 0.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

    }
    private void Start()
    {
  
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();


    }
    float distance;
    private void Update()
    {
         distance = Vector3.Distance(transform.position, target.position);
        if(distance > chaseRange && !isDead)
        {
            Chasis();
            
        }

        else if(canAttack && !PlayerManager.Instance.isGameOver)
        {
            Attacking();
        }
        else if( PlayerManager.Instance.isGameOver)
        {

            DisableEnemy();
        }

    }

    private void Chasis()
    {

        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        anime.SetBool("isWalking", true);
        anime.SetBool("isAttacking",false);
       
    }

    private void Attacking()
    {
        anime.transform.LookAt(target);
        agent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
        anime.SetBool("isWalking", false);
        anime.SetBool("isAttacking", true);
        
        StartCoroutine(AttackTime());
    }

    private IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
       // PlayerHealth.Instance.DamagePlayer(playerDamage);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }

    void DisableEnemy()
    {
        canAttack = false;
       // anime.SetBool("isWalking", false);
        anime.SetBool("isAttacking", false);
    }
   
    public void enemyDeath()
    {
        isDead = true;
        anime.SetTrigger("isDead");
    }

}