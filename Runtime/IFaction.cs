namespace TravisRFrench.Factions.Runtime
{
    public interface IFaction
    {
        FactionAttitude GetAttitudeWithFaction(IFaction faction);
    }
}
