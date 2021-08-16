using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyMoveSpeed;
    public Rigidbody rb;
    public Transform target;
    public bool chasing;
    public float distanceTochase, distanceToloose, distannceToStop;
    public NavMeshAgent agent;
    Vector3 startPoint;
    public float keepChasingTime, chasecounter;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < distanceTochase)
            {
                chasing = true;
            }
            if (chasecounter > 0)
            {
                chasecounter -= Time.deltaTime;
                if (chasecounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }


        }
        else
        {

            //transform.LookAt(PlayerController.instance.transform.position);
            //rb.velocity = transform.forward * enemyMoveSpeed;
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distannceToStop)
            {

            }
            agent.destination = PlayerController.instance.transform.position;


            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceTochase)
            {
                chasing = false;
                agent.destination = startPoint;
                chasecounter = keepChasingTime;
            }
        }

    }
}