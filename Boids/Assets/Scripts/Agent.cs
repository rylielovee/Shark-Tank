using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    //[SerializeField]
    //public AgentManager agentManager;

    [SerializeField]
    protected PhysicsObject physicsObject;

    //[SerializeField]
    //protected Obstacle obstacle;

    protected Vector3 totalForces = Vector3.zero;

    [SerializeField]
    float maxForce = 5f;

    [SerializeField]
    float maxDistance = 1.0f;

    float randAngle;

    // list of all positions of obstacles agent has found (each agent has there own list
    protected List<Vector3> foundObstaclePositions = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        randAngle = Random.Range(0f, Mathf.PI * 2f);

        //Debug.Log(AgentManager.Instance.agents.Count);
    }

    // Update is called once per frame
    void Update()
    {
        // parent class does not care what the function does, that depends on code in child class
        totalForces += CalculateSteeringForces();

        totalForces = Vector3.ClampMagnitude(totalForces, maxForce);

        physicsObject.ApplyForce(totalForces);

        totalForces = Vector3.zero;
    }


    // abstract method = you implement the function in each child class
    protected abstract Vector3 CalculateSteeringForces();


    public Vector3 Seek(Vector3 targetPos)
    {
        // Seek is a - b vector subraction for desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;  // Calculate desired velocity

        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;  // Set desired = max speed

        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;  // Calculate seek steering force

        return seekingForce;  // Return seek steering force
    }

    // overrides function above to make it easier in seeker script
    public Vector3 Seek(Agent target)
    {
        return Seek(target.transform.position);
    }

    public Vector3 Flee(Vector3 targetPos)
    {
        // Flee is b - a vector subtraction for desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;  // Calculate desired velocity

        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;  // Set desired = max speed

        Vector3 fleeingForce = desiredVelocity - physicsObject.Velocity;  // Calculate flee steering force

        return fleeingForce;  // Return flee steering force
    }

    // overrides function above to make it easier in fleer script
    public Vector3 Flee(Agent target)
    {
        return Flee(target.transform.position);
    }


    // Evade calculates fleeing from a future position vs. flee is just fleeing in the opposite direction
    public Vector3 Evade(Agent target)
    {
        return Flee(target.CalcFuturePosition(5f));
    }


    // picks a somewhat random point to put into Seek() function to look like wandering
    public Vector3 Wander(float time, float radius)
    {
        Vector3 futurePosition = CalcFuturePosition(time);

        randAngle += Random.Range(-0.3f, 0.3f);   // want in radians for later

        Vector3 wanderTarget = futurePosition;  // set wanderTarget to future position to make it easier later

        wanderTarget.x += Mathf.Cos(randAngle) * radius;
        wanderTarget.y += Mathf.Sin(randAngle) * radius;

        return Seek(wanderTarget);
    }


    // Separation
    public Vector3 Separation(List<Agent> agents)
    {
        Vector3 separationForce = Vector3.zero;

        foreach (Agent agent in agents)
        {
            float distance = Vector3.Distance(transform.position, agent.transform.position);  //find distance between agent and neighbors

            if (distance < maxDistance && agent != this)
            {
                separationForce = Flee(agent);
            }
        }
        return separationForce;
    }


    // avoid obstacles
    public Vector3 AvoidObstacles()
    {
        foundObstaclePositions.Clear();

        Vector3 steeringForce = Vector3.zero;

        Vector3 directionToObstacle = Vector3.zero;

        float forwardDot, rightDot;

        foreach (Obstacle obstacle in AgentManager.Instance.obstacles)
        {
            directionToObstacle = obstacle.transform.position - transform.position;

            // calc foward and right dot products
            forwardDot = Vector3.Dot(physicsObject.Direction, directionToObstacle);
            rightDot = Vector3.Dot(transform.right, directionToObstacle);

            // calc safe distance
            float safeDis = 2f + obstacle.radius;

            // if obstacle is in front and within safe distance
            if (forwardDot > 0f && forwardDot < safeDis)
            {   
                // if obstacle is within side bounds
                if (Mathf.Abs(rightDot) < obstacle.radius + physicsObject.radius)
                {
                    // Found something to avoid
                    foundObstaclePositions.Add(obstacle.transform.position);

                    // calc desired velocity
                    Vector3 desiredVelocity = transform.right * -Mathf.Sign(rightDot) * physicsObject.MaxSpeed;

                    // calc steering force
                    steeringForce += desiredVelocity - physicsObject.Velocity;
                }
            }
        }
        return steeringForce;
    }

    // stay in bounds of screen function
    public Vector3 StayInBounds()
    {
        Vector3 steeringForce = Vector3.zero;

        if (CheckIfInBounds(transform.position))
        {
            steeringForce += Seek(Vector3.zero);
        }

        return steeringForce;
    }


    // calculates the future position of agent
    public Vector3 CalcFuturePosition(float futureTime)
    {
        return transform.position + (physicsObject.Velocity * futureTime);  // returns a world point because of the transform.position
    }


    // checks if agent is in bounds for stay in bounds function
    protected bool CheckIfInBounds(Vector3 position)
    {
        if (position.x > AgentManager.Instance.ScreenSize.x ||
            position.x < -AgentManager.Instance.ScreenSize.x ||
            position.y > AgentManager.Instance.ScreenSize.y ||
            position.y < -AgentManager.Instance.ScreenSize.y)
        {
            return true;
        }

        return false;
    }
}
