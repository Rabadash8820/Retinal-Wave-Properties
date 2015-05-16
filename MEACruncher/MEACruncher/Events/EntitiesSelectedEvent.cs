using System;
using System.Collections.Generic;
using MeaData;

namespace MEACruncher.Events {

    public delegate void EntitiesSelectedEventHandler<E>(object sender, EntitiesSelectedEventArgs<E> e) where E : Entity;

    public class EntitiesSelectedEventArgs<E> : EventArgs where E : Entity {
        public EntitiesSelectedEventArgs(IList<E> entities) { Entities = entities; }
        public IList<E> Entities { get; protected set; }
    }

}