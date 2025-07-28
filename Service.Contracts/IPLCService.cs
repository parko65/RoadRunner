namespace Service.Contracts;
public interface IPLCService
{
    Task<bool> CheckMixerReadyAsync();
}
