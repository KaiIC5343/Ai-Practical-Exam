using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private GameObject[] ZombieWaypoints;
    private NavMeshAgent agent;
    private GameObject NavDestination;
    private Quaternion Rotation;
    private bool isChasing = false;
    public GameObject chaseTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ZombieWaypoints = GameObject.FindGameObjectsWithTag("Zombiepoint");
        agent = GetComponent<NavMeshAgent>();
        if (agent.destination == null)
        {
            newWaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotation = Quaternion.Euler(0, +90f, 0);
        if(isChasing)
        {
            agent.destination = chaseTarget.transform.position;
        }

        else if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance && !isChasing)
        {
            newWaypoint();
        }

    }

    void newWaypoint()
    {
        var index = Random.Range(0, ZombieWaypoints.Length);
        NavDestination = ZombieWaypoints[index];
        agent.destination = NavDestination.transform.position;
        Debug.Log(ZombieWaypoints[index]);
        Debug.Log(agent.destination);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered");
            chaseTarget = collision.gameObject;
            
        }
      
    }

    
}
