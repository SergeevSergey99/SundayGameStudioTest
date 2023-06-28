using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void LoadSceneThroughLoadingScreen(string sceneName)
    {
        StaticVariables.sceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
