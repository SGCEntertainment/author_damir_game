using UnityEngine;
using UnityEngine.UI;

public class UITranslatItem : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
        GetComponent<Text>().text = UITranslatUtil.GetUIString(id);
    }
}
