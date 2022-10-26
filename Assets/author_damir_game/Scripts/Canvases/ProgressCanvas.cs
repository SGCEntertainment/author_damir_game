using UnityEngine;

public class ProgressCanvas : MonoBehaviour
{
    [SerializeField] Transform parent;

    private void Start()
    {
        CheckProgress();
    }

    void CheckProgress()
    {
        GameObject[] icons = new GameObject[parent.childCount];
        for(int i = 0; i < icons.Length; i++)
        {
            icons[i] = parent.GetChild(i).GetChild(1).gameObject;
            icons[i].SetActive(i <= ProgressManager.LastChapterID);
        }
    }
}
