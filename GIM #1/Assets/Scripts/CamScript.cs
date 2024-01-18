using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public NewBehaviourScript nbs;
    // Start is called before the first frame update
    void Start()
    {
        speed = nbs.speed;
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        
    }
}
