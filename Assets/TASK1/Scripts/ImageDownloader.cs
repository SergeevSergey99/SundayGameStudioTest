using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    [SerializeField] string url = "http://data.ikppbb.com/test-task-unity-data/pics/";

    public IEnumerator LoadImageFromURL(int index)
    {
        if (StaticVariables.dataStorage.sprites.ContainsKey(index))
        {
            Debug.LogWarning("Изображение уже загружено");
            yield break;
        }
        
        StaticVariables.dataStorage.sprites.Add(index, null);
        var imageUrl = url + index + ".jpg";
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);

                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                
                // Here we store the sprite in the dictionary
                
                StaticVariables.dataStorage.sprites[index] = sprite;
            }
            else
            {
                Debug.LogError("Ошибка загрузки изображения: "+ url + "\n" + webRequest.error);
            }
        }
    }
}