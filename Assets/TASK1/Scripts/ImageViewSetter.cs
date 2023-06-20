using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewSetter : MonoBehaviour
{
    [SerializeField] Image image;
    void Start()
    {
        image.sprite = StaticVariables.dataStorage.sprites[StaticVariables.imageToShow];
    }
}
