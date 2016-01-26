using MeaData;
using System;

namespace MEACruncher.Events {

    public class EntityUpdatedEventArgs : EventArgs {
        public EntityUpdatedEventArgs(Entity entity) { Entity = entity; }
        public Entity Entity { get; protected set; }
    }

}