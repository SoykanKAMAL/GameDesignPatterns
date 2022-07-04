namespace CommandPattern
{
    public interface ICommand
    {
        float GetExecutionTime();

        MoveDirection GetMoveDirection();
        void Execute();

        void Undo();
    
        string ToString();
    }
}
