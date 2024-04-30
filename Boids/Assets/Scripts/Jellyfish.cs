using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Agent
{
    [SerializeField]
    float wanderTime, wanderRadius;
    
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float wanderWeight, boundsWeight, obstacleWeight, separationWeight;

    void Start()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }

    // this method was created in parent class but each child class has to implement it separately
    protected override Vector3 CalculateSteeringForces()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;

        Vector3 wanderForce = Wander(wanderTime, wanderRadius) * wanderWeight;

        Vector3 boundsForce = StayInBounds() * boundsWeight;

        Vector3 obstacleForce = AvoidObstacles() * obstacleWeight;

        Vector3 separationForce = Separation(AgentManager.Instance.jellyfishList) * separationWeight;

        return wanderForce + boundsForce + obstacleForce + separationForce;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(transform.position, spriteRenderer.bounds.size);

        /*
        Gizmos.color = Color.magenta;

        Vector3 futurePosition = CalcFuturePosition(wanderTime);
        Gizmos.DrawWireSphere(futurePosition, wanderRadius);

        Gizmos.color = Color.cyan;
        float randAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 wanderTarget = futurePosition;

        wanderTarget.x += Mathf.Cos(randAngle) * wanderRadius;
        wanderTarget.y += Mathf.Sin(randAngle) * wanderRadius;

        Gizmos.DrawLine(transform.position, wanderTarget);
        */
    }


}
