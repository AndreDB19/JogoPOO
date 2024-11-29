using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementState : states
{   
    public player player;
    private float maxLinearVelocity;
    private float velocity;
    public GameObject Bullet;
    private int DelayShoot = 0;


    
    

    private void Move()
    {
        player.RBPlayer.MovePosition(player.RBPlayer.position + (player.MoveAction.ReadValue<Vector2>()*velocity) * Time.fixedDeltaTime);
    }

    private void shoot()
    {
        
        if(player.ShootAction.ReadValue<Vector2>() != new Vector2(0,0) && DelayShoot > 25)
        {

            player.position = new Vector3(player.position.x+player.ShootAction.ReadValue<Vector2>().x, player.position.y+player.ShootAction.ReadValue<Vector2>().y,player.position.z);

            Instantiate(Bullet, player.position , Quaternion.identity);
            DelayShoot = 0;
        }
        DelayShoot++;
    }

    public override void Enter()
    {
        velocity = 10f;
        player.health=4;
    }

    public override void Do()
    {
        
        Move();
    }

    public override void FixedDo()
    {
        shoot();
    }

    public override void LateDo()
    {
        
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }


}
