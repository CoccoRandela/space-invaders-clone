using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    private CompositeCollider2D compositeCollider2D;
    private GameObject RightEdge, LeftEdge;
    private CompositeCollider2D EnemyGroupCollider;
    private Rigidbody2D rb2d;
    public float speed;
    public float distanceY, distanceX;
    Vector3 enemySpawnPoint = new Vector3(0, 0, 0);
    public GameObject EnemyOne, EnemyTwo, EnemyThree;

    void SpawnEnemies()
    {
        int i = 0;

        while(i < 10)
        {
            GameObject Enemy = Instantiate(EnemyOne, transform, false);
            Enemy.transform.localPosition = enemySpawnPoint;
            enemySpawnPoint = new Vector3(enemySpawnPoint.x + distanceX, enemySpawnPoint.y, enemySpawnPoint.z);
            i++;
        }
        enemySpawnPoint = new Vector3(0, enemySpawnPoint.y + distanceY, enemySpawnPoint.z);
        while (i < 20)
        {
           GameObject Enemy = Instantiate(EnemyOne, transform, false);
           Enemy.transform.localPosition = enemySpawnPoint;
           enemySpawnPoint = new Vector3(enemySpawnPoint.x + distanceX, enemySpawnPoint.y, enemySpawnPoint.z);
           i++;
        }
        enemySpawnPoint = new Vector3(0, enemySpawnPoint.y + distanceY, enemySpawnPoint.z);
        while (i < 30)
        {
           GameObject Enemy = Instantiate(EnemyTwo, transform, false);
           Enemy.transform.localPosition = enemySpawnPoint;
           enemySpawnPoint = new Vector3(enemySpawnPoint.x + distanceX, enemySpawnPoint.y, enemySpawnPoint.z);
           i++;
        }
        enemySpawnPoint = new Vector3(0, enemySpawnPoint.y + distanceY, enemySpawnPoint.z);
        while (i < 40)
        {
           GameObject Enemy = Instantiate(EnemyTwo, transform, false);
           Enemy.transform.localPosition = enemySpawnPoint;
           enemySpawnPoint = new Vector3(enemySpawnPoint.x + distanceX, enemySpawnPoint.y, enemySpawnPoint.z);
           i++;
        }
        enemySpawnPoint = new Vector3(0, enemySpawnPoint.y + distanceY, enemySpawnPoint.z);
        while (i < 50)
        {
           GameObject Enemy = Instantiate(EnemyThree, transform, false);
           Enemy.transform.localPosition = enemySpawnPoint;
           enemySpawnPoint = new Vector3(enemySpawnPoint.x + distanceX, enemySpawnPoint.y, enemySpawnPoint.z);
           i++;
        }

    }

    private void Move()
    {
        if (EnemyGroupCollider.bounds.max.x > RightEdge.transform.position.x)
        {
            speed = -speed * 1.25f;
            foreach(Transform child in transform) {
                child.GetComponent<Animator>().speed = -speed;
            }
            rb2d.velocity = new Vector2(speed, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y - distanceY, 0);
        }

        if (EnemyGroupCollider.bounds.min.x < LeftEdge.transform.position.x)
        {
            speed = -speed * 1.25f;
            foreach(Transform child in transform) {
                child.GetComponent<Animator>().speed = speed;
            }
            rb2d.velocity = new Vector2(speed, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y - distanceY, 0);
        }
    }

    void Start()
    {
        EnemyGroupCollider = transform.gameObject.GetComponent<CompositeCollider2D>();
        RightEdge = GameObject.FindGameObjectWithTag("RightEdge");
        LeftEdge = GameObject.FindGameObjectWithTag("LeftEdge");
        rb2d = transform.gameObject.GetComponent<Rigidbody2D>();

        SpawnEnemies();

        foreach(Transform child in transform) {
            child.GetComponent<Animator>().speed = speed; 
        }

        rb2d.velocity = new Vector2(speed, 0);

    }

    private void DestroyBlastedEnemy(Collider2D collision) {
        float blastPosY = collision.bounds.max.y;
        float blastPosX = collision.bounds.center.x;

        foreach(Transform child in transform){
            float childMinPosY = child.GetComponent<BoxCollider2D>().bounds.center.y - child.GetComponent<BoxCollider2D>().size.y * 7 / 2;
            float childMinPosX = child.GetComponent<BoxCollider2D>().bounds.center.x - child.GetComponent<BoxCollider2D>().size.x * 7 / 2;
            float childMaxPosX = child.GetComponent<BoxCollider2D>().bounds.center.x + child.GetComponent<BoxCollider2D>().size.x * 7 / 2;
            
            if (blastPosY > childMinPosY && (blastPosX > childMinPosX && blastPosX < childMaxPosX)) 
            {
                Destroy(collision.gameObject);
                Destroy(child.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        // float blastPosY = collision.bounds.max.y;
        // float blastPosX = collision.bounds.center.x;
        // foreach(Transform child in transform){
        //     float childMinPosY = child.GetComponent<BoxCollider2D>().bounds.center.y - child.GetComponent<BoxCollider2D>().size.y * 7 / 2;
        //     float childMinPosX = child.GetComponent<BoxCollider2D>().bounds.center.x - child.GetComponent<BoxCollider2D>().size.x * 7 / 2;
        //     float childMaxPosX = child.GetComponent<BoxCollider2D>().bounds.center.x + child.GetComponent<BoxCollider2D>().size.x * 7 / 2;
        //     if(blastPosY > childMinPosY && (blastPosX > childMinPosX && blastPosX < childMaxPosX)){
        //         Destroy(collision.gameObject);
        //         Destroy(child.gameObject);
        //     }
        // }
        DestroyBlastedEnemy(collision);
    }


}


