using System.Collections.Generic;

public class CommandHistory
{
	private Stack<IUndoable> undoStack = new Stack<IUndoable>();
	private Stack<IUndoable> redoStack = new Stack<IUndoable>();

	public void Add(IUndoable cmd)
	{
		undoStack.Push(cmd);
		redoStack.Clear();
	}

	public bool Undo()
	{
		bool result = undoStack.Count > 0;
		if (result)
		{
			IUndoable c = undoStack.Pop();
			redoStack.Push(c);
			c.Undo();
		}
		return result;
	}

	public bool Redo()
	{
		bool result = redoStack.Count > 0;
		if (result)
		{
			IUndoable c = redoStack.Pop();
			undoStack.Push(c);
			c.Redo();
		}
		return result;
	}
}
