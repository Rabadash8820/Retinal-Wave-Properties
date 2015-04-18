using System;
using System.Collections.Generic;

namespace Neuro {

    public class TissueCondition : Entity {
        // VARIABLES
        private ISet<Recording> _recordings;

        // CONSTRUCTORS
        public TissueCondition() {
            this.Construct();
        }
        public TissueCondition(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual TissuePreparation TissuePreparation { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual ISet<Recording> Recordings {
            get { return _recordings; }
        }

        // FUNCTIONS
        private void Construct(){
            _recordings = new HashSet<Recording>();
        }
        public override object Clone() {
            return TissueCondition.Clone(this, new EntityMap());
        }
        internal static TissueCondition Clone(TissueCondition tc, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            TissueCondition clone = null;
            if (map.Contains(tc))
                clone = map.GetEntity<TissueCondition>(tc);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(tc.GetType()) as TissueCondition;
                map.Add(tc, clone);

                foreach (Recording r in tc.Recordings)
                    clone.Recordings.Add(Recording.Clone(r, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.TissuePreparation = map.GetEntity<TissuePreparation>(tc.TissuePreparation);
            clone.Condition = map.GetEntity<Condition>(tc.Condition);
            return clone;
        }
    }

}