using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void Open(int i)
    {
        switch(i)
        {
            case 0: break;
            case 1: break;
            case 2: UIManager.Instance.ShowCanvas(CanvasName.progress); break;
            case 3: UIManager.Instance.ShowCanvas(CanvasName.contacts); break;
            case 4: UIManager.Instance.ShowCanvas(CanvasName.exit); break;
        }

        Destroy(gameObject);
    }
}