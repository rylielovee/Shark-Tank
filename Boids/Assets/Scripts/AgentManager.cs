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

    public GameObject player;

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
    int sharkCount, jellyfishCount, fishCount;

    // agent list
    public List<Agent> agents = new List<Agent>();

    // fish list
    public List<Agent> fishList = new List<Agent>();

    // shark list
    public List<Agent> sharkList = new List<Agent>();

    // jellyfish list
    public List<Agent> jellyfishList = new List<Agent>();

    // obstacle list
    public List<Pufferfish> pufferfishList = new List<Pufferfish>();

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
        // shark spawning
        for (int i = 0; i < sharkCount; i++)
        {
            Agent newShark = Instantiate(sharkAgent, PickRandomPoint(), Quaternion.identity);
            agents.Add(newShark);
            sharkList.Add(newShark);
        }

        // jellyfish spawning
        for (int i = 0; i < jellyfishCount; i++)
        {
            Agent newJellyfish = Instantiate(jellyfishAgent, PickRandomPoint(), Quaternion.identity);
            agents.Add(newJellyfish);
            jellyfishList.Add(newJellyfish);
        }

        // fish spawning
        for (int i = 0; i < fishCount; i++)
        {
            Agent newFish = Instantiate(fishAgent, PickRandomPoint(), Quaternion.identity);
            fishAgentSpriteRenderer.sprite = fishAgentSprites[(int)PickRandomFish()];
            agents.Add(newFish);
            fishList.Add(newFish);
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

