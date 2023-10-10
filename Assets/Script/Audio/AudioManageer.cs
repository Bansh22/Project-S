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
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmPlayer");//�����Ϸ��� ��ȣ�ȿ�
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>(); //������Ʈ ����
        bgmPlayer.playOnAwake = false; //�ٷ� �۵��Ǵ°� ����.�ѹ��� ���X
        bgmPlayer.loop = true; //�ݺ�
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        

        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index=0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false; //�ٷ� �۵��Ǵ°� ����.�ѹ��� ���X
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
