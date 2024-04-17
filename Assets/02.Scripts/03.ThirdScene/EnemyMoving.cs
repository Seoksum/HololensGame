using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;
    Animator anim;
    float dis;


    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dis = Vector3.Distance(agent.transform.position, target.transform.position);

        if (Vector3.Distance(agent.transform.position, target.transform.position) < 0.5f)
        {
            anim.SetBool("IsRun", false);
            anim.SetBool("IsAttack", true);
            transform.eulerAngles = new Vector3(0, -150, 0);
        }

    }

    public void OnStartToRun()
    {
        agent.SetDestination(target.position);
        anim.SetBool("IsRun", true);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsAttack", true);
    }
}
