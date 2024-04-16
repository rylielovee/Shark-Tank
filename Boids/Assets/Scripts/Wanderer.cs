using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime, wanderRadius;

    // this method was created in parent class but each child class has to implement it separately
    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius);

        Vector3 boundsForce = StayInBounds();

        return wanderForce + boundsForce;
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
