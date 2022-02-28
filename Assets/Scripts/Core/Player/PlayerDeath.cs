using System;

public class PlayerDeath
{
    public static event Action Died;

    private readonly LowerBorder _lowerBorder;

    public PlayerDeath(LowerBorder border)
    {
        _lowerBorder = border;
        _lowerBorder.PlayerTouched += Die;
    }

    private void Die(Player player)
    {
        player.Disable();
        Died?.Invoke();
        _lowerBorder.PlayerTouched -= Die;
    }
}
