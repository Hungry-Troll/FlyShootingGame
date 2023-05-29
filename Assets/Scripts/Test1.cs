using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test2:MonoBehaviour
{
    void TestFunction1()
    {
        int hp = 10; //4바이트
        int mp = 10;
        long money = 100_100_100; // 8바이트
    }
}

public class Test3:MonoBehaviour
{
    static int global;

    void TestPulu()
    {
        global++;
    }

    void TestPulu2()
    {
        global++;
        global++;
    }
}

public class Test4: MonoBehaviour
{
    private void Start()
    {
        Test();
    }

    void Test()
    {
        int num1 = 1;
        int num2 = 2;
        float num3;
        char num4;
        bool num5;
        Debug.Log(num1);
        Debug.Log(num2);
    }


}

public class Test5 : MonoBehaviour
{
    private void Start()
    {
        Test(1,2);
    }

    void Test(int num1, int num2)
    {
        Debug.Log(num1);
        Debug.Log(num2);
    }
}

public class Orc
{
    // 대기
    // 이동
    // 공격
    // 사망

    public int hp = 10;
}
public class Test1:MonoBehaviour
{
    void Start()
    {
        Orc orc1 = new Orc();
        Orc orc2 = new Orc();
        Orc orc3 = new Orc();

        orc1.hp = 100;
        orc2.hp = 200;
        orc3.hp = 300;
    }
}


public class Test
{
    public void TestFunction()
    {

    }
}