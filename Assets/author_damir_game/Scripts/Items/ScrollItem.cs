using UnityEngine;
using UnityEngine.UI;

public class ScrollItem : MonoBehaviour
{
    [SerializeField] int direction;

    private void Start()
    {
        int min = 0;
        int maxIndex = transform.parent.childCount - 1;

        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
        {
            int currentIndex = transform.GetSiblingIndex();
            int destinationIndex = currentIndex += direction;

            if(destinationIndex < min)
            {
                destinationIndex = maxIndex;
            }
            else if(destinationIndex > maxIndex)
            {
                destinationIndex = min;
            }

            transform.SetSiblingIndex(destinationIndex);
        });
    }
}
