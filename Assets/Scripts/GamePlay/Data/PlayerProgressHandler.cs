public class PlayerProgressHandler : IPlayerProgressHandler
{
    private PlayerProgress _playerProgress;

    public PlayerProgress PlayerProgress 
    { 
        get => _playerProgress; 
        set => _playerProgress = value; 
    }
}
