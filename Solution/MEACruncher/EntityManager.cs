using System;
using System.Reflection;
using System.Collections.Generic;

using NHibernate;

using MeaData;
using MEACruncher.Resources;

namespace MEACruncher {
    internal static class EntityManager {
        // ENCAPSULATED FIELDS
        private static Stack<Entity> _stack;

        // INTERFACE
        static EntityManager() {
            _stack = new Stack<Entity>();
        }
        public static void Remember(Entity entity) {
            if (entity == null) return;
            _stack.Push(entity);
        }
        public static Entity Recall() {
            if (_stack.Count == 0) return null;
            return _stack.Pop();
        }

        // DELETE ENTITY WARNINGS
        public static string DeleteWarningMsg(Project entity) {
            return String.Format(DeleteRes.ProjectWarning, entity.Name);
        }

        // DUPLICATE ENTITY ERROR MESSAGES
        public static string DuplicateErrorMsg(Project entity) {
            string msg = String.Format(
                            DuplicateRes.ProjectError,
                            entity.Name,
                            entity.DateStarted.ToShortDateString());
            msg += ("\n\n" + DuplicateRes.Message);
            return msg;
        }

        // TEST ENTITIES FOR UNIQUENESS
        public static bool IsUnique(Project entity) {
            using (ISession db = Program.MeaDataDb.Session){
                int count = db.QueryOver<Project>()
                              .Where(e =>
                                e.Guid != entity.Guid &&
                                e.Name == entity.Name &&
                                e.DateStarted == entity.DateStarted)
                              .RowCount();
                return (count == 0);
            }
        }
        
    }

}