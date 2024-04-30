using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Agent
{
    [SerializeField]
    float wanderTime, wanderRadius;

    [SerializeField]
    float separationWeight, cohesionWeight, alignmentWeight, wanderWeight, fleeWeight, boundsWeight, obstacleWeight;

    // this method was created in parent class but each child class has to implement it separately
    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 separationForce = Separation(AgentManager.Instance.fishList) * separationWeight;

        Vector3 cohesionForce = Cohesion(AgentManager.Instance.fishList) * cohesionWeight;

        Vector3 alignmentForce = Alignment(AgentManager.Instance.fishList) * alignmentWeight;

        Vector3 wanderForce = Wander(wanderTime, wanderRadius) * wanderWeight;

        Vector3 fleeForce = Flee(AgentManager.Instance.player.transform.position) * fleeWeight;

        Vector3 boundsForce = StayInBounds() * boundsWeight;

        if (Vector3.Distance(AgentManager.Instance.player.transform.position, transform.position) < 5)
        {
            return separationForce + cohesionForce + alignmentForce + wanderForce + fleeForce + boundsForce;
        }
        
        return separationForce + cohesionForce + alignmentForce + wanderForce + boundsForce;
    }

    // Drawing Gizmos function
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //
        //if (Vector3.Distance(AgentManager.Instance.player.transform.position, transform.position) < 4)
        //{
        //    Gizmos.DrawLine(AgentManager.Instance.player.transform.position, transform.position);
        //}


        //Gizmos.color = Color.magenta;
        //
        //Vector3 futurePosition = CalcFuturePosition(wanderTime);
        //Gizmos.DrawWireSphere(futurePosition, wanderRadius);
        //
        //Gizmos.color = Color.cyan;
        //float randAngle = Random.Range(0f, Mathf.PI * 2f);
        //
        //Vector3 wanderTarget = futurePosition;
        //
        //wanderTarget.x += Mathf.Cos(randAngle) * wanderRadius;
        //wanderTarget.y += Mathf.Sin(randAngle) * wanderRadius;
        //
        //Gizmos.DrawLine(transform.position, wanderTarget);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, physicsObject.radius);


    }
}
