using UnityEngine;

public class UserSettings: ScriptableObject
{
    public float MusicVolume { get; private set; }
    public float SfxVolume { get; private set; }

    private void OnEnable()
    {
        MusicVolume = PlayerPrefs.GetFloat(PrefsKeys.MUSIC_Volume_Key, 0.5f);
        SfxVolume = PlayerPrefs.GetFloat(PrefsKeys.SFX_Volume_Key, 0.5f);
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume =volume;
        PlayerPrefs.SetFloat(PrefsKeys.MUSIC_Volume_Key, MusicVolume);
    }

    public void SetSfxVolume(float volume)
    {
        SfxVolume = volume;
        PlayerPrefs.SetFloat(PrefsKeys.SFX_Volume_Key, SfxVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(PrefsKeys.MUSIC_Volume_Key, MusicVolume);
        PlayerPrefs.SetFloat(PrefsKeys.SFX_Volume_Key, SfxVolume);
    }
}
