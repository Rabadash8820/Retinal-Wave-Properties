using System;
using MeaData;

namespace MEACruncher {

    public delegate void ProjectCreatedEventHandler(object sender, ProjectCreatedEventArgs e);

    public class ProjectCreatedEventArgs : EventArgs {
        public ProjectCreatedEventArgs(Project p) { Project = p; }
        public Project Project { get; protected set; }
    }

}