using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime, wanderRadius, obstacleWeight;

    // this method was created in parent class but each child class has to implement it separately
    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius);

        Vector3 boundsForce = StayInBounds();

        Vector3 avoidForce = AvoidObstacles() * obstacleWeight;

        return wanderForce + boundsForce + avoidForce;
    }

    private void OnDrawGizmos()
    {
        //
        //  Draw safe space box
        //
        Gizmos.color = Color.green;
        Vector3 futurePos = CalcFuturePosition(wanderTime);

        float length = Vector3.Distance(transform.position, futurePos) + physicsObject.radius;

        Vector3 boxSize = new Vector3(physicsObject.radius * 2f, length, 1f);

        Vector3 boxCenter = Vector3.zero;
        boxCenter.y += length / 2f;

        transform.rotation = Quaternion.LookRotation(Vector3.back, physicsObject.Direction);

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(boxCenter, boxSize);
        Gizmos.matrix = Matrix4x4.identity;


        //
        //  Draw lines to found obstacles
        //
        Gizmos.color = Color.yellow;

        foreach (Vector3 pos in foundObstaclePositions)
        {
            Gizmos.DrawLine(transform.position, pos);
        }
    }




    // Drawing Gizmos function
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.magenta;
    //
    //    Vector3 futurePosition = CalcFuturePosition(wanderTime);
    //    Gizmos.DrawWireSphere(futurePosition, wanderRadius);
    //
    //    Gizmos.color = Color.cyan;
    //    float randAngle = Random.Range(0f, Mathf.PI * 2f);
    //
    //    Vector3 wanderTarget = futurePosition;
    //
    //    wanderTarget.x += Mathf.Cos(randAngle) * wanderRadius;
    //    wanderTarget.y += Mathf.Sin(randAngle) * wanderRadius;
    //
    //    Gizmos.DrawLine(transform.position, wanderTarget);
    //
    //
    //
    //
    //    // found obstacle lines
    //
    //    Gizmos.color = Color.yellow;
    //
    //    foreach (Vector3 obPos in foundObstaclePositions)
    //    {
    //        Gizmos.DrawLine(transform.position, obPos);
    //    }
    //}
}
