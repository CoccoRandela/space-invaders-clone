using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject Blast;
    public float blastSpeed;
    public float speed;
    public float edgeLeft = -5.88f;
    public float edgeRight = 5.88f;
    public SpriteRenderer spriteRenderer;

    void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if (transform.position.x < edgeLeft)
        {
            transform.position = new Vector3(edgeLeft, -6.5f, 0);
        }
        if (transform.position.x > edgeRight)
        {
            transform.position = new Vector3(edgeRight, -6.5f, 0);
        }
    }

    void Shoot()
    {
        if (!GameObject.FindGameObjectWithTag("Blast"))
        {
            Instantiate(Blast, new Vector3(transform.position.x, transform.position.y + spriteRenderer.size.y, transform.position.z), transform.rotation);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); 
        }
       

    }
}
