using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AgentManager : Singleton<AgentManager>
{
    public enum FishTypes   // enums make it easier to read in code but are really just an int
    {
        OrangeFish,
        PurpleFish,
        AquaFish,
        RedFish
    }

    [SerializeField]
    Agent fishAgent;

    [SerializeField]
    SpriteRenderer fishAgentSpriteRenderer;

    [SerializeField]
    List<Sprite> fishAgentSprites;

    [SerializeField]
    Agent sharkAgent;

    [SerializeField]
    Agent jellyfishAgent;

    [SerializeField]
    int spawnCount = 10;

    public List<Agent> agents = new List<Agent>();

    public List<Obstacle> obstacles = new List<Obstacle>();

    Vector2 screenSize = Vector2.zero;

    public Vector2 ScreenSize { get { return screenSize; } }

    // prevent non singleton constructor use
    protected AgentManager() { }

    private void Start()
    {
        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;

        Spawn();
    }


    void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Agent newFish = Instantiate(fishAgent, PickRandomPoint(), Quaternion.identity);
            //agents.Add(Instantiate(fishAgent, PickRandomPoint(), Quaternion.identity));

            fishAgentSpriteRenderer.sprite = fishAgentSprites[(int)PickRandomFish()];
            
            agents.Add(newFish);

            agents.Add(Instantiate(sharkAgent, PickRandomPoint(), Quaternion.identity));
            agents.Add(Instantiate(jellyfishAgent, PickRandomPoint(), Quaternion.identity));
        }
    }


    FishTypes PickRandomFish()
    {
        float randValue = Random.Range(0f, 1f);

        //orange 25%
        if (randValue < .25f)
        {
            return FishTypes.OrangeFish;
        }
        //purple 25%
        else if (randValue < .50f)
        {
            return FishTypes.PurpleFish;
        }
        //aqua 25%
        else if (randValue < .75f)
        {
            return FishTypes.AquaFish;
        }
        //red 25%
        else
        {
            return FishTypes.RedFish;
        }
    }


    Vector2 PickRandomPoint()
    {
        Vector2 randPoint = Vector2.zero;

        randPoint.x = Random.Range(-ScreenSize.x, ScreenSize.x);
        randPoint.y = Random.Range(-ScreenSize.y, ScreenSize.y);

        return randPoint;

    }




}

