using System;
using System.Reflection;
using System.Collections.Generic;

using NHibernate;

using MeaData;
using MEACruncher.Resources;

namespace MEACruncher {
    internal static class EntityManager {
        // DELEGATES
        private delegate string duplication(Entity entity);
        private delegate bool uniqueness(Entity entity);

        // VARIABLES
        private static ISession _db;
        private static Stack<Entity> _stack;
        private static Dictionary<Type, Func<Entity, string>> _duplicateError;
        private static Dictionary<Type, Func<Entity, string>> _deleteMsg;
        private static Dictionary<Type, Func<Entity, bool>> _uniqueness;

        // STATIC CONSTRUCTOR
        static EntityManager() {
            _stack = new Stack<Entity>();

            initDuplications();
            initDeletions();
            initUniqueness();
        }

        // INTERFACE FUNCTIONS
        public static void Remember(Entity entity) {
            if (entity == null) return;
            _stack.Push(entity);
        }
        public static Entity Recall() {
            if (_stack.Count == 0) return null;
            return _stack.Pop();
        }

        public static string DuplicateError(Entity entity){
            _db = Program.MeaDataDb.Session;
            string entityError = _duplicateError[entity.GetType()](entity);
            return entityError + "\n\n" + DuplicateRes.Message;
        }
        public static string DeleteMessage(Entity entity) {
            return _deleteMsg[entity.GetType()](entity);
        }
        public static bool IsUnique(Entity entity) {
            _db = Program.MeaDataDb.Session;
            return _uniqueness[entity.GetType()](entity);
        }

        // HELPER FUNCTIONS
        private static void initDuplications() {
            // For each Entity type, associate an error message for when a duplicate record would be created in the database
            _duplicateError = new Dictionary<Type, Func<Entity, string>>(){
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    return String.Format(
                        DuplicateRes.ProjectError,
                        e1.Name,
                        e1.DateStarted.ToShortDateString()); }
                },
            };
        }
        private static void initDeletions() {
            _deleteMsg = new Dictionary<Type, Func<Entity, string>>() {
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    return String.Format(DeleteRes.ProjectWarning, e1.Name); }
                },
            };
        }
        private static void initUniqueness() {
            // For each Entity type, associate a method to determine if it is duplicating an Entity already in the database
            _uniqueness = new Dictionary<Type, Func<Entity, bool>>() {
                // Projects
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    int count = _db.QueryOver<Project>()
                                   .Where(e2 =>
                                       e2.Guid != e1.Guid &&
                                       e2.Name == e1.Name &&
                                       e2.DateStarted == e1.DateStarted)
                                   .RowCount();
                    return (count == 0); }
                },
            };
        }
        
    }

}