using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalProjectButtonManager : MonoBehaviour
{
    string FinalProject_Menu = "FinalProject_Menu";
    string EndlessBarrels_Scene = "EndessBarrels_Scene";

    public void GoToMainMenu()
    {
        Debug.Log("FinalProject_Menu");
        SceneManager.LoadScene(FinalProject_Menu);
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
 