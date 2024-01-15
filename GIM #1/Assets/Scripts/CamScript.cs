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
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
    }
}
