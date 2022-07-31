using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float stop;
    public Transform target;
    public bool following;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        if (Vector2.Distance(transform.position, target.position) > stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            following = true;
        }
        else
        {
            following = false;
        }
    }
}
