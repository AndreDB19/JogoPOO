using UnityEngine;

public class Tank : Enemy
{
    private void Start()
    {
        health = 2;
        speed = 1f;
        score = 2;
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
