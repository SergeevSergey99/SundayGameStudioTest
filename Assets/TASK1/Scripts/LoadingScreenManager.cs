using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(ImageDownloader))]
public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] int imagesCount = 10;
    [SerializeField] float waitBeforeLoading = 2f;
    [SerializeField] float waitAfterLoading = 1f;
    [SerializeField] Image progressBar;
    ImageDownloader imageDownloader;
    void Start()
    {
        imageDownloader = GetComponent<ImageDownloader>();
        progressBar.fillAmount = 0f;
        
        StartCoroutine(LoadingProcess());
    }
    IEnumerator LoadingProcess()
    {
        yield return new WaitForSeconds(waitBeforeLoading);
        yield return StartCoroutine(DownloadImages());
        yield return new WaitForSeconds(waitAfterLoading);
        
        LoadScene();
    }
    IEnumerator DownloadImages()
    {
        for (int i = 1; i <= imagesCount; i++)
        {
            yield return StartCoroutine(imageDownloader.LoadImageFromURL(i));
            progressBar.fillAmount = ((float) i) / imagesCount;
        }
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene(StaticVariables.sceneToLoad);
        StaticVariables.sceneToLoad = "";
    }
}
