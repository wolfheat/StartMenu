using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    public void UpdateSound()
    {
        SoundMaster.Instance.UpdateVolume(master.value,music.value, sfx.value);
    } 
    public void SFXSliderChange()
    {
        SoundMaster.Instance.PlaySound(SoundName.MenuClick);
    }
}
