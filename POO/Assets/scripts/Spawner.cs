using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Minion;
    public GameObject Tank;
    public GameManager GameManager;
    public int spawned = 0;
    
    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        
            if(GameManager.timer%40==0 )
            {
                Instantiate(Minion, transform.position, Quaternion.identity);
                spawned++;
                if(spawned%2==0)
                {
                    Instantiate(Tank, transform.position, Quaternion.identity);
                }
            }
    }
}
