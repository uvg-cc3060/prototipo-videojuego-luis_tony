using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D theRB;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
    }

}
