using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FadeAnim : MonoBehaviour
{

    public TextMeshProUGUI textDisplay; // 첫번째 텍스트
    public TextMeshProUGUI textDisplay2; // 두번째 텍스트
    public TextMeshProUGUI textDisplay3;
    float time = 0;
    public float fadeTime = 4f;
     void Start()
    {
        Debug.Log("시작");
        StartCoroutine(Fadetextanim());

    }

 
    IEnumerator Fadetextanim()
    {
        while (time < fadeTime)
        {
            
            textDisplay.color = new Color(1, 1, 1, time / fadeTime);
            time += Time.deltaTime;
            if(time>fadeTime)
            {
                Debug.Log("첫번째");
                time = 0;
                textDisplay.gameObject.SetActive(false);
                StartCoroutine(Secondtextanim());
            }

            yield return null;
        }
       
       
        



    }
    IEnumerator Secondtextanim()
    {
        textDisplay2.gameObject.SetActive(true);
        while (time < fadeTime)
        {
            
            textDisplay2.color = new Color(1, 1, 1, time / fadeTime);
            time += Time.deltaTime;
            if (time > fadeTime)
            {
                time = 0;
                textDisplay2.gameObject.SetActive(false);
                StartCoroutine(Thirdtextanim());

            }
            yield return null;

        }
      
       
       
    }
    IEnumerator Thirdtextanim()
    {
        textDisplay3.gameObject.SetActive(true);
        while (true)
        {
            if (time < 1f)
            {
                textDisplay3.color = new Color(1, 1, 1, time);

            }
            else
            {
                textDisplay3.color = new Color(1, 1, 1, time);
                if (time > 1f)
                {
                    time = 0.5f;
                }
            }
            time += Time.deltaTime;

            yield return null;
        }
        
    }




}
