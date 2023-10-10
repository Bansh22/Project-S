using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioManageer : MonoBehaviour
{
    public static AudioManageer instance;
    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx { 
        Dead,
        Hit,
        LevelUp=3,
        Lose,
        Melee,
        Range=7,
        Select,
        Win
    }
    private void Awake()
    {
        instance = this;
        Init();
    }
    void Init()
    {
        //배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");//지정하려면 괄호안에
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>(); //컴포넌트 지정
        bgmPlayer.playOnAwake = false; //바로 작동되는거 차단.한번만 출력X
        bgmPlayer.loop = true; //반복
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        

        //효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index=0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false; //바로 작동되는거 차단.한번만 출력X
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;
            
            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }

    }

    public void PlayBgm()
    {
        bgmPlayer.Play();
    }
}
