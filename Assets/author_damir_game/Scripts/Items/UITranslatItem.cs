using TMPro;
using UnityEngine;

public class UITranslatItem : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = UITranslatUtil.GetUIString(id);
    }
}
