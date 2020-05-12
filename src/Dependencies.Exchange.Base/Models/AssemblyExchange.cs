using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dependencies.Exchange.Base.Models
{

    [DebuggerDisplay("Name = {ShortName}, Version = {Version}, FullName = {Name}")]
    public class AssemblyExchange
    {
        public string Name { get; set; } = null!;

        public string ShortName { get; set; } = null!;

        public bool IsNative { get; set; }

        public string Version { get; set; } = null!;

        public string Creator { get; set; } = null!;

        public string TargetFramework { get; set; } = null!;

        public string TargetProcessor { get; set; } = null!;

        public bool? IsDebug { get; set; }

        public bool IsILOnly { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsPartial { get; set; }

        public bool IsLocal { get; set; }
        public bool HasEntryPoint { get; set; }

        public List<string> AssembliesReferenced { get; set; } = new List<string>();
    }
}