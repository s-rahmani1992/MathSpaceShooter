using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VFXSlider : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] UserSettings userSettings;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioClip clip;

    void Start () 
    {
        sfxSlider.value = userSettings.SfxVolume;
    }

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,-9), sfxSlider.value);
        userSettings.SetSfxVolume(sfxSlider.value);
    }
}
