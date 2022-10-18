using UnityEngine.UI;
using UnityEngine;
using System;

public class ChoiceCanvas : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Button yesBtn;
    [SerializeField] Button noBtn;

    public void Init(string title, Action op)
    {
        titleText.text = title;
        yesBtn.onClick.AddListener(() => op?.Invoke());
        noBtn.onClick.AddListener(() => Destroy(gameObject));
    }
}
