using UnityEngine.UI;
using UnityEngine;
using System;

public class CompleteCanvas : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Image achImg;
    [SerializeField] Button continueBtn;

    public void Init(string titleString, string contBtnString, Sprite achSprite, Action OnContinueEvent)
    {
        continueBtn.transform.GetChild(0).GetComponent<Text>().text = contBtnString;
        titleText.text = titleString;
        achImg.sprite = achSprite;
        achImg.SetNativeSize();

        continueBtn.onClick.AddListener(() => OnContinueEvent.Invoke());
    }
}
