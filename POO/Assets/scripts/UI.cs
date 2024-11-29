using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public player player;
    public TextMeshProUGUI Texto;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        Texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    
        Texto.text =  "Vida: "+player.health+"    Pontuação: "+player.score;
    }
}
