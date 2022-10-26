using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private static ProgressManager instance;
    public static ProgressManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<ProgressManager>();
            }

            return instance;
        }
    }

    const string lastChapterId = "lastChapterId";

    Transform canvasParent;

    private void Start()
    {
        canvasParent = GameObject.Find("Canvases").transform;
    }

    public static bool HasProgress
    {
        get => PlayerPrefs.HasKey(lastChapterId);
    }

    public static int LastChapterID
    {
        get => PlayerPrefs.GetInt(lastChapterId, -1);
        set => PlayerPrefs.SetInt(lastChapterId, value);
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(lastChapterId);
        PlayerPrefs.Save();
    }

    public int MaxChapters
    {
        get => chapterCanvas.Length;
    }

    [SerializeField] ChapterCanvas[] chapterCanvas;

    public GameObject OpenChapter(int id, out string chapterName)
    {
        ChapterCanvas _chapter = Instantiate(chapterCanvas[id], canvasParent).GetComponent<ChapterCanvas>();
        _chapter.chapterId = id;

        chapterName = LanguageUtil.IsRussian() ? _chapter.chapterNameRu : _chapter.chapterNameEn;

        return _chapter.gameObject;
    }
}
