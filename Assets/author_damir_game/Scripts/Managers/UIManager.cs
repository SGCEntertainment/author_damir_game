using UnityEditor;
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

    GameObject canvasGORef;
    GameObject choiseCanvasRef;

    CanvasName lastCanvasNameRef;


    [Space(10)]
    [SerializeField] GameObject languageCanvas;
    [SerializeField] GameObject splashCanvas;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject contactsCanvas;
    [SerializeField] GameObject progressCanvas;
    [SerializeField] GameObject choiceCanvas;

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
        if (!choiseCanvasRef && Input.GetKeyDown(KeyCode.Escape))
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
        GameObject canvasPrefab = GetCanvasPrefab(canvasName);
        if(canvasGORef && canvasPrefab != choiceCanvas)
        {
            Destroy(canvasGORef);
        }

        switch (canvasName)
        {
            case CanvasName.language: Instantiate(canvasPrefab, parentRef); break;
            case CanvasName.splash: Instantiate(canvasPrefab, parentRef); break;

            case CanvasName.exit: choiseCanvasRef = Instantiate(canvasPrefab, parentRef);
                choiseCanvasRef.GetComponent<ChoiceCanvas>().Init("Вы точно хотите выйти из игры?", () => 
                { 
                    Application.Quit(); 
                });
                break;

            case CanvasName.menu: 
                canvasGORef = Instantiate(canvasPrefab, parentRef);
                NavigationCanvas.Instance.UpdateNavigation();
                break;

            case CanvasName.contacts: 
                canvasGORef = Instantiate(canvasPrefab, parentRef);
                lastCanvasNameRef = CanvasName.menu;
                break;

            case CanvasName.progress: 
                canvasGORef = Instantiate(canvasPrefab, parentRef);
                lastCanvasNameRef = CanvasName.menu;
                break;
        }
    }

    GameObject GetCanvasPrefab(CanvasName canvasName) => canvasName switch
    {
        CanvasName.language => languageCanvas,
        CanvasName.splash => splashCanvas,
        CanvasName.exit => choiceCanvas,
        CanvasName.menu => menuCanvas,
        CanvasName.contacts => contactsCanvas,
        CanvasName.progress => progressCanvas,

        _ => languageCanvas
    };

    public void Back()
    {
        if(canvasGORef)
        {
            Destroy(canvasGORef);
        }

        ShowCanvas(lastCanvasNameRef);
    }
}
