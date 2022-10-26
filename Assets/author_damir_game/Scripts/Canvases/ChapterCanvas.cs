using UnityEngine;

public class ChapterCanvas : MonoBehaviour
{
    int index = 0;

    [HideInInspector]
    public int chapterId;

    Transform[] etaps;

    public string chapterNameRu;
    public string chapterNameEn;

    [Space(10)]
    [TextArea] public string winTextRu;
    [TextArea] public string winTextEn;

    [Space(10)]
    public Sprite achSprite;

    private void Start()
    {
        etaps = new Transform[transform.childCount];
        for(int i = 0; i < etaps.Length; i++)
        {
            etaps[i] = transform.GetChild(i);
        }

        foreach(Transform t in etaps)
        {
            t.gameObject.SetActive(t.GetSiblingIndex() == index);
        }
    }

    public void Next()
    {
        index++;
        if(index >= etaps.Length)
        {
            ProgressManager.LastChapterID = chapterId;
            GameObject completeCanvas = UIManager.Instance.ShowCanvas(CanvasName.complete);
            bool lastChapter = chapterId == ProgressManager.Instance.MaxChapters - 1;
            string contBtnString = lastChapter ? UITranslatUtil.GetUIString(10) : UITranslatUtil.GetUIString(9);
            completeCanvas.GetComponent<CompleteCanvas>().Init(LanguageUtil.IsRussian() ? winTextRu: winTextEn, contBtnString, achSprite, () =>
            {
                if(chapterId == ProgressManager.Instance.MaxChapters - 1)
                {
                    UIManager.Instance.ShowCanvas(CanvasName.menu);
                }
            });

            string chapterName = LanguageUtil.IsRussian() ? chapterNameRu : chapterNameEn;
            NavigationCanvas.Instance.UpdateNavigation(false, chapterName, false, true);
            return;
        }

        foreach (Transform t in etaps)
        {
            t.gameObject.SetActive(t.GetSiblingIndex() == index);
        }
    }
}
