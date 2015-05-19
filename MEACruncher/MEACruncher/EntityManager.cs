using System;
using MeaData;
using NHibernate;
using MEACruncher.Resources;
using System.Collections.Generic;

namespace MEACruncher {

    internal static class EntityManager {
        // DELEGATES
        private delegate string duplication(Entity entity);
        private delegate bool uniqueness(Entity entity);

        // VARIABLES
        private static ISession _db;
        private static Dictionary<Type, duplication> _duplicateError;
        private static Dictionary<Type, uniqueness> _uniqueness;
        private static Stack<object> _stack;

        // STATIC CONSTRUCTOR
        static EntityManager() {
            initDuplications();
            initUniqueness();
            _stack = new Stack<object>();
        }

        // INTERFACE FUNCTIONS
        public static string DuplicateError(Entity entity){
            _db = Program.MeaDataDb.Session;
            string entityError = _duplicateError[entity.GetType()](entity);
            return entityError + "\n\n" + DuplicateRes.Message;
        }
        public static bool IsUnique(Entity entity) {
            _db = Program.MeaDataDb.Session;
            return _uniqueness[entity.GetType()](entity);
        }
        public static void Remember(object obj) {
            if (obj == null) return;
            _stack.Push(obj);
        }
        public static object Recall() {
            if (_stack.Count == 0) return null;
            return _stack.Pop();
        }

        // HELPER FUNCTIONS
        private static void initDuplications() {
            // For each Entity type, associate an error message for when a duplicate record would be created in the database
            _duplicateError = new Dictionary<Type, duplication>(){
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    return String.Format(
                        DuplicateRes.ProjectError,
                        e1.Title,
                        e1.DateStarted.ToShortDateString()); }
                },
                { typeof(Experimenter), e => {
                    Experimenter e1 = e as Experimenter;
                    return String.Format(
                        DuplicateRes.ExperimenterError,
                        e1.FullName); }
                },
            };
        }
        private static void initUniqueness() {
            // For each Entity type, associate a method to determine if it is duplicating an Entity already in the database
            _uniqueness = new Dictionary<Type, uniqueness>() {
                // Projects
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    int count = _db.QueryOver<Project>()
                                   .Where(e2 =>
                                       e2.Guid != e1.Guid &&
                                       e2.Title == e1.Title &&
                                       e2.DateStarted == e1.DateStarted)
                                   .RowCount();
                    return (count == 0); }
                },

                // Experimenters
                { typeof(Experimenter), e => {
                    Experimenter e1 = e as Experimenter;
                    int count = _db.QueryOver<Experimenter>()
                                   .Where(e2 =>
                                       e2.Guid != e1.Guid &&
                                       e2.FullName == e1.FullName &&
                                       e2.WorkEmail == e1.WorkEmail &&
                                       e2.WorkPhone == e1.WorkPhone)
                                   .RowCount();
                    return (count == 0); }
                },
            };
        }


    }

}