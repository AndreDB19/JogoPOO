using System;
using UnityEngine;

public class Minion : Enemy
{
    public Transform PlayerTransform;
    private void Start()
    {
        health = 1;
        speed = 2f;
        PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Physics.IgnoreLayerCollision(8, 8, true);
    }

    public override void DropItem()
    {
        
    }

    public override void MoveTo()
    {
        position = PlayerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, position, speed* Time.deltaTime);
    }


    private void FixedUpdate()
    {
        MoveTo();     
    }
}
