﻿using UnityEngine;
using ILogger = NickoJ.DinoRunner.Core.ILogger;

namespace NickoJ.DinoRunner.Engine
{
    internal sealed class UnityLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}