using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    float secondsBetweenMinusHealth;  //min number of seconds that player can take damage

    [SerializeField]
    float sharkElapsedTime = 0.0f;

    [SerializeField]
    float jellyfishElapsedTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // scale can't go below 0.2f
        if (AgentManager.Instance.player.transform.localScale.x <= 0.2f ||
                        AgentManager.Instance.player.transform.localScale.y <= 0.2f ||
                        AgentManager.Instance.player.transform.localScale.z <= 0.2f)
        {
            AgentManager.Instance.player.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        FishCollides();

        SharkCollides();

        JellyfishCollides();
    }



    // collision check for fish and player
    public bool FishCircleCollisionCheck(Agent fish)
    {
        float combinedRadius = movementController.mouthRadius + fish.physicsObject.radius;

        float xNum = (AgentManager.Instance.player.transform.position.x + movementController.mouthDistance) - (fish.transform.position.x);
        xNum = Mathf.Pow(xNum, 2);

        float yNum = (AgentManager.Instance.player.transform.position.y) - (fish.transform.position.y);
        yNum = Mathf.Pow(yNum, 2);

        if (Mathf.Sqrt(xNum + yNum) <= combinedRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // runs code if fish collision check is true
    public void FishCollides()
    {
        if (AgentManager.Instance.fishList != null)
        {
            for (int i = AgentManager.Instance.fishList.Count - 1; i >= 0; i--)
            {
                if (FishCircleCollisionCheck(AgentManager.Instance.fishList[i]) == true)
                {
                    Destroy(AgentManager.Instance.fishList[i].gameObject);
                    AgentManager.Instance.fishList.Remove(AgentManager.Instance.fishList[i]);
                    AgentManager.Instance.agents.Remove(AgentManager.Instance.agents[i]);

                    AgentManager.Instance.player.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                    movementController.mouthRadius += 0.01f;

                    if (movementController.mouthDistance >= 0)
                    {
                        movementController.mouthDistance += 0.03f;
                    }
                    else
                    {
                        movementController.mouthDistance -= 0.03f;
                    }

                }
            }
        }
    }

    // collision check for shark and player
    public bool SharkJellyCollisionCheck(Agent agent)
    {
        if (agent.min.x < movementController.max.x &&
            agent.max.x > movementController.min.x &&
            agent.max.y > movementController.min.y &&
            agent.min.y < movementController.max.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // runs code if shark collision check is true
    public void SharkCollides()
    {
        sharkElapsedTime += Time.deltaTime;

        if (AgentManager.Instance.sharkList != null)
        {
            for (int i = AgentManager.Instance.sharkList.Count - 1; i >= 0; i--)
            {
                if (SharkJellyCollisionCheck(AgentManager.Instance.sharkList[i]) == true && sharkElapsedTime > secondsBetweenMinusHealth)
                {
                    sharkElapsedTime = 0.0f;
                    AgentManager.Instance.player.transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f);
                }
            }
        }
    }

    // runs code if jellyfish collision check is true
    public void JellyfishCollides()
    {
        jellyfishElapsedTime += Time.deltaTime;

        if (AgentManager.Instance.jellyfishList != null)
        {
            for (int i = AgentManager.Instance.jellyfishList.Count - 1; i >= 0; i--)
            {
                if (SharkJellyCollisionCheck(AgentManager.Instance.jellyfishList[i]) == true && jellyfishElapsedTime > secondsBetweenMinusHealth)
                {
                    jellyfishElapsedTime = 0.0f;
                    AgentManager.Instance.player.transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f);
                }
            }
        }
    }

}
