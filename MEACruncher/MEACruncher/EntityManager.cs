using System;
using System.Reflection;
using System.Collections.Generic;

using NHibernate;

using MeaData;
using MEACruncher.Resources;
using MEACruncher.Forms.NewForms;
using MEACruncher.Forms.EditForms;

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
        private static Dictionary<Type, Func<NewEntityForm>> _newForm;
        private static Dictionary<Type, Func<EditEntityForm>> _editForm;

        // STATIC CONSTRUCTOR
        static EntityManager() {
            _stack = new Stack<Entity>();

            initDuplications();
            initDeletions();
            initUniqueness();
            initNewForms();
            initEditForms();
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
        public static NewEntityForm ShowNewForm(Entity entity) {
            return ShowNewForm(entity.GetType());
        }
        public static NewEntityForm ShowNewForm(Type entityType) {
            return _newForm[entityType]();
        }
        public static EditEntityForm ShowEditForm(Entity entity) {
            return ShowEditForm(entity.GetType());
        }
        public static EditEntityForm ShowEditForm(Type entityType) {
            return _editForm[entityType]();
        }

        // HELPER FUNCTIONS
        private static void initDuplications() {
            // For each Entity type, associate an error message for when a duplicate record would be created in the database
            _duplicateError = new Dictionary<Type, Func<Entity, string>>(){
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
        private static void initDeletions() {
            _deleteMsg = new Dictionary<Type, Func<Entity, string>>() {
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    return String.Format(DeleteRes.ProjectWarning, e1.Title); }
                },
                { typeof(Experimenter), e => {
                    Experimenter e1 = e as Experimenter;
                    return String.Format(DeleteRes.ExperimenterWarning, e1.FullName); }
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
        private static void initNewForms() {
            // For each Entity type, show a NewEntityForm and return it
            _newForm = new Dictionary<Type, Func<NewEntityForm>>() {
                { typeof(Project), () => {
                    NewProjectForm form = new NewProjectForm();
                    form.ShowDialog();
                    return form; }
                },
                { typeof(Experimenter), () => {
                    NewExperimenterForm form = new NewExperimenterForm();
                    form.ShowDialog();
                    return form; }
                },
            };
        }
        private static void initEditForms() {
            // For each Entity type, show an EditEntityForm and return it
            _editForm = new Dictionary<Type, Func<EditEntityForm>>() {
                { typeof(Project), () => {
                    EditProjectForm form = new EditProjectForm();
                    form.ShowDialog();
                    return form; }
                },
            };
        }
        
    }

}