using System;
using MeaData;
using System.Collections.Generic;

namespace MEACruncher {

    static class EntityStack {
        // VARIABLES
        private static Stack<Entity> _stack;
        private static bool _initialized = false;

        // INTERFACE FUNCTIONS
        public static void Push(Entity e) {
            if (!_initialized)
                initialize();

            // Only push non-null elements
            if (e == null)
                throw new ArgumentNullException();
            _stack.Push(e);
        }
        public static Entity Pop() {
            // If the stack hasn't been initialzed yet, don't throw an exception, just return null
            if (!_initialized) {
                initialize();
                return null;
            }

            return _stack.Pop();
        }

        // HELPER FUNCTIONS
        private static void initialize() {
            _stack = new Stack<Entity>();
            _initialized = true;
        }
    }

}