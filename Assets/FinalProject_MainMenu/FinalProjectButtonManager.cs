using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalProjectButtonManager : MonoBehaviour
{
    string FinalProject_MainMenu = "FinalProject_MainMenu";
    string EndlessBarrels_Scene = "EndlessBarrels_Scene";

    public void GoToMainMenu()
    {
        Debug.Log("FinalProject_MainMenu");
        SceneManager.LoadScene(FinalProject_MainMenu);
    }
    public void GoToEndlessBarrels()
    {
        Debug.Log("EndlessBarrels_Scene");
        SceneManager.LoadScene(EndlessBarrels_Scene);
    }

    public void ExitApplication()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
