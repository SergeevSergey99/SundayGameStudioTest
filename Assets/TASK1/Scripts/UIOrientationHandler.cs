using UnityEngine;

public class UIOrientationHandler : MonoBehaviour
{
    public RectTransform landscapeUI;
    public RectTransform portraitUI;

    private void Start()
    {
        SetUIPositions();
    }

    private void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            portraitUI.gameObject.SetActive(true);
            landscapeUI.gameObject.SetActive(false);
        }
        else
        {
            portraitUI.gameObject.SetActive(false);
            landscapeUI.gameObject.SetActive(true);
        }
    }

    private void SetUIPositions()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            portraitUI.gameObject.SetActive(true);
            landscapeUI.gameObject.SetActive(false);
        }
        else
        {
            portraitUI.gameObject.SetActive(false);
            landscapeUI.gameObject.SetActive(true);
        }
    }
}