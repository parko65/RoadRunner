namespace Service.Contracts;
public interface IPLCService
{
    Task<bool> CheckMixerReadyAsync();
    Task SendMixingDataAsync();
}
