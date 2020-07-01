using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    //opens selected scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Quits the application (still debugging)
    public void QuitGame()
    {
        Debug.Log("Game is Quitting");
        Application.Quit();
    }
}
