using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;

    public float speed;
    public Vector3 position;

    public abstract void MoveTo();
    public abstract void DropItem();
    public void TakeDamage()
    {
        health -= 1;
        if(health <= 0)
        {
            DropItem();
            GameObject.FindWithTag("Player").GetComponent<player>().score += 1;
            Destroy(gameObject);
        }
    }

}
