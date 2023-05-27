using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image progressbar;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }
    // Update is called once per frame
  

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation AsyneLoad = SceneManager.LoadSceneAsync("GameScene");

        AsyneLoad.allowSceneActivation = false;

        float timer = 0.0f;
        while(!AsyneLoad.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (AsyneLoad.progress < 0.9f)
            {
                progressbar.fillAmount = Mathf.Lerp(progressbar.fillAmount, AsyneLoad.progress, timer);
                if (progressbar.fillAmount >= AsyneLoad.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressbar.fillAmount = Mathf.Lerp(progressbar.fillAmount, 1f, timer);

                if (progressbar.fillAmount == 1.0f)
                {
                    yield return new WaitForSeconds(4.0f);
                    AsyneLoad.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
