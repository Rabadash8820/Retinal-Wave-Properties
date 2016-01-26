using System;
using System.Collections.Generic;

namespace MeaData {

    [DoNotVirtualize]
    public class EntityMap {
        // VARIABLES
        private Dictionary<Entity, Entity> _map = new Dictionary<Entity, Entity>();

        // INTERFACE FUNCTIONS
        public T GetEntity<T>(T inEntity) where T : Entity {
            if (inEntity != null) {
                Entity outEntity = null;
                if (_map.TryGetValue(inEntity, out outEntity))
                    return outEntity as T;
            }

            return inEntity;
        }
        public void Add(Entity oldEntity, Entity newEntity) {
            if (oldEntity != null && newEntity != null)
                _map.Add(oldEntity, newEntity);
        }
        public bool ContainsKey(Entity entity) {
            if (entity == null)
                return false;
            return _map.ContainsKey(entity);
        }
    }

}