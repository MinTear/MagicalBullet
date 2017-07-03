/*********************************************************
 * 
 * SoundPlayer.csの使い方は
 * http://marupeke296.com/UNI_SND_No3_SoundPlayer.html
 * 参照のこと
 * 
*********************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer
{
    #region Singleton
    private static SoundPlayer _instance;

    public static SoundPlayer Instance
    {
        get
        {
            _instance = _instance ?? new SoundPlayer();
            return _instance;
        }
    }
    #endregion 

    #region Member
    // AudioClip information
    private SoundPlayer()
    {
        //ここに曲を追加します。ここから
        audioClips.Add(Sounds.Explosion, new AudioClipInfo("bomb3", "explosionSE"));
        audioClips.Add(Sounds.Decided, new AudioClipInfo("DecidedVoice", "Decided"));

        //ここまでの行は自分で追加したの以外は削除しないようにおねがいします。
    }
    private GameObject soundPlayerObj;
    private Dictionary<Sounds, AudioClipInfo> audioClips = new Dictionary<Sounds, AudioClipInfo>();
    private AudioSource audioSource;


    public bool PlaySE(Sounds sound)
    {
        if (audioClips.ContainsKey(sound) == false)
            return false; // not register

        AudioClipInfo info = audioClips[sound];

        // Load
        if (info.Clip == null)
            info.Clip = (AudioClip)Resources.Load(info.ResourceName);

        if (soundPlayerObj == null)
        {
            soundPlayerObj = new GameObject("SoundPlayer");
            audioSource = soundPlayerObj.AddComponent<AudioSource>();
        }

        // Play SE
        audioSource.PlayOneShot(info.Clip);

        return true;
    }

    public bool PlaySE(Sounds sound, float volume)
    {
        if (audioClips.ContainsKey(sound) == false)
            return false; // not register

        AudioClipInfo info = audioClips[sound];

        // Load
        if (info.Clip == null)
            info.Clip = (AudioClip)Resources.Load(info.ResourceName);

        if (soundPlayerObj == null)
        {
            soundPlayerObj = new GameObject("SoundPlayer");
            audioSource = soundPlayerObj.AddComponent<AudioSource>();
        }

        // Play SE
        audioSource.PlayOneShot(info.Clip, volume);

        return true;
    }
    #endregion

    #region EnclosingTypes
    public enum Sounds
    {
        Explosion,
        Decided
    }

    protected class AudioClipInfo
    {
        public readonly string ResourceName;
        public readonly string Name;
        public AudioClip Clip;

        public AudioClipInfo(string resourceName, string name)
        {
            this.ResourceName = resourceName;
            this.Name = name;
        }
    }
    #endregion

}
