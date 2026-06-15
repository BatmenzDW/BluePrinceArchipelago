namespace BluePrinceArchipelago.Rooms.RoomHandlers;

public class MasterBedroom : RoomHandler
{
    public MasterBedroom()
    {
        AllowanceTokens.Add("Master Bedroom");
    }

    public override void OnAllowanceTokenCollected()
    {
        ModInstance.ModEventHandler.OnMoraJaiSolved("Master Bedroom");
    }
}