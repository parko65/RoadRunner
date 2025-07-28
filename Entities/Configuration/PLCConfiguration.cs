using libplctag;

namespace Entities.Configuration;
public class PLCConfiguration
{
    public PLCCommunications? PLCCommunications { get; set; }
    public PLCStatusBlock? PLCStatusBlock { get; set; }
}

public class PLCCommunications
{
    public string? IPAddress { get; set; }
    public PlcType PlcType { get; set; }
    public string? Path { get; set; }
    public Protocol Protocol { get; set; }
}

public class PLCStatusBlock
{
    public string? StatusReadBlock { get; set; }
    public string? StatusReadStart { get; set; }
}
