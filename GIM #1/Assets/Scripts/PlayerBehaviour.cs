using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public bool checkjump;
    public bool buttonpress;
    public float jumpheight;
    public KeyCode keycode_space;
    public GameObject player;
    public GameObject UIrestart;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        checkjump = false;
        speed = 10f;
        jumpheight = 24f;
        keycode_space = KeyCode.Space;
        if (rb.gravityScale < 0)
        {
            jumpheight = jumpheight * -1;
            keycode_space = KeyCode.Return;
            var part = GetComponent<ParticleSystem>();
            var a = part.main;
            float gravity = part.main.gravityModifierMultiplier;
            gravity *= -1;
            a.gravityModifierMultiplier = gravity;
            ;
        }

        if (rb.gravityScale == 0)
        {
            jumpheight = 0;
            keycode_space = KeyCode.None;
        }

        buttonpress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode_space))
        {
            buttonpress = true;
        }
        if(Input.GetKeyUp(keycode_space))
        {
            buttonpress= false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (checkjump && buttonpress)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpheight);
            checkjump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            checkjump = true;
        }
        else
        {
            checkjump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //spike death
        if (collision.gameObject.CompareTag("Spike"))
        {
            Time.timeScale = 0;
            var part = GetComponent<ParticleSystem>();
            part.Play();
            player.GetComponent<Renderer>().enabled = false;
            UIrestart.SetActive(true);
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        UIrestart.SetActive(false);
    }
}
