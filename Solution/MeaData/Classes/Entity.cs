using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace MeaData {
    
    [PropertyChanged.ImplementPropertyChanged]
    [PropertyChanging.ImplementPropertyChanging]
    public abstract class Entity : ICloneable {
        // HIDDEN FIELDS
        private int? _hash;

        // PROPERTIES
        [PropertyChanging.DoNotNotify]
        [PropertyChanged.DoNotNotify]
        public Guid Guid { get; protected set; }
        public bool IsTransient{
            get { return this.Guid.Equals(default(Guid)); }
        }

        // INTERFACE FUNCTIONS
        public static bool operator==(Entity e1, Entity e2) {
            // By default, == and Equals compares references.
            // In order to maintain these semantics with Entities, we need to compare by identity value.
            // The Equals(x, y) override is used to guard against null values; it then calls entityEquals().
            return Object.Equals(e1, e2);
        }
        public static bool operator!=(Entity e1, Entity e2) {
            // See comments in operator== method
            return !Object.Equals(e1, e2);
        }
        public E As<E>() where E : Entity {
            return this as E;
        }
        public override bool Equals(object obj) {
            return entityEquals(obj as Entity);
        }
        public override int GetHashCode() {
            // Hash code is cached because it must not change once calculated.
            // For example, if Entity was added to a hashed collection when transient and then saved,
            // we need the same hash code or else it could get lost, because it no longer lives in the same bin.
            if (!_hash.HasValue)
                _hash = this.IsTransient ? base.GetHashCode() : this.Guid.GetHashCode();
            return _hash.Value;
        }
        public object Clone() {
            return cloneEntity(this, new EntityMap());
        }

        // HELPER FUNCTIONS
        private bool entityEquals(Entity that) {
            // If other Entity is null or of incorrect type, return false
            if (that == null || this.GetType() != that.As<Entity>().GetType())
                return false;

            // If one Entity is transient and the other is persistent, return false
            else if (this.IsTransient ^ that.IsTransient)
                return false;
            
            // If both are transient, use reference equals
            else if (this.IsTransient && that.IsTransient)
                return ReferenceEquals(this, that);

            else
                return this.Guid.Equals(that.Guid);
        }
        private static Entity cloneEntity(Entity e, EntityMap map) {
            if (e == null)
                return null;

            // If this object is already a key in the map, then return its associated value
            if (map.ContainsKey(e))
                return map.GetEntity(e);

            // Otherwise, create its clone and add them as a key/value pair
            Entity clone = Activator.CreateInstance(e.As<Entity>().GetType()) as Entity;
            map.Add(e, clone);  // Must add to map before cloning properties!
            cloneProperties(e, clone, map);

            return clone;
        }
        private static void cloneProperties(Entity original, Entity clone, EntityMap map) {
            // Loop through each property of the Entity (excluding ones inherited from Entity)
            PropertyInfo[] properties = original.As<Entity>().GetType()
                                                .GetProperties()
                                                .Where(pi => pi.Name != nameof(Guid) && pi.Name != nameof(IsTransient))
                                                .ToArray();
            foreach (PropertyInfo p in properties) {
                // Clone Entity collection properties
                IEnumerable<Entity> originalEntities = (p.GetValue(original) as IEnumerable<Entity>);
                if (originalEntities != null) {
                    MethodInfo add = p.PropertyType.GetMethod("Add");
                    IEnumerable<Entity> cloneEntities = p.GetValue(clone) as IEnumerable<Entity>;   // some kind of boxed collection
                    foreach (Entity oe in originalEntities)
                        add.Invoke(cloneEntities, new object[] { cloneEntity(oe, map) });
                    continue;
                }

                // Clone Entity properties
                bool isEntity = (p.PropertyType.IsSubclassOf(typeof(Entity)));
                if (isEntity) {
                    Entity originalEntity = p.GetValue(original) as Entity;
                    Entity cloneEntity = map.GetEntity(Entity.cloneEntity(originalEntity, map));
                    p.SetValue(clone, cloneEntity);
                    continue;
                }

                // Clone all other properties
                object originalValue = p.GetValue(original);
                p.SetValue(clone, originalValue);
            }
        }

    }

}