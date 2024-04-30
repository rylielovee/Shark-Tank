using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    public float radius;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite happySprite;

    [SerializeField]
    Sprite madSprite;

    [SerializeField]
    Vector3 min, max;

    [SerializeField]
    float elapsedTime = 0.0f;

    [SerializeField]
    float secondsBetweenMinusHealth;  //min number of seconds that player can take damage

    void Start()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }

    void Update()
    {
        PufferfishCollides();
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }


    public bool PufferfishCollisionCheck(Pufferfish puff)
    {
        if (puff.min.x < movementController.max.x &&
            puff.max.x > movementController.min.x &&
            puff.max.y > movementController.min.y &&
            puff.min.y < movementController.max.y)
        {
            puff.spriteRenderer.sprite = madSprite;
            AgentManager.Instance.player.transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f);
            return true;
        }
        else
        {
            puff.spriteRenderer.sprite = happySprite;
            return false;
        }
    }

    // runs code if pufferfish collision check is true
    public void PufferfishCollides()
    {
        elapsedTime += Time.deltaTime;

        if (AgentManager.Instance.pufferfishList != null)
        {
            for (int i = AgentManager.Instance.pufferfishList.Count - 1; i >= 0; i--)
            {
                if (PufferfishCollisionCheck(AgentManager.Instance.pufferfishList[i]) == true && elapsedTime > secondsBetweenMinusHealth)
                {
                    elapsedTime = 0.0f;
                    AgentManager.Instance.player.transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f);
                }
            }
        }
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    
        Gizmos.DrawWireCube(transform.position, spriteRenderer.bounds.size);
    }
}
