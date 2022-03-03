using System.Collections.Generic;

public class GamePause : IPausable
{
    private List<IPausable> _pausables = new List<IPausable>();

    public bool IsPaused { get; private set; } = false;

    public void Register(IPausable pausable)
    {
        _pausables.Add(pausable);
    }
    public void Clear()
    {
        _pausables.Clear();
    }

    public void Pause()
    {
        if (_pausables.Count == 0) return;
        foreach (var pausable in _pausables)
        {
            pausable.Pause();
        }

        IsPaused = true;
    }

    public void UnPause()
    {
        if (_pausables.Count == 0) return;
        foreach (var pausable in _pausables)
        {
            pausable.UnPause();
        }

        IsPaused = false;
    }
}
