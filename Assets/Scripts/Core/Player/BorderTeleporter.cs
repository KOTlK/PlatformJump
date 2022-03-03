using System;

public enum BorderSide
{
    Left,
    Right,
    Lower,
    Upper,
}

public class BorderTeleporter
{
    private readonly Player _player;
    private readonly IBorderTouchAwaiter _touchAwaiter;

    public BorderTeleporter(Player player)
    {
        _player = player;
        _touchAwaiter = new BorderTouchAwaiter();
        _touchAwaiter.BorderTouched += FlipSides;
    }

    public void Update()
    {
        _touchAwaiter.WaitTouch(_player.transform.position);
    }


    private void FlipSides(BorderSide side)
    {
        var position = _player.transform.position;
        position.x = GetSideReversePosition(side);
        _player.transform.position = position;
    }

    private float GetSideReversePosition(BorderSide side)
    {
        switch (side)
        {
            case BorderSide.Left:
                return CameraBounds.Max.x;
            case BorderSide.Right:
                return CameraBounds.Min.x;
            default: throw new Exception($"No data for side {side}");
        }
    }

    
}
