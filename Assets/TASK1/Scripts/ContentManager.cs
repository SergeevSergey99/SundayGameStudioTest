using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImageDownloader))]
public class ContentManager : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] int countToFirstLoad = 6;
    [SerializeField] int maxImages = 66;
    ImageDownloader imageDownloader;

    void Start()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        imageDownloader = GetComponent<ImageDownloader>();

        LoadContent();
    }

    public void LoadContent()
    {
        StartCoroutine(LoadContentCoroutine());
    }

    IEnumerator LoadContentCoroutine()
    {
        for (int i = 1; i <= countToFirstLoad; i++)
        {
            yield return AddImageToContentCoroutine(i);
        }
    }

    IEnumerator AddImageToContentCoroutine(int i)
    {
        if (StaticVariables.dataStorage.sprites.ContainsKey(i) 
            && StaticVariables.dataStorage.sprites[i] == null) 
            yield break;
        
        yield return imageDownloader.LoadImageFromURL(i);
        CreateSlot(i);
    }

    void CreateSlot(int index)
    {
        var slot = Instantiate(slotPrefab, content);
        slot.GetComponent<Slot>().Init(index);
    }

    public void OnScrollValueChanged(Vector2 value)
    {
        if (value.y < 0.1f)
        {
            //Debug.Log(value);
            int index = content.childCount + 1;
            if (index > maxImages) return;
            StartCoroutine(AddImageToContentCoroutine(index));
        }
    }
}