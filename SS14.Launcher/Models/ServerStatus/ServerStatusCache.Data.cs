using System;
using System.Threading;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace SS14.Launcher.Models.ServerStatus;

public sealed class ServerStatusData : ObservableObject, IServerStatusData
{
    private string? _name;
    private string? _desc;
    private TimeSpan? _ping;
    private int _playerCount;
    private int _softMaxPlayerCount;
    private ServerStatusCode _status = ServerStatusCode.FetchingStatus;
    private ServerStatusInfoCode _statusInfo = ServerStatusInfoCode.NotFetched;
    private ServerInfoLink[]? _links;

    public ServerStatusData(string address)
    {
        Address = address;
    }

    public string Address { get; }

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string? Description
    {
        get => _desc;
        set => SetProperty(ref _desc, value);
    }

    // BUG: This ping stat is completely wrong currently.
    // See the assignment in ServerStatusCache.cs for why.
    public TimeSpan? Ping
    {
        get => _ping;
        set => SetProperty(ref _ping, value);
    }

    public ServerStatusCode Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public ServerStatusInfoCode StatusInfo
    {
        get => _statusInfo;
        set => SetProperty(ref _statusInfo, value);
    }

    public int PlayerCount
    {
        get => _playerCount;
        set => SetProperty(ref _playerCount, value);
    }

    public int SoftMaxPlayerCount
    {
        get => _softMaxPlayerCount;
        set => SetProperty(ref _softMaxPlayerCount, value);
    }

    public ServerInfoLink[]? Links
    {
        get => _links;
        set => SetProperty(ref _links, value);
    }

    public CancellationTokenSource? InfoCancel;
}
