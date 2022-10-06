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

    GameObject exitCanvasRef;

    [SerializeField] Transform parent;

    [Space(10)]
    [SerializeField] GameObject languageCanvas;
    [SerializeField] GameObject splashCanvas;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject exitCanvas;

    private void Start()
    {
        CheckLanguageUI();
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
            case CanvasName.language: Instantiate(languageCanvas, parent); break;
            case CanvasName.splash: Instantiate(splashCanvas, parent); break;
            case CanvasName.exit: exitCanvasRef = Instantiate(exitCanvas, parent); break;
            case CanvasName.menu: Instantiate(menuCanvas, parent); ; break;
        }
    }
}
