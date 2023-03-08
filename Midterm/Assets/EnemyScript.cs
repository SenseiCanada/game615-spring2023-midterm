using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    NavMeshAgent nma;
    float newPositionTimer = 0;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        newPositionTimer = newPositionTimer - Time.deltaTime;
        if (newPositionTimer < 0)
        {
            newPositionTimer = Random.Range(1, 5);
            Vector3 randomPosition = RandomNavmeshLocation(Random.Range(5, 20));
            nma.SetDestination(randomPosition);
        }
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gm.IncrementEnemyScore();
        }
    }
}
