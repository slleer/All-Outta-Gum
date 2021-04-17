using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCommand : Command
{
    public Player player;
    public FollowCommand (Target tget) : base(tget)
    {
        player = Player.inst;
    }

    public override void Init()
    {

    }

    public override void Tick()
    {

    }

    public override bool IsDone()
    {
        return false;
    }
    public override void Stop()
    {

    }
}
