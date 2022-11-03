using UnityEngine;
using UnityEngine.UI;

public class UserInfoItem : MonoBehaviour
{
    [SerializeField, TextArea] string ru;
    [SerializeField, TextArea] string en;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("main text").GetComponent<Text>().text = LanguageUtil.IsRussian() ? ru : en;
            transform.parent.parent.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
            GetComponentInParent<ButtonsHelper>().EnableContinue();
        });
    }
}
