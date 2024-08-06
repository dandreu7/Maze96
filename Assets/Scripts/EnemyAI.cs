using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  //Set to player object
    public AudioSource walking;
    public AudioSource attacking;
    public AudioSource jumpscare;
    public float checkInterval = 20f;  //Default interval for phase change in flaot
    public float maxAggressionLevel = 10f;  //Default max time for enemy to be in attack mode
    public float detectionRange = 10f;  //Enemy detection range
    public float chaseSpeed = 2.5f;
    public float normalSpeed = 1.5f;


    private NavMeshAgent navMeshAgent;
    private float aggressionLevel;
    private float timeSinceStart;
    private bool isAttacking;
    private float checkTimer;


    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        aggressionLevel = 0f;
        isAttacking = false;
        checkTimer = 0f;
        Debug.Log("Phase: Roaming");
        walking.Play();
    }

    void Update() {
        checkTimer += Time.deltaTime;
        timeSinceStart += Time.deltaTime;

        //Check if the player is within detection radius
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            isAttacking = true;
            Debug.Log("Player In Sight");
            attacking.Play();
            navMeshAgent.speed = chaseSpeed;
        }

        //Phase switching
        if (isAttacking) {
            AttackPhase();
        } else {
            RoamingPhase();
        }

        if (checkTimer >= checkInterval) {
            CheckPhaseChange();
            checkTimer = 0f;
        }
    }

    void RoamingPhase() {
        //Roaming phase logic, will move to a random point in the navMesh
        if (!navMeshAgent.hasPath) {
            navMeshAgent.speed = normalSpeed;
            Vector3 randomDirection = Random.insideUnitSphere * 10f; //Pick a random direction
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10f, 1);
            Vector3 finalPosition = hit.position;
            navMeshAgent.SetDestination(finalPosition);
        }
    }
    //TODO: Figure out why attack phase sometimes lasts a super short time even if check interval is high
    void AttackPhase() {
        //Attack Phase logic, will move towards player location
        navMeshAgent.SetDestination(player.position);
        aggressionLevel -= Time.deltaTime;
        if (aggressionLevel <= 0f) {
            isAttacking = false;
            Debug.Log("Phase: Roaming");
        }
    }

    void CheckPhaseChange() {
        //Check if the enemy should enter attack mode
        if (!isAttacking) {
            isAttacking = true;
            aggressionLevel = Mathf.Min(timeSinceStart / 10f, maxAggressionLevel);
            Debug.Log("Phase: Attacking");
        }
    }
    //Enemy gets player resulting in a Game Over
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy touching " + other.name);
        if (other.transform == player)
        {
            Debug.Log("GAME OVER");
            jumpscare.Play();
            StartCoroutine(GameOver());
        }
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(jumpscare.clip.length);
        SceneManager.LoadScene("GameOver");
    }
}

