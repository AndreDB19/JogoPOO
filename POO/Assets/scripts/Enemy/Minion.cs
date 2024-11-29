using System;
using UnityEngine;

public class Minion : Enemy
{
    private void Start()
    {
        health = 1;
        speed = 2f;
        score = 1;
        Physics.IgnoreLayerCollision(8, 8, true);
        player = GameObject.FindWithTag("Player").GetComponent<player>();
    }

    public override void DropItem()
    {
        //throw new System.NotImplementedException();
    }

    public override void MoveTo()
    {
        position = player.position;
        transform.position = Vector3.MoveTowards(transform.position, position, speed* Time.deltaTime);
    }


    private void FixedUpdate()
    {
        MoveTo();     
    }
}
