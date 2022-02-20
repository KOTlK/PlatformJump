using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerInput
{
    private IPlayerInput _playerInput;
    private Player _player;

    public PlayerInput(Player player)
    {
        _player = player;
        _playerInput = new KeyboardInput();
        _playerInput.HorizontalAxisChanged += _player.Move;
        _playerInput.DebugButtonPressed += _player.Jump;
    }

    public void Update()
    {
        _playerInput.UpdateInput();
    }


}
