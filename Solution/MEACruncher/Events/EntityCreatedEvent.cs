using MeaData;
using System;

namespace MEACruncher.Events {

    public class EntityCreatedEventArgs : EventArgs {
        public EntityCreatedEventArgs(Entity entity) { Entity = entity; }
        public Entity Entity { get; protected set; }
    }

}