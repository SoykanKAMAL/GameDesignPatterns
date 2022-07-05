using System;

namespace CommandPattern
{
    public class MoveCommand : ICommand
    {
        public static Action<MoveCommand> OnCommandCreated;
        public static Action<MoveCommand> OnCommandExecuted;
        public static Action<MoveCommand> OnCommandUndone;
    
        public readonly MoveDirection direction;
        public readonly MoveDirection undoDirection;
        private float _executeTime;
        protected MovingObject MovingObjectInstance { get; }

        public MoveCommand (MovingObject movingObjectInstance, float executeTime, MoveDirection direction, MoveDirection undoDirection)
        {
            MovingObjectInstance = movingObjectInstance;
            _executeTime = executeTime;
            this.direction = direction;
            this.undoDirection = undoDirection;
        
            OnCommandCreated?.Invoke(this);
        }

        public float GetExecutionTime()
        {
            return _executeTime;
        }

        public virtual void Execute()
        {
            OnCommandExecuted?.Invoke(this);
            MovingObjectInstance.Move(direction);
        }

        public virtual void Undo()
        {
            OnCommandUndone?.Invoke(this);
            MovingObjectInstance.Move(undoDirection);
        }
    
        public MoveDirection GetMoveDirection() => direction;
    
    
        // ToString()
        public override string ToString()
        {
            return $"Move: {direction}";
        }
    }
}