using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    int index;
    public void Init(int index)
    {
        image.sprite = StaticVariables.dataStorage.sprites[index];
        this.index = index;
    }
    
    public void OnClick(string sceneName)
    {
        Debug.Log("Clicked on slot " + index);
        StaticVariables.imageToShow = index;
        SceneLoad.LoadSceneThroughLoadingScreen(sceneName);
    }
}
