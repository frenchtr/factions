namespace Factions
{
    public interface IFaction
    {
        FactionAttitude GetAttitudeWithFaction(IFaction faction);
    }
}
