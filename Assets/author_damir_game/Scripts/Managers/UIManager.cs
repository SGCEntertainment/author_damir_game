using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    Transform parentRef;
    GameObject exitCanvasRef;

    [Space(10)]
    [SerializeField] GameObject languageCanvas;
    [SerializeField] GameObject splashCanvas;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject exitCanvas;
    [SerializeField] GameObject contactsCanvas;
    [SerializeField] GameObject progressCanvas;

    private void Start()
    {
        CacheComponents();
        CheckLanguageUI();
    }

    void CacheComponents()
    {
        parentRef = GameObject.Find("Canvases").transform;
    }

    private void Update()
    {
        if(!exitCanvasRef && Input.GetKeyDown(KeyCode.Escape))
        {
            ShowCanvas(CanvasName.exit);
        }
    }

    void CheckLanguageUI()
    {
        bool hasLang = LanguageUtil.LanguageIsSet();

        if (hasLang)
        {
            ShowCanvas(CanvasName.splash);
            return;
        }

        ShowCanvas(CanvasName.language);
    }

    public void ShowCanvas(CanvasName canvasName)
    {
        switch (canvasName)
        {
            case CanvasName.language: Instantiate(languageCanvas, parentRef); break;
            case CanvasName.splash: Instantiate(splashCanvas, parentRef); break;
            case CanvasName.exit: exitCanvasRef = Instantiate(exitCanvas, parentRef); break;
            case CanvasName.menu: Instantiate(menuCanvas, parentRef); break;
            case CanvasName.contacts: Instantiate(contactsCanvas, parentRef); break;
            case CanvasName.progress: Instantiate(progressCanvas, parentRef); break;
        }
    }
}
