using UnityEngine;
using UnityEngine.UI; 

public class UserPref : MonoBehaviour {

    
    string userName;
    public InputField UserField;

	// Use this for initialization
	void Start () {

        bool haskey = PlayerPrefs.HasKey("UserName");
        if (!haskey)
        {
            userName = "New User";
            UserField.text = userName;
            return;
        }

       userName = PlayerPrefs.GetString("UserName");

    
       
        if (userName == "")
        {
            userName = "Bad User";
        }
            
        Debug.Log("userName: " + userName);

        UserField.text = userName; 

    }
	
	
	public void SaveUserName () {

        PlayerPrefs.SetString("UserName", UserField.text);
        PlayerPrefs.Save(); 
	}
}
