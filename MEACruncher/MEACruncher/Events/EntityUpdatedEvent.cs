using System;
using MeaData;

namespace MEACruncher.Events {

    public delegate void EntityUpdatedEventHandler<E>(object sender, EntityUpdatedEventArgs<E> e) where E : Entity;

    public class EntityUpdatedEventArgs<E> : EventArgs where E : Entity {
        public EntityUpdatedEventArgs(E entity) { Entity = entity; }
        public E Entity { get; protected set; }
    }

}