using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public static Action<ICommand?> OnCurrentCommandChanged;
    private Queue<ICommand> _commands = new Queue<ICommand>();
    private Stack<ICommand> _undoCommands = new Stack<ICommand>();
    private ICommand _currentExecutingCommand;

    private void Start()
    {
        OnCurrentCommandChanged?.Invoke(null);
    }

    public void AddCommand(ICommand command)
    {
        _commands.Enqueue(command);
    }
    
    public void ExecuteAllCommands()
    {
        StartCoroutine(ExecuteAllCommandsCoroutine());
    }

    public void ExecuteOneCommand()
    {
            StartCoroutine(ExecuteCommand());
    }

    public void UndoLastCommand()
    {
        if(_currentExecutingCommand != null) return;
        if (_undoCommands.Count <= 0) return;
        
        var command = _undoCommands.Pop();
        command.Undo();
    }

    private IEnumerator ExecuteAllCommandsCoroutine()
    {
        while (_commands.Count > 0)
        {
            yield return StartCoroutine(ExecuteCommand());
        }
    }
    
    private IEnumerator ExecuteCommand()
    {
        var command = _commands.Dequeue();
        _currentExecutingCommand = command;
        OnCurrentCommandChanged?.Invoke(_currentExecutingCommand);
        command.Execute();
        yield return new WaitForSeconds(command.GetExecutionTime());
        _currentExecutingCommand = null;
        OnCurrentCommandChanged?.Invoke(_currentExecutingCommand);
        _undoCommands.Push(command);
    }
}