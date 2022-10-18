using UnityEngine.UI;
using UnityEngine;

public class UITranslatItem : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
        GetComponent<Text>().text = UITranslatUtil.GetUIString(id);
    }
}
