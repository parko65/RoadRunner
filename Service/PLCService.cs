using Contracts;
using Entities.Configuration;
using libplctag;
using libplctag.DataTypes;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;
internal sealed class PLCService : IPLCService
{
    private readonly IOptionsMonitor<PLCConfiguration> _plcMonitor;
    private readonly ILoggerManager _logger;    

    public PLCService(IOptionsMonitor<PLCConfiguration> plcMonitor, ILoggerManager logger)
    {
        _plcMonitor = plcMonitor;
        _logger = logger;
    }

    public async Task<bool> CheckMixerReadyAsync()
    {
        var plcConfig = _plcMonitor.CurrentValue;

        var result = await ReadSingleValueAsync($"{plcConfig.PLCStatusBlock!.StatusReadBlock}[{plcConfig.PLCStatusBlock.StatusReadStart}]");

        if (result == 0)
        {            
            return true;
        }
        else
        {
            _logger.LogWarn($"Mixer is not ready. Alarm code: {result}");
            return false;
        }        
    }

    public async Task SendMixingDataAsync()
    {
        var plcConfig = _plcMonitor.CurrentValue;

        // Delete this line if you don't want to read the value
        var result = await ReadSingleValueAsync($"{plcConfig.PLCStatusBlock!.StatusReadBlock}[{plcConfig.PLCStatusBlock.StatusReadStart}]");
    }

    private Tag<IntPlcMapper, short[]> CreateTag(string tagName, int arrayLength)
    {
        var plcConfig = _plcMonitor.CurrentValue;

        return new Tag<IntPlcMapper, short[]>
        {
            Name = tagName,
            Gateway = plcConfig.PLCCommunications!.IPAddress,
            Path = plcConfig.PLCCommunications!.Path,
            PlcType = plcConfig.PLCCommunications!.PlcType,
            Protocol = plcConfig.PLCCommunications!.Protocol,
            ArrayDimensions = new int[] { arrayLength },
            Timeout = TimeSpan.FromMilliseconds(5000)
        };
    }

    private async Task<short[]?> ReadValueAsync(string tagName, int arrayLength)
    {
        var plcConfig = _plcMonitor.CurrentValue;

        try
        {
            var tag = CreateTag(tagName, arrayLength);
            var result = await tag.ReadAsync();

            if (result != null && result.Length > 0)
            {
                _logger.LogInfo($"Successfully read {result.Length} values from PLC tag '{tagName}' at address {plcConfig.PLCCommunications!.IPAddress}");
                return result;
            }
            else
            {
                _logger.LogWarn($"No data returned from PLC tag '{tagName}' at address {plcConfig.PLCCommunications!.IPAddress}");
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to read from PLC tag '{tagName}' at address {plcConfig.PLCCommunications!.IPAddress}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Reads a single value from the specified PLC tag
    /// </summary>
    private async Task<short?> ReadSingleValueAsync(string tagName)
    {
        var result = await ReadValueAsync(tagName, 1);
        return result?.Length > 0 ? result[0] : null;
    }
}
