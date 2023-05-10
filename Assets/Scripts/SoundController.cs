using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM;

    public void Start()
    {
        // ���
        BGM.Play();

        // ��Ʈ true >> ���Ұ�
        BGM.mute = true;

        // ���� true >> �ݺ�
        BGM.loop = true;

        // �ڵ� ��� true >> �ڵ����
        BGM.playOnAwake = true;

        // ����
        BGM.Stop();
    }
}
