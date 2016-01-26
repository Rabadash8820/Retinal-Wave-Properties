using MeaData;
using System;

namespace MEACruncher.Events {

    public class EntitySelectedEventArgs : EventArgs {
        public EntitySelectedEventArgs(Entity entity) { Entity = entity; }
        public Entity Entity { get; protected set; }
    }

}