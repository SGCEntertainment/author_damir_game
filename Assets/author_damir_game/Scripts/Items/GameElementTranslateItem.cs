using UnityEngine.UI;
using UnityEngine;

public class GameElementTranslateItem : MonoBehaviour
{
    [SerializeField, TextArea] string ru;
    [SerializeField, TextArea] string en;

    private void Start()
    {
        GetComponent<Text>().text = LanguageUtil.IsRussian() ? ru : en;
    }
}
