using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    
    public TextMeshProUGUI Texto;
    public player player;
    

    public void mudarTexto()
    {
        Texto = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        Texto.text =  "Antiga Melhor Pontuação: "+GameObject.FindWithTag("GameManager").GetComponent<GameManager>().allLines[0] +   "        Pontuação Atual: "+ player.score;
    }

    

}
