using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;

    public float speed;
    public Vector3 position;
    public player player;
    public int score;

    public abstract void MoveTo();
    public abstract void DropItem();
    public void TakeDamage()
    {
        health -= 1;
        if(health <= 0)
        {
            DropItem();
            player.score += score;
            Destroy(gameObject);
        }
    }

}
