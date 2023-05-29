using UnityEngine;
using UnityEngine.UI;

public class ImageOpacityController : MonoBehaviour
{
    public Image image0; // Image 컴포넌트를 가리킬 변수
    public Image image1; // Image 컴포넌트를 가리킬 변수
    public Image image2; // Image 컴포넌트를 가리킬 변수
    public Image image3; // Image 컴포넌트를 가리킬 변수
    
    public float minOpacity = 0f; // 최소 투명도
    public float maxOpacity = 1f; // 최대 투명도
    public float changeInterval = 3f; // 투명도 변화 간격

    private float targetOpacity0; // 목표 투명도
    private float currentOpacity0; // 현재 투명도
    private float targetOpacity1; // 목표 투명도
    private float currentOpacity1; // 현재 투명도
    private float targetOpacity2; // 목표 투명도
    private float currentOpacity2; // 현재 투명도
    private float targetOpacity3; // 목표 투명도
    private float currentOpacity3; // 현재 투명도
    private float timer; // 시간 측정용 타이머

    private void Start()
    {
        // 초기 투명도 설정
        currentOpacity0 = image0.color.a;
        targetOpacity0 = currentOpacity0;
        currentOpacity1 = image1.color.a;
        targetOpacity1 = currentOpacity1;
        currentOpacity2 = image2.color.a;
        targetOpacity2 = currentOpacity2;
        currentOpacity3 = image3.color.a;
        targetOpacity3 = currentOpacity3;
    }

    private void Update()
    {
        // 타이머 업데이트
        timer += Time.deltaTime;

        // 일정 간격마다 투명도 변경
        if (timer >= changeInterval)
        {
            timer = 0f;
            targetOpacity0 = Random.Range(minOpacity, maxOpacity);
            targetOpacity1 = Random.Range(minOpacity, maxOpacity);
            targetOpacity2 = Random.Range(minOpacity, maxOpacity);
            targetOpacity3 = Random.Range(minOpacity, maxOpacity);
        }

        // 투명도 보간하여 적용
        currentOpacity0 = Mathf.Lerp(currentOpacity0, targetOpacity0, Time.deltaTime);
        currentOpacity1 = Mathf.Lerp(currentOpacity1, targetOpacity1, Time.deltaTime);
        currentOpacity2 = Mathf.Lerp(currentOpacity2, targetOpacity2, Time.deltaTime);
        currentOpacity3 = Mathf.Lerp(currentOpacity3, targetOpacity3, Time.deltaTime);
        image0.color = new Color(image0.color.r, image0.color.g, image0.color.b, currentOpacity0);
        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, currentOpacity1);
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, currentOpacity2);
        image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, currentOpacity3);
    }
}
