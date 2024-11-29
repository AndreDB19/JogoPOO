using UnityEngine;

public class Tank : Enemy
{

    public Transform PlayerTransform;
    private void Start()
    {
        health = 2;
        speed = 1f;
        PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Physics.IgnoreLayerCollision(8, 8, true);
    }

    public override void DropItem()
    {
        //throw new System.NotImplementedException();
    }

    public override void MoveTo()
    {
        position = PlayerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, position, speed* Time.deltaTime);
    }


    private void FixedUpdate()
    {
        MoveTo();
        DropItem();
    }
}
