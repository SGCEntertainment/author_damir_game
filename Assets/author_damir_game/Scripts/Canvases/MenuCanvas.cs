using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void Exit()
    {
        UIManager.Instance.ShowCanvas(CanvasName.exit);
    }
}