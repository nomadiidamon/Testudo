public class DashAbility : BaseAbility
{
    public override string AbilityName => "Dash";

    public override void Activate()
    {
        if (CanActivate())
        {
            UnityEngine.Debug.Log("Dash activated!");
        }
    }
}
