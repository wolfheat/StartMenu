using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void AnimationComplete()
    {
        StartMenuController.Instance.ButtonAnimationComplete();
    }
}
