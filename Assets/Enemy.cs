using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float RefRate = 0.25f;

    public int enemydamage = 100;
    public int enemiesDead = 0;
    public float Speed = 10f;

    public event System.Action OnDeath;

    public GameObject EnemyDeadScore;

    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    void Start()
    {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("find player");

        StartCoroutine (UpdatePath());

        //EnemyDeadScore.gameObject = "Enemies Killed:" + enemiesDead;
    }

    void Update()
    {
       
    }

    //Updating path and transform of player coroutine
    IEnumerator UpdatePath()
    {
        Debug.Log("update path");
        float refreshRate = RefRate;

        while (target != null)
        {
            Debug.Log("while position");
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    //Hitting the player
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Debug.Log("Enemy Hit!");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit!");

            FirstPersonMovement health = hit.GetComponent<FirstPersonMovement>();
            if (health != null)
            {
                health.TakeDamage(enemydamage);
            }

            Destroy(gameObject);
        }

       //if (OnDeath != null)
        {
            //OnDeath();
        }
    }
}

