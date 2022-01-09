namespace DITutorial
{
    public interface IShipInput
    {
        void ReadInput();
        float Rotation { get; }
        float Thrust { get; }
    }
}
