using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : itemController
{
    PlayerController playerController;
    protected override void ItemGain()
    {
        playerController = base.player.GetComponent<PlayerController>();
        if(playerController.Boom < 3)
        {
            playerController.Boom++;
            UIManager.instance.BoomCheck(playerController.Boom);
        }
        if(playerController.Boom >= 3)
        {
            UIManager.instance.ScoreAdd(base.score);
        }
    }
}
