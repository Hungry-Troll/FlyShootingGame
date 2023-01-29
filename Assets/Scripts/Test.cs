using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public class Orc
    {
        public int hp;
        public int dropGold;
    }

    void Start()
    {
        #region
        Orc orc1 = new Orc();
        Orc orc2 = new Orc();
        Orc orc3 = new Orc();

        orc1.hp = 10;
        orc1.dropGold = 10;

        orc2.hp = 20;
        orc2.dropGold = 20;

        orc3.hp = 30;
        orc3.dropGold = 30;

        Debug.Log("orc1 hp :" + orc1.hp + "  orc1 dropGold :" + orc1.dropGold);
        Debug.Log("orc1 hp :" + orc2.hp + "  orc1 dropGold :" + orc2.dropGold);
        Debug.Log("orc1 hp :" + orc3.hp + "  orc1 dropGold :" + orc3.dropGold);
        #endregion
        /*        Orc.hp = 10;
                Orc.dropGold = 10;

                Orc.hp = 20;
                Orc.dropGold = 20;

                Orc.hp = 30;
                Orc.dropGold = 30;

                Debug.Log("orc1 hp :" + Orc.hp + "  orc1 dropGold :" + Orc.dropGold);*/
    }
}


