using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    private void Start()
    {
        transform.Find("buttons").Find("continue").GetComponent<Button>().interactable = ProgressManager.HasProgress;
    }

    public void Open(int i)
    {
        switch(i)
        {
            case 0: break;
            case 1:
                UIManager.Instance.ShowCanvas(CanvasName.newgame);
                break;

            case 2: 
                UIManager.Instance.ShowCanvas(CanvasName.progress);;
                NavigationCanvas.Instance.UpdateNavigation(true, UITranslatUtil.GetUIString(2), false, true);
                break;

            case 3: 
                UIManager.Instance.ShowCanvas(CanvasName.contacts);
                NavigationCanvas.Instance.UpdateNavigation(true, UITranslatUtil.GetUIString(3), false, true);
                break;

            case 4: UIManager.Instance.ShowCanvas(CanvasName.exit); break;
        }
    }
}