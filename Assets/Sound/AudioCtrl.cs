using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static AudioCtrl instance;
    public static AudioCtrl Instance => instance;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip shoot;
    [SerializeField] protected AudioClip explode;
    [SerializeField] protected AudioClip FireProjectile;
    [SerializeField] protected AudioClip bgMusic;
    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Exceed Audio Ctrl");
        instance = this;
    }

    protected virtual void Start()
    {
        //this.audioSource.
    }
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        audioSource = GetComponentInChildren<Camera>().GetComponent<AudioSource>();
    }

    public virtual void PlayShootSoundFX()
    {
        this.audioSource.PlayOneShot(shoot);
    }
    public virtual void ExplodeSoundFX()
    {
        this.audioSource.PlayOneShot(explode);
    }

    public virtual void FireProjectileFX()
    {
        this.audioSource.PlayOneShot(FireProjectile);
    }



    //protected abstract AudioClip SetAudioClip(string audioClip);
    
}
