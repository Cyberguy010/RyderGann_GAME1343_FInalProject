using UnityEngine;
using TMPro;

public class EndlessBarrelsManager : MonoBehaviour
{
    public static EndlessBarrelsManager Instance;
    public TextMeshProUGUI playerScorefield;
    public TextMeshProUGUI playerLivesfield;
    int gameScore = 0;
    int playerLives = 3;

    private void Awake()
    {
        Instance = this;

        gameScore = 0;
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

    }

    public void AddScore(int value)
    {

    }

    public void RemoveLife(int value)
    {

    }
}
