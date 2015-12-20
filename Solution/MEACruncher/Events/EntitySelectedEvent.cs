using MeaData;
using System;

namespace MEACruncher.Events {

    public delegate void EntitySelectedEventHandler(object sender, EntitySelectedEventArgs e);

    public class EntitySelectedEventArgs : EventArgs {
        public EntitySelectedEventArgs(Entity entity) { Entity = entity; }
        public Entity Entity { get; protected set; }
    }

}