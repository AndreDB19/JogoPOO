using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;
public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    public Rigidbody2D RBBullet;
    [SerializeField] private float velocity;
    public player player;


    void Start()
    {
        RBBullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<player>();;
        velocity = 20f;
        direction = player.ShootAction.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RBBullet.MovePosition((velocity *direction * Time.fixedDeltaTime)+new Vector2(transform.position.x, transform.position.y));
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage();
        }
        Destroy(gameObject);
    }
}
