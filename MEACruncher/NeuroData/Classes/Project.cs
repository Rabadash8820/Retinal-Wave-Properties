using System;
using System.Collections.Generic;

namespace Neuro {

    public class Project : Entity {
        // VARIABLES
        private ISet<ProjectExperimenter> _projectExperimenters;
        private ISet<ProjectRecording> _projectRecordings;

        // CONSTRUCTORS
        public Project() {
            this.Construct();
        }
        public Project(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Title { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<ProjectExperimenter> ProjectExperimenters {
            get { return _projectExperimenters; }
        }
        public virtual ISet<ProjectRecording> ProjectRecordings {
            get { return _projectRecordings; }
        }

        // FUNCTIONS
        private void Construct() {
            _projectExperimenters = new HashSet<ProjectExperimenter>();
            _projectRecordings = new HashSet<ProjectRecording>();
        }
        public override object Clone() {
            return Project.Clone(this, new EntityMap());
        }
        internal static Project Clone(Project p, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Project clone = null;
            if (map.Contains(p))
                clone = map.GetEntity<Project>(p);
                
            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(p.GetType()) as Project;
                map.Add(p, clone);

                clone.Title = p.Title;
                clone.DateStarted = p.DateStarted;
                clone.Comments = p.Comments;
                foreach (ProjectExperimenter pe in p.ProjectExperimenters)
                    clone.ProjectExperimenters.Add(ProjectExperimenter.Clone(pe, map));
                foreach (ProjectRecording pr in p.ProjectRecordings)
                    clone.ProjectRecordings.Add(ProjectRecording.Clone(pr, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}