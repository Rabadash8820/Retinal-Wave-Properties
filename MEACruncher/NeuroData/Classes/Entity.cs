using System;
using System.ComponentModel;

namespace Neuro {

    public class Entity {
        // VARIABLES
        private int? _hash;

        // CONSTRUCTORS
        public Entity() { }
        public Entity(Guid g){
            this.Guid = g;
        }

        // PROPERTIES
        public virtual Guid Guid { get; protected set; }
        [Browsable(false)]
        public virtual bool IsTransient{
            get { return this.Guid.Equals(default(Guid)); }
        }

        // FUNCTIONS
        public override bool Equals(object obj) {
            Entity that = obj as Entity;
            if (that == null)
                return false;
            else if (this.GetType() != that.GetUnproxiedType())
                return false;
            else if (this.IsTransient ^ that.IsTransient)
                return false;
            else if (this.IsTransient && that.IsTransient)
                return ReferenceEquals(this, that);
            else
                return this.Guid.Equals(that.Guid);
        }
        public override int GetHashCode() {
            if (!_hash.HasValue)
                _hash = this.IsTransient ? base.GetHashCode() : this.Guid.GetHashCode();
            return _hash.Value;
        }
        protected virtual Type GetUnproxiedType() {
            return this.GetType();
        }
        public virtual object Clone() {
            return null;
        }

#pragma warning disable 0067
        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual event PropertyChangingEventHandler PropertyChanging;
#pragma warning restore 0067

    }

}