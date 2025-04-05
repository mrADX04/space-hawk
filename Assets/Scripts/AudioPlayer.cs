using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    //singleton pattern is used to use the same instance of the class
    static AudioPlayer instance;

    //making the instance global for using **Way 2 of executiong singleton pattern**
    //but we will not be using this geetter method in our project
    // public AudioPlayer GetInstance()
    // {
    //     return instance;
    // }
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //**WAY 1 of executing singleton pattern (non-global way/method)**
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
       PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
       PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
