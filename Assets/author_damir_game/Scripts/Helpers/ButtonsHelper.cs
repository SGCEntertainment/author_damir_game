using UnityEngine;

public class ButtonsHelper : MonoBehaviour
{
    [SerializeField] GameObject continueGo;

    private void Start()
    {
        continueGo.SetActive(false);
    }

    public void EnableContinue()
    {
        continueGo.SetActive(true);
    }
}
