using UnityEngine;
using TMPro;

public class SoccerManager : MonoBehaviour
{
    public TextMeshProUGUI Team1ScoreField;
    public TextMeshProUGUI Team2ScoreField;

    public SoccerNet Team1Net;
    public SoccerNet Team2Net;
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
        Team1ScoreField.text = "" + Team1Net.score;
        Team2ScoreField.text = "" + Team2Net.score;
    }
}
