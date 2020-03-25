
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent;
 //  public Transform goal;// if it exist then goes to target, otherwise if waits for a click of the mouse on the area of the Nav Agent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public Transform Flag;
    void Update()
    {
            //if (goal == null) { 

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                        agent.destination = hitInfo.point;
                         Flag.position = hitInfo.point;
                         Flag.gameObject.GetComponent<Animator>().SetBool("active", true);
        }
           // }
            //else {
            //    agent.destination = goal.transform.position;
           // }
        }
}
