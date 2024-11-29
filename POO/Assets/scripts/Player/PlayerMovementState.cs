using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementState : states
{   
    public player player;
    private float velocity;
    public GameObject Bullet;
    private int DelayShoot = 0;

    private Vector3 shootDirection;

    private void Move()
    {
        player.RBPlayer.MovePosition(player.RBPlayer.position + (player.MoveAction.ReadValue<Vector2>()*velocity) * Time.fixedDeltaTime);
    }

    private void shoot()
    {
        
        if(player.ShootAction.ReadValue<Vector2>() != new Vector2(0,0) && DelayShoot > 25)
        {

            shootDirection = new Vector3(player.position.x+player.ShootAction.ReadValue<Vector2>().x, player.position.y+player.ShootAction.ReadValue<Vector2>().y,player.position.z);

            Instantiate(Bullet, shootDirection , Quaternion.identity);
            DelayShoot = 0;
        }
        DelayShoot++;
    }

    public override void Enter()
    {
        velocity = 10f;
    }

    public override void Do()
    {
        
        
    }

    public override void FixedDo()
    {
        shoot();
        Move();
    }

    public override void LateDo()
    {
        
    }

    public override void Exit()
    {
    
    }


}
