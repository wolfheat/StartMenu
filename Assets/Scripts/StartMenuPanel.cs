using UnityEngine;

public class StartMenuPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void Disable()
    {
        StartMenuController.Instance.MenuAnimationComplete();
        panel.SetActive(false);
    }
}
