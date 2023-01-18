using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : itemController
{
    PlayerController playerController;
    protected override void ItemGain() 
    {
        if(playerController.Damage < 3)
        {
            playerController = base.player.GetComponent<PlayerController>();
            playerController.Damage++;
        }
    }
}
