using System;
namespace Commander.WASM.Shared
{
    public partial class Command : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CommandString { get; set; } = null!;
        public string Parameters { get; set; } = null!;
        public string ParametersSummary { get; set; } = null!;
        public string RuntimeEnvironment { get; set; } = null!;
        public string OperatingSystem { get; set; } = null!;
    }
}

