using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : Agent
{
    [SerializeField]
    float separationWeight = 1f, boundsWeight = 1f, wanderWeight = 1f;

    [SerializeField]
    float wanderTime, wanderRadius;

    // this method was created in parent class but each child class has to implement it separately
    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 separationForce = Separation(AgentManager.Instance.agents) * separationWeight;

        Vector3 wanderForce = Wander(wanderTime, wanderRadius) * wanderWeight;

        Vector3 boundsForce = StayInBounds() * boundsWeight;
    
        return separationForce + boundsForce + wanderForce;
    }

    // Drawing Gizmos function
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Vector3 futurePosition = CalcFuturePosition(wanderTime);
        Gizmos.DrawWireSphere(futurePosition, wanderRadius);

        Gizmos.color = Color.cyan;
        float randAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 wanderTarget = futurePosition;

        wanderTarget.x += Mathf.Cos(randAngle) * wanderRadius;
        wanderTarget.y += Mathf.Sin(randAngle) * wanderRadius;

        Gizmos.DrawLine(transform.position, wanderTarget);
    }
}
