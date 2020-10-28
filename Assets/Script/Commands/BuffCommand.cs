﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCommand : ICommand
{
    IBuffable _buffableToken;

    public BuffCommand(IBuffable buffableToken)
    {
        _buffableToken = buffableToken;
    }

    public void Execute()
    {
        _buffableToken.Buff();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

    public void UndoExecute()
    {
        _buffableToken.Unbuff();
    }
}
