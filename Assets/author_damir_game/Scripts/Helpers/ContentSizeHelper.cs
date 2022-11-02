using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ContentSizeHelper : MonoBehaviour
{
    const float fixedOffset = 25.0f;
 
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        float parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
        float contentHeight = transform.GetHeight();

        float space = contentHeight > parentHeight ? (parentHeight - contentHeight) - fixedOffset : 0;

        RectTransform rt = GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(0, space);

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        yield return new WaitForEndOfFrame();

        float et = 0.0f;
        float needTime = 1.0f;
        while(et < needTime)
        {
            et += Time.deltaTime;
            canvasGroup.alpha = et / needTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
}
