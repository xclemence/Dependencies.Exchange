﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dependencies.Exchange.Base.Models
{

    [DebuggerDisplay("Name = {ShortName}, Version = {Version}, FullName = {Name}")]
    public record AssemblyExchange
    {
        public string Name { get; init; }

        public string ShortName { get; init; } 

        public bool IsNative { get; init; }

        public string Version { get; init; } 

        public string Creator { get; init; } 

        public string TargetFramework { get; init; } 

        public string TargetProcessor { get; init; } 

        public bool? IsDebug { get; init; }

        public bool IsILOnly { get; init; }

        public DateTime CreationDate { get; init; }

        public bool IsPartial { get; init; }

        public bool IsLocal { get; init; }
        public bool HasEntryPoint { get; init; }

        public List<string> AssembliesReferenced { get; init; } = new List<string>();
    }
}