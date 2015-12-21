using MeaData;
using System;
using System.Collections.Generic;

namespace MEACruncher.Events {

    public class EntitiesSelectedEventArgs : EventArgs {
        public EntitiesSelectedEventArgs(IList<Entity> entities) { Entities = entities; }
        public IList<Entity> Entities { get; protected set; }
    }

}