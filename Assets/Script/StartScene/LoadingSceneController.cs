using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Image barSlider;
    [SerializeField]
    Text loadingText;

    void Start()
    {
        StartCoroutine(LoadScene());
    }


    public static void LoadScene(string sceneName) {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    
   
    IEnumerator LoadScene(){
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while(!op.isDone) {
            yield return null;
            timer += Time.deltaTime;

            if(op.progress < 0.9f) {
                barSlider.fillAmount = Mathf.Lerp(barSlider.fillAmount, op.progress, timer);
                loadingText.text = $"{(int)(barSlider.fillAmount*100)} %";
                if(barSlider.fillAmount >= op.progress) timer = 0.0f;
            }
            else {
                barSlider.fillAmount = Mathf.Lerp(barSlider.fillAmount, 1f, timer);
                loadingText.text = $"{(int)(barSlider.fillAmount*100)} %";
                if(barSlider.fillAmount ==1f){
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
