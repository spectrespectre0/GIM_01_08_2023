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
    public KeyCode keycode_space_1;
    public KeyCode keycode_space_2;
    public KeyCode keycode_space_3;
    public GameObject player;
    public GameObject UIrestart;
    public Rigidbody2D rb;

  

    // Start is called before the first frame update
    void Start()
    {
        checkjump = false;
        jumpheight = 24f;
        keycode_space_1 = KeyCode.Z;
        keycode_space_2 = KeyCode.X;
        keycode_space_3 = KeyCode.C;
        if (rb.gravityScale < 0)
        {
            jumpheight = jumpheight * -1;
            keycode_space_1 = KeyCode.B;
            keycode_space_2 = KeyCode.N;
            keycode_space_3 = KeyCode.M;
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
            keycode_space_1 = KeyCode.None;
            keycode_space_2 = KeyCode.None;
            keycode_space_3 = KeyCode.None;
        }

        buttonpress = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keycode_space_1) || Input.GetKeyDown(keycode_space_2) || Input.GetKeyDown(keycode_space_3))
        {
            buttonpress = true;
        }
        if (Input.GetKeyUp(keycode_space_1) || Input.GetKeyUp(keycode_space_2) || Input.GetKeyUp(keycode_space_3))
        {
            buttonpress = false;
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

    void OnCollisionExit2D(Collision2D collision)
    {
        checkjump = false;
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
