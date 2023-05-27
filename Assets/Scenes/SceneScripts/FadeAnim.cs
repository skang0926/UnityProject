using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FadeAnim : MonoBehaviour
{

    public TextMeshProUGUI textDisplay; // ù��° �ؽ�Ʈ
    public TextMeshProUGUI textDisplay2; // �ι�° �ؽ�Ʈ
    public TextMeshProUGUI textDisplay3;

    float time = 0;
    public float fadeTime = 4f;
     void Start()
    {
        Debug.Log("����");
        StartCoroutine(FadeTextAnim());

    }

 
    IEnumerator FadeTextAnim()
    {
        while (time < fadeTime)
        {
            
            textDisplay.color = new Color(1, 1, 1, time / fadeTime);
            time += Time.deltaTime;
            if(time>fadeTime)
            {
                Debug.Log("ù��°");
                time = 0;
                textDisplay.gameObject.SetActive(false);
                StartCoroutine(SecondTextAnim());
            }

            yield return null;
        }
       
       
        



    }
    IEnumerator SecondTextAnim()
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
                StartCoroutine(ThirdTextAnim());

            }
            yield return null;

        }
      
       
       
    }
    IEnumerator ThirdTextAnim()
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
