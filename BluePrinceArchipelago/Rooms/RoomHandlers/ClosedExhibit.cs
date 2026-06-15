namespace BluePrinceArchipelago.Rooms.RoomHandlers;

public class ClosedExhibit : RoomHandler
{
    public ClosedExhibit()
    {
        AllowanceTokens.Add("Closed Exhibit");
    }

    public override void OnAllowanceTokenCollected()
    {
        ModInstance.ModEventHandler.OnMoraJaiSolved("Closed Exhibit");
    }
}