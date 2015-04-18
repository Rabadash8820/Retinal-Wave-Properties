using System;
using System.Collections.Generic;

namespace Neuro {

    public class EntityMap {
        // VARIABLES
        private Dictionary<Entity, Entity> _map;

        // CONSTRUCTORS
        public EntityMap() {
            _map = new Dictionary<Entity, Entity>();
        }

        // FUNCTIONS
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
        public bool Contains(Entity entity) {
            if (entity == null)
                return false;
            return _map.ContainsKey(entity);
        }
    }

}