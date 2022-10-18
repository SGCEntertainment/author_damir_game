using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void Open(int i)
    {
        switch(i)
        {
            case 0: break;
            case 1: break;

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