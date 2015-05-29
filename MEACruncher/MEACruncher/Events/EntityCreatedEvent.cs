using MeaData;
using System;

namespace MEACruncher.Events {

    public delegate void EntityCreatedEventHandler(object sender, EntityCreatedEventArgs e);

    public class EntityCreatedEventArgs : EventArgs {
        public EntityCreatedEventArgs(Entity entity) { Entity = entity; }
        public Entity Entity { get; protected set; }
    }

}