using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Command
{
    public Target target;

    public Command(Target tget)
    {
        target = tget;
    }

    public virtual void Init()
    {

    }

    public virtual void Tick()
    {

    }

    public virtual bool IsDone()
    {
        return false;
    }
    public virtual void Stop()
    {

    }
}
