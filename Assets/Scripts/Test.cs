using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // static

    public class Orc
    {
        public int hp;
        public int dropGold;

        void test()
        {
            hp = 10;
        }
    }

    void Start()
    {
        Orc orc1 = new Orc();
        orc1.hp = 10;


        #region
       /* Orc.hp = 10;
        Orc.dropGold = 10;

        Orc.hp = 20;
        Orc.dropGold = 20;

        Orc.hp = 30;
        Orc.dropGold = 30;

        Debug.Log("Orc hp: " + Orc.hp + " Orc dropGold :" + Orc.dropGold);*/
        #endregion
    }
}


