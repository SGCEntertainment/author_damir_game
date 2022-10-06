using UnityEngine;

public class ExitCanvas : MonoBehaviour
{
    public void Exit(bool accept)
    {
        if(!accept)
        {
            Destroy(gameObject);
        }

        Application.Quit();
    }
}
