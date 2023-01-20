using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : itemController
{
    PlayerController playerController;
    protected override void ItemGain()
    {
        playerController = base.player.GetComponent<PlayerController>();
        if(playerController.Damage < 3)
        {
            playerController.Damage++;
        }
    }
}
