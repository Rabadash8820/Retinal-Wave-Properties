using System;
using System.Reflection;
using System.Collections.Generic;

namespace MEACruncher {

    public class Memento {
        // VARIABLES
        protected object _originator;
        protected string _property;
        protected object _oldValue;
        protected object _newValue;

        // CONSTRUCTORS
        public Memento(string message, object target, string property, object oldValue, object newValue) {
            Message = message;
            _originator = target;
            _property = property;
            _oldValue = oldValue;
            _newValue = newValue;
        }

        // PROPERTIES
        public string Message { get; protected set; }

        // METHODS
        public void Undo() {
            restoreTo(_oldValue);
        }
        public void Redo() {
            restoreTo(_newValue);
        }
        private void restoreTo(object value) {
            PropertyInfo prop = _originator.GetType().GetProperty(_property);
            prop.SetValue(_originator, value);
        }
    }

    public class MementoManager {
        // VARIABLES
        private Stack<Memento> _undoStack;
        private Stack<Memento> _redoStack;

        // CONSTRUCTORS
        public MementoManager() {
            this.initialize();
        }

        // PROPERTIES
        public bool CanUndo {
            get { return _undoStack.Count != 0; }
        }
        public bool CanRedo {
            get { return _redoStack.Count != 0; }
        }
        public string TopUndoMessage {
            get {
                if (_undoStack.Count != 0)
                    return _undoStack.Peek().Message;
                else
                    return "Cannot undo.";
            }
        }
        public string TopRedoMessage {
            get {
                if (_redoStack.Count != 0)
                    return _redoStack.Peek().Message;
                else
                    return "Cannot redo.";
            }
        }

        // METHODS
        public void Store(Memento m) {
            _undoStack.Push(m);
            _redoStack.Clear();
        }
        public void Store(string message, object target, string property, object oldValue, object newValue) {
            this.Store(new Memento(message, target, property, oldValue, newValue));
        }
        public void Undo() {
            manage(_undoStack, _redoStack, m => m.Undo());
        }
        public void Redo() {
            manage(_redoStack, _undoStack, m => m.Redo());
        }

        // HELPER FUNCTIONS
        private void initialize() {
            _undoStack = new Stack<Memento>();
            _redoStack = new Stack<Memento>();
        }
        private void manage(Stack<Memento> fromStack, Stack<Memento> toStack, Action<Memento> action) {
            // If there's still a Memento in the first stack, then push it to the other stack
            if (fromStack.Count == 0)
                return;
            Memento m = fromStack.Pop();
            toStack.Push(m);

            // Manage this Memento in the requested way
            action(m);
        }

    }

}