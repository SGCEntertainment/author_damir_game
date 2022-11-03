using UnityEngine.UI;
using UnityEngine;

public class GetAnsverItem : MonoBehaviour
{
    [SerializeField, TextArea] string ru;
    [SerializeField, TextArea] string en;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("main text").GetComponent<Text>().text = LanguageUtil.IsRussian() ? ru : en;
            transform.parent.parent.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
            foreach(Transform t in transform.parent)
            {
                t.gameObject.SetActive(false);
            }
            GetComponentInParent<ButtonsHelper>().EnableContinue();
        });
    }
}
