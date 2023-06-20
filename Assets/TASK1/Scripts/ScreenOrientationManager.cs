using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrientationManager : MonoBehaviour
{
    [SerializeField] ScreenOrientation targetOrientation = ScreenOrientation.LandscapeLeft;

    private void Start()
    {
        SetScreenOrientation(targetOrientation);
    }

    private void OnDestroy()
    {
        ResetScreenOrientation();
    }

    private void SetScreenOrientation(ScreenOrientation orientation)
    {
        Screen.orientation = orientation;
    }

    private void ResetScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void LoadTargetScene(string sceneName)
    {
        ResetScreenOrientation();
        SceneManager.LoadScene(sceneName);
    }
}