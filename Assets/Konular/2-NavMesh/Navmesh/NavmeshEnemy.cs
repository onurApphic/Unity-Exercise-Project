using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class NavmeshEnemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private Transform playerTransform;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject projectile;

    public int health;
    // Patroling 
    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange; // Görüş & Saldırı
    public bool playerIsSightRange, playerInAttackRange;
}
public partial class NavmeshEnemy : MonoBehaviour
{
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerIsSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerIsSightRange && !playerInAttackRange) Patroling();
        if (playerIsSightRange && !playerInAttackRange) ChasePlayer();
        if (playerIsSightRange && playerInAttackRange) AttackPlayer();
    }
}
public partial class NavmeshEnemy : MonoBehaviour
{
    private void Patroling() // devriye
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else if (walkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer() // kovala
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }
    private void AttackPlayer()
    {
        //Make Sure enemy doesn't move
        navMeshAgent.SetDestination(transform.position);
        LookAtThePlayer();
        if (!alreadyAttacked)
        {
            //Attack Code Here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
}
public partial class NavmeshEnemy : MonoBehaviour
{
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
    private void LookAtThePlayer()
    {
        Vector3 directionToFace = playerTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}