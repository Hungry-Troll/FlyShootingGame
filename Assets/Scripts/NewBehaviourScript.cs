using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        Orc orc1 = new Orc();
        Orc orc2 = new Orc();

        orc1.damage = 5;
        orc1.defence = 10;
        orc2.damage = 10;
        orc2.defence = 10;

        orc1 = orc2;
        orc1.defence = 20;

        Debug.Log("��ũ1 ���ݷ�: " + orc1.damage);
        Debug.Log("��ũ1 ����: " + orc1.defence);
        Debug.Log("��ũ2 ���ݷ�: " + orc2.damage);
        Debug.Log("��ũ2 ����: " + orc2.defence);

    }
}

struct Orc
{
    public int damage;
    public int defence;
}
