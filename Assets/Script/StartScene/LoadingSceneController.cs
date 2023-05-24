using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public static string nextScene;
    private static bool isLoading = false;
    [SerializeField]
    Image barSlider;
    [SerializeField]
    Text loadingText;

    void Start()
    {

        StartCoroutine(LoadScene());
        
    }


    public static void LoadScene(string sceneName) {
        if (isLoading)
        {
            Debug.LogWarning("로딩 중입니다. 잠시 후 다시 시도하세요.");
            return;
        }
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    
   
    IEnumerator LoadScene(){
        isLoading = true;

        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while(!op.isDone) {
            print("-------------------------");
            yield return null;
            timer += Time.deltaTime;
            
            if(op.progress < 0.9f) {
                print(op.progress);
                barSlider.fillAmount = Mathf.Lerp(barSlider.fillAmount, op.progress, timer);
                loadingText.text = $"{(int)(barSlider.fillAmount*100)} %";
                if(barSlider.fillAmount >= op.progress) timer = 0.0f;
            }
            else {
                print("111111111111111111111111111");
                barSlider.fillAmount = Mathf.Lerp(barSlider.fillAmount, 1f, timer);
                loadingText.text = $"{(int)(barSlider.fillAmount*100)} %";
                if(barSlider.fillAmount == 1f){
                    op.allowSceneActivation = true;
                    isLoading = false;
                    yield break;
                }
            }
        }

    }
}
