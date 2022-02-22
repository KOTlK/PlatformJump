public class PlayerInput
{
    private IPlayerInput _playerInput;
    private Player _player;

    public PlayerInput(Player player)
    {
        _player = player;
    }

    public void Init(IPlayerInput input)
    {
        _playerInput = input;
        Subscribe();
    }

    public void ChangeInputType(IPlayerInput input)
    {
        Unsubscribe();

        _playerInput = input;

        Subscribe();
    }

    public void Update()
    {
        _playerInput.UpdateInput();
    }

    private void Subscribe()
    {
        _playerInput.HorizontalAxisChanged += _player.Move;
        _playerInput.DebugButtonPressed += _player.Jump;
    }

    private void Unsubscribe()
    {
        _playerInput.HorizontalAxisChanged -= _player.Move;
        _playerInput.DebugButtonPressed -= _player.Jump;
    }


}
