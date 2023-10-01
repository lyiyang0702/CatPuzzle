using System;

public static class LifeTimeBroadCaster
{
    public static event EventHandler OnNextLevelEvent;
    public static event EventHandler OnQuit;

    public static void ProceedLevel()
    {
        OnNextLevelEvent.Invoke(null, EventArgs.Empty);
    }

    public static void Quit()
    {
        OnQuit.Invoke(null, EventArgs.Empty);
    }
}
