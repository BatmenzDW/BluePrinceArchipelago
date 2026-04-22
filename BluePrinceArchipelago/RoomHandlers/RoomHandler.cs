namespace BluePrinceArchipelago.RoomHandlers;

public abstract class RoomHandler
{    
    public abstract void OnRoomDrafted();
    public static RoomHandler CreateRoomHandler(string roomName)
    {
        return roomName switch
        {
            "Commissary" => new Commissary(4, 1, 10, 0), // Placeholder values, should be set appropriately
            _ => null
        };
    }
}