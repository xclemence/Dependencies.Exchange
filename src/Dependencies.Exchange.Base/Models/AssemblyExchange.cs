using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dependencies.Exchange.Base.Models
{

    [DebuggerDisplay("Name = {ShortName}, Version = {Version}, FullName = {Name}")]
    public record AssemblyExchange
    {
        public string Name { get; init; } = string.Empty;

        public string ShortName { get; init; } = string.Empty;

        public bool IsNative { get; init; }

        public string Version { get; init; } = string.Empty;

        public string Creator { get; init; } = string.Empty;

        public string TargetFramework { get; init; } = string.Empty;

        public string TargetProcessor { get; init; } = string.Empty;

        public bool? IsDebug { get; init; }

        public bool IsILOnly { get; init; }

        public DateTime CreationDate { get; init; }

        public bool IsPartial { get; init; }

        public bool IsLocal { get; init; }
        public bool HasEntryPoint { get; init; }

        public List<string> AssembliesReferenced { get; init; } = new ();
    }
}