using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlast : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float upwardVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody.velocity = new Vector2(0, upwardVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if(collision.gameObject == GameObject.FindGameObjectWithTag("TopEdge"))
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
