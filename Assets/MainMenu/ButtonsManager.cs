using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{

    string MainMenu_Scene = "APP_MainMenu";
    string Combat_Scene = "Combat_Scene";
    string Soccer_Scene = "Soccer_Scene";
    string Plinko_Scene = "Plinko_Scene";
    public void GoToMainMenu()
    {
        Debug.Log("Main_Menu");
        SceneManager.LoadScene(MainMenu_Scene);
    }
    public void GoToPlinko()
    {
        Debug.Log("Plinko_Scene");
        SceneManager.LoadScene(Plinko_Scene);
    }
    public void GoToSoccer()
    {
        Debug.Log("Soccer_Scene");
        SceneManager.LoadScene(Soccer_Scene);
    }
    public void GoToCombat()
    {
        Debug.Log("Combat_Scene");
        SceneManager.LoadScene(Combat_Scene);
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
