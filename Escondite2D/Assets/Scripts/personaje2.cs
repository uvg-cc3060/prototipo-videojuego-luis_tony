using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje2 : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public KeyCode shot;

    private Rigidbody2D theRB;

    public GameObject snowBall;
    public Transform throwPoint;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }

        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump))
        {
            theRB.velocity = new Vector2(theRB.velocity.y, jumpForce);
        }

        if (Input.GetKeyDown(shot))
        {
            Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
        }

    }
}
