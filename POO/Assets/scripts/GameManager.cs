using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public int timer = 0;
    
    public GameObject TelaMorte;
    public player player;
    public Text text;
    public GameObject[] spawner;
    public GameObject Minion;
    public GameObject Tank;
    public GameObject UI;

    public string path;
    public string[] allLines;

    public int MaxScore;
    public string[] newScore;

    public int spawned = 0;

    void Start()
    {
        TelaMorte=GameObject.FindWithTag("TelaMorte");
        text = GameObject.FindWithTag("Texto").GetComponent<Text>();
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        spawner = GameObject.FindGameObjectsWithTag("Spawner");
        UI = GameObject.FindWithTag("UI");
        
        path = @"D:\projects\projeto Game dev\JogoPOO\POO\Assets\scripts\Pontuação.txt";

        TelaMorte.SetActive(false);
        
    }

    
    void FixedUpdate()
    {
        timer++;
        Spawnar();
    }

    public void end()
    {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            UI.SetActive(true);
            TelaMorte.SetActive(false);
            player.Spawnar();
        } else if (Time.timeScale == 1) {
            Time.timeScale = 0;
            NovaPontuacao();
            TelaMorte.SetActive(true);
            text.mudarTexto();
            UI.SetActive(false);
        }
        spawned = 0;
        
    }

    public void NovaPontuacao()
    {
         try
        {
            allLines = File.ReadAllLines(path);
            MaxScore = Convert.ToInt32(allLines[0]);
            if (MaxScore < player.score)
            {
                File.Delete(path);
                newScore = new string[1];
                newScore[0] = player.score.ToString();
                File.WriteAllLines(path, newScore);
            }
        }
        catch (FormatException e)
        {
            Debug.Log(e);
        }
        catch (OverflowException e)
        {
            Debug.Log(e);
        }
    }

    public void Spawnar()
    {
        if(timer%40==0 )
            {
                Instantiate(Minion, spawner[UnityEngine.Random.Range(0, 4)].transform.position, Quaternion.identity);
                spawned++;
                if(spawned%2==0)
                {
                    Instantiate(Tank, spawner[UnityEngine.Random.Range(0, 4)].transform.position, Quaternion.identity);
                }
            }
    }
}
