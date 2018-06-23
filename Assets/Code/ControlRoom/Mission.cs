namespace Code.ControlRoom
{
    public interface Mission
    {
        string Description { get; }
        int Reward { get; }
        bool IsComplete { get; }
        void CheckCompletion();
        void Complete();
    }
}
