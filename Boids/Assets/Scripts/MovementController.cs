using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    Vector3 objectPosition = Vector3.zero;   // Vector3 with all zeros (0, 0, 0)

    [SerializeField]
    Vector3 direction = Vector3.zero;

    [SerializeField]
    Vector3 velocity = Vector3.zero;     // velocity doesn't make sense outside of update but to debug
                                         // put it here to see in inspector
    [SerializeField]
    float speed;   // whatever speed we put in inspector will override this

    public float mouthRadius;  // when checking for collisions with player mouth and fish

    public float regularRadius;  // when checking for collisions with player and enemies

    public float mouthDistance;

    bool facingRight = true;

    public Vector3 Direction
    {
        set { direction = value.normalized; }
    }

    public SpriteRenderer playerSpriteR;

    public Vector3 min, max;


    void Start()
    {
        objectPosition = transform.position;   // sets object to the position we put it in the editor

        min = playerSpriteR.bounds.min;
        max = playerSpriteR.bounds.max;
    }


    void Update()
    {
        velocity = direction * speed * Time.deltaTime;   // velocity is direction * speed * deltaTime

        objectPosition += velocity;   // add velocity to position

        // validate new calculated position
        // (not in code yet)

        transform.position = objectPosition;   // "draw" this object(the vehicle) at that position

        float hValue = Input.GetAxis("Horizontal");  // returns -1 or 1 to tell which way it is facing

        // to change where player faces to the direction it is moving (only horizontal)
        if ((hValue < 0 && facingRight) || (hValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            mouthDistance = -mouthDistance;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        min = playerSpriteR.bounds.min;
        max = playerSpriteR.bounds.max;

        StopAtEdges();
    }


    void StopAtEdges()
    {
        Vector3 sq = Vector3.zero;
        sq.x = Screen.width;    // this is in pixels
        sq.y = Screen.height;   // this is in pixels

        Vector3 objPix = Camera.main.ScreenToWorldPoint(sq);  // changes pixels into coords

        if ((objectPosition.x + 1 > objPix.x)) 
        {
            objectPosition.x = objectPosition.x - 0.1f;
            transform.position = objectPosition;
        }

        if ((objectPosition.x - 1 < -objPix.x))
        {
            objectPosition.x = objectPosition.x + 0.1f;
            transform.position = objectPosition;
        }

        if ((objectPosition.y + 0.8f > objPix.y))
        {
            objectPosition.y = objectPosition.y - 0.1f;
            transform.position = objectPosition;
        }

        if ((objectPosition.y - 0.4f < -objPix.y))
        {
            objectPosition.y = objectPosition.y + 0.1f;
            transform.position = objectPosition;
        }

    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        if (playerSpriteR != null)   // when you reference spriteRenderer but can't because its null before play, use if statement
        {
            Gizmos.DrawWireCube(transform.position, playerSpriteR.bounds.size);   // takes in center and size
        }
        //Gizmos.DrawWireSphere(transform.position + new Vector3(mouthDistance, 0f, 0f), mouthRadius);

        //Gizmos.color = Color.green;

        //Gizmos.DrawWireSphere(transform.position, regularRadius);
    }
}
