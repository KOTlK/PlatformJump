using System;

public class PlayerDeath
{
    private readonly LowerBorder _lowerBorder;

    public PlayerDeath(LowerBorder border)
    {
        _lowerBorder = border;
        _lowerBorder.PlayerTouched += Die;
    }

    private void Die(Player player)
    {
        player.Disable();
        GameContext.Instance.Runtime.EndGame();
        _lowerBorder.PlayerTouched -= Die;
    }
}
