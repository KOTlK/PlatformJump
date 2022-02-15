using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlatformDestroyer
{
    public event Action<Platform> PlatformDestroyed;

    public void DestroyPlatform(Platform platform)
    {
        platform.Destroy();
        PlatformDestroyed?.Invoke(platform);
    }
}
