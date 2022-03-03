using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runtime : IPausable
{
    public event Action<SessionStatus> StatusChanged;
    public event Action Paused;
    public event Action UnPaused;
    public event Action Restarted;

    public Runtime()
    {
        GamePause = new GamePause();
        StatusChanged += ChangeStatus;
        StatusChanged += LogStatus;
    }
    public GamePause GamePause { get; private set; }
    public SessionStatus Status { get; private set; }

    public void Pause()
    {
        GamePause.Pause();
        StatusChanged?.Invoke(SessionStatus.Paused);
        Paused?.Invoke();
    }

    public void UnPause()
    {
        GamePause.UnPause();
        StatusChanged?.Invoke(SessionStatus.Running);
        UnPaused?.Invoke();
    }

    public void Restart()
    {
        StatusChanged?.Invoke(SessionStatus.Restarting);

        GamePause.Clear();
        SceneManager.LoadScene(0);

        StatusChanged?.Invoke(SessionStatus.Restarted);
        Restarted?.Invoke();
    }

    private void ChangeStatus(SessionStatus status)
    {
        Status = status;
    }

    private void LogStatus(SessionStatus status)
    {
        Debug.Log(status);
    }
}


public enum SessionStatus
{
    Running,
    Paused,
    Restarted,
    Restarting,
}
