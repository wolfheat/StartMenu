using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    public void UpdateSound()
    {
        Debug.Log("Music "+music.value);
        Debug.Log("SFX "+sfx.value);
        SoundMaster.Instance.UpdateVolume(master.value,music.value, sfx.value);


    }
}
