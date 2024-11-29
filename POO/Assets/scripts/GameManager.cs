using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public int timer = 0;
    
    public GameObject TelaMorte;

    public string path;
    public string[] allLines;
    public int MaxScore;
    public player player;
    public string[] newScore;

    public Text text;

    void Start()
    {
        TelaMorte=GameObject.FindWithTag("TelaMorte");
        text = GameObject.FindWithTag("Texto").GetComponent<Text>();
        TelaMorte.SetActive(false);
        path = @"D:\projects\projeto Game dev\POO\POO\Assets\scripts\Pontuação.txt";
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        
    }

    
    void FixedUpdate()
    {
        timer++;
    }

    public void pause()
    {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            TelaMorte.SetActive(false);
            player.Spawnar();
        } else if (Time.timeScale == 1) {
            Time.timeScale = 0;
            NovaPontuacao();
            TelaMorte.SetActive(true);
            text.mudarTexto();
        }
        GameObject.FindWithTag("Spawner").GetComponent<Spawner>().spawned = 0;
        
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
}
