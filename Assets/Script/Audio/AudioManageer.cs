using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManageer : MonoBehaviour
{
    public static AudioManageer instance;
    [Header("#BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;


    public enum Bgm { 
        Village,
        Battle1,
        Battle2,
        Battle3,
    }
    public enum Sfx { 
        Dead,
        Hit=3,
        LevelUp=4,
        Lose,
        Melee,
        Range=8,
        Select,
        Win
    }
    private void Awake()
    {
        instance = this;
        Init();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Town")
        {
            PlayBgm(AudioManageer.Bgm.Village);
        }
        else if (scene.name == "Stage1")
        {
            PlayBgm(AudioManageer.Bgm.Battle1);
        }
        else if (scene.name == "")
        {
            PlayBgm(AudioManageer.Bgm.Battle2);
        }
        else if (scene.name == "")
        {
            PlayBgm(AudioManageer.Bgm.Battle3);
        }
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

    public void PlayBgm(Bgm bgm)
    {
        bgmPlayer.clip = bgmClip[(int)bgm];
        bgmPlayer.Play();
    }
    public void StopBgm()
    {
        bgmPlayer.Stop();
    }
}
