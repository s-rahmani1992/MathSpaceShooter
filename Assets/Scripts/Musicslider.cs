using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] UserSettings userSettings;
    [SerializeField] Slider musicSlider;
    [SerializeField] AudioSource player;
    
    void Start () 
    {
        musicSlider.value = userSettings.MusicVolume;
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
    }
	
	void OnMusicChanged(float value) 
    {
        musicSlider.value = value;
        player.volume = value;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        userSettings.SetMusicVolume(musicSlider.value);
    }
}
