using System.Collections.Generic;

public class GamePause : IPausable
{
    private List<IPausable> _pausables = new List<IPausable>();

    public void Register(IPausable pausable)
    {
        _pausables.Add(pausable);
    }


    public void Pause()
    {
        if (_pausables.Count == 0) return;
        foreach (var pausable in _pausables)
        {
            pausable.Pause();
        }
    }

    public void UnPause()
    {
        if (_pausables.Count == 0) return;
        foreach (var pausable in _pausables)
        {
            pausable.UnPause();
        }
    }
}
