using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    public int Player1score = 0;

    public int Player2score = 0;

    public CombatController Player1;
    public CombatController Player2;

    public TextMeshProUGUI Player1Field;
    public TextMeshProUGUI Player2Field;

    private void Awake()
    {
       // lazy singleton 
       instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Player1Field.text = Player1score.ToString();
        Player2Field.text = Player2score.ToString();
    }

    public void AddScore(int playerNumber)
    {
        if (playerNumber == 1) { Player1score++; }
        if (playerNumber == 2) { Player2score++; }
    }
}
