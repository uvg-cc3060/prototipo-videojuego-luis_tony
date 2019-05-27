using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character2 : MonoBehaviour
{

    Rigidbody2D rb2d;
    SpriteRenderer sr;
    private Sprite character, grassCenter, grassMid;
    public Camera cam;
    private float speed = 5f;
    private float jumpForce = 250f;
    private float tiempo = 0.0f;
    private int tiempoS = 0;
    private bool facingRight = true;
    Animator anim;
    AudioSource aud;
    public AudioClip transforms, jumps, alarm;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        character = Resources.Load<Sprite>("SnowBallFightArt");
        grassCenter = Resources.Load<Sprite>("grassCenter2");
        grassMid = Resources.Load<Sprite>("grassMid");
        sr.sprite = character;
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Funcion para que el personaje se mueva en horizontal
        float move = Input.GetAxis("Horizontal2");
        if (move != 0)
        {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            facingRight = move > 0;
        }

        sr.flipX = !facingRight;
        //Funcion para que el personaje pueda saltar
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            aud.clip = jumps;
            aud.Play(); ;
        }
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            aud.clip = transforms;
            aud.Play();
            if (sr.sprite == character)
                sr.sprite = grassCenter;
            else if (sr.sprite == grassCenter)
                sr.sprite = grassMid;
            else if (sr.sprite == grassMid)
                sr.sprite = character;
            aud.clip = transforms;
            aud.Play();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            aud.clip = transforms;
            aud.Play();
            if (sr.sprite == grassCenter)
                sr.sprite = character;
            else if (sr.sprite == grassMid)
                sr.sprite = grassCenter;
            else if (sr.sprite == character)
                sr.sprite = grassMid;
            aud.clip = transforms;
            aud.Play();
        }
        tiempo += Time.deltaTime;
        tiempoS = (int)tiempo;
        if (tiempoS == 9)
        {
            aud.clip = alarm;
            aud.Play();
        }
        if (tiempoS == 12)
        {
            aud.Stop();
            tiempo = 0;
        }
    }
}
