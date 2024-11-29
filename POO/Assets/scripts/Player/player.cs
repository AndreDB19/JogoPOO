using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public states CurrentState;
    [SerializeField] public PlayerMovementState PlayerMovementState;

    public Rigidbody2D RBPlayer;
    public Vector3 position;

    public PlayerInput PlayerInput;
    public InputAction MoveAction;
    public InputAction ShootAction;

    public int health;
    public GameObject[] enemies;
    public int score;

    public GameManager GameManager;

    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        RBPlayer = GetComponent<Rigidbody2D>();
        MoveAction = PlayerInput.actions["move"];
        ShootAction = PlayerInput.actions["attack"];
        ChangeState(PlayerMovementState);
        score = 0;
    }


    void Update()
    {
        position = GetComponent<Transform>().position;
        CurrentState.Do();
    }

    void FixedUpdate()
    {
        CurrentState.FixedDo();
    }

    public void ChangeState(states newState)
    {
        try
        {
            CurrentState.Exit();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        CurrentState = newState;
        CurrentState.Enter();
      
    }

    public void TakeDamage()
    {
        health--;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
            Debug.Log("Inimigo numero " + i + " destruido");
        }

        if(health <= 0)
        {
            GameManager.pause();

        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        
    }

    public void Spawnar()
    {
        health = 4;
        transform.position = new Vector3(0, 0,0);
        score = 0;
    }
}
