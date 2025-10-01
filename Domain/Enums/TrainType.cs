namespace Domain.Enums
{
    /// <summary>
    /// Type of train in domain
    /// </summary>
    [Flags]
    public enum TrainType : byte
    {
        Passenger = 0b_00000000,
        Service = 0b_00000001,
    }
}
