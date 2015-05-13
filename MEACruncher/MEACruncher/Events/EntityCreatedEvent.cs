using System;
using MeaData;

namespace MEACruncher.Events {

    public delegate void EntityCreatedEventHandler<E>(object sender, EntityCreatedEventArgs<E> e) where E : Entity;

    public class EntityCreatedEventArgs<E> : EventArgs where E : Entity{
        public EntityCreatedEventArgs(E entity) { Entity = entity; }
        public E Entity { get; protected set; }
    }

}