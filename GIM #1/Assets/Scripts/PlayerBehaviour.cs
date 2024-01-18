using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public int key_1;
    public int key_2;
    public int key_3;
    public GameObject player;
    public GameObject otherplayer;
    public GameObject UIrestart;
    public GameObject Pause;
    public PauseMenu esc_pause;
    public Rigidbody2D rb;
    public AudioSource playerAudioSource;
    public AudioClip collisionAudioClip;
    public SettingsButtons sets;




    // Start is called before the first frame update
    //this is void start
    void Start()
    {
        checkjump = false;
        jumpheight = 24f;

        key_1 = PlayerPrefs.GetInt("p1_1",(int)KeyCode.Z);
        key_2 = PlayerPrefs.GetInt("p1_2", (int)KeyCode.X);
        key_3 = PlayerPrefs.GetInt("p1_3", (int)KeyCode.C);

        if (rb.gravityScale < 0)
        {
            jumpheight = jumpheight * -1;
            key_1 = PlayerPrefs.GetInt("p2_1", (int)KeyCode.B);
            key_2 = PlayerPrefs.GetInt("p2_2", (int)KeyCode.N);
            key_3 = PlayerPrefs.GetInt("p2_3", (int)KeyCode.M);
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

        keycode_space_1 = (KeyCode)key_1;
        keycode_space_2 = (KeyCode)key_2;
        keycode_space_3 = (KeyCode)key_3;

        buttonpress = false;

        //horizontal movement
        rb.velocity = new Vector2(speed, rb.velocity.y);
    } 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keycode_space_1) || Input.GetKeyDown(keycode_space_2) || Input.GetKeyDown(keycode_space_3))
        {
            buttonpress = true;

            if (rb.gravityScale > 0)
            {
                Debug.Log(player.transform.position.x);
            }

            //if (rb.gravityScale < 0)
            //{
            //    Debug.Log(player.transform.position.x);
            //}

        }
        if (Input.GetKeyUp(keycode_space_1) || Input.GetKeyUp(keycode_space_2) || Input.GetKeyUp(keycode_space_3))
        {
            buttonpress = false;
        }

        //restart after death without mouse click
        if(UIrestart.activeSelf == true && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            OnRestartButton();
        }

        //pause menu without mouse click
        if(UIrestart.activeSelf == false && Time.timeScale == 1 && Input.GetKeyDown((KeyCode)27)) //(keycode)27 = keycode.escape
        {
            esc_pause.Pause();
        }

        //resume without mouse click
        if (UIrestart.activeSelf == false && Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            esc_pause.Resume();
        }

        

    } 

    public void nextbutton()
    {
        SceneManager.LoadScene("LevelSelection");
    } 

    void FixedUpdate()
    {

        if (checkjump && buttonpress)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpheight);
            checkjump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") && (rb.velocity.x > 0))
        {
            checkjump = true;
        }

        if (collision.gameObject.CompareTag("Floor") && (rb.velocity.x < speed)){

            Debug.Log("collided!");
            playerAudioSource.Stop();
            playerAudioSource.clip = collisionAudioClip;
            playerAudioSource.Play();

            StartCoroutine(ShowDeathEffects());
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
            
            // Stop the audio clip
            playerAudioSource.Stop();
            playerAudioSource.clip = collisionAudioClip;
            playerAudioSource.Play();

            StartCoroutine(ShowDeathEffects());
        }
    }

    IEnumerator ShowDeathEffects()
    {
        
        // Play death effects
        var part = GetComponent<ParticleSystem>();
        part.Play();
        player.GetComponent<Renderer>().enabled = false;

        // Wait for a very short interlude duration (adjust as needed)
        yield return new WaitForSeconds(0.2f);

        // Show UI elements after the interlude
        Time.timeScale = 0;
        UIrestart.SetActive(true);
        Pause.SetActive(false);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        UIrestart.SetActive(false);
    }
}
