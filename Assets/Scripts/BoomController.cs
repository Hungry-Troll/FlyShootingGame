using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : itemController
{
    PlayerController playerController;
    protected override void ItemGain()
    {
        playerController = base.player.GetComponent<PlayerController>();
        if (playerController.Boom < 4)
        {
            playerController.Boom++;
        }
    }
}
