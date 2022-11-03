using UnityEngine.UI;
using UnityEngine;

public class SortItem : MonoBehaviour
{
    private void Start()
    {
        int minIndex = 0;
        int maxIndex = transform.parent.childCount - 1;

        Button down = transform.GetChild(1).GetComponent<Button>();
        Button up = transform.GetChild(2).GetComponent<Button>();

        down.onClick.AddListener(() =>
        {
            int targetIndex = transform.GetSiblingIndex() + 1;
            if(targetIndex > maxIndex)
            {
                return;
            }

            transform.SetSiblingIndex(targetIndex);
        });

        up.onClick.AddListener(() =>
        {
            int targetIndex = transform.GetSiblingIndex() - 1;
            if(targetIndex < minIndex)
            {
                return;
            }

            transform.SetSiblingIndex(targetIndex);
        });
    }
}
