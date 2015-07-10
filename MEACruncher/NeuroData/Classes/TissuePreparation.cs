using System;
using System.Collections.Generic;

namespace MeaData {

    public class TissuePreparation : Entity {
        // VARIABLES
        private ISet<Population> _populations;
        private ISet<Recording> _recordings;

        // CONSTRUCTORS
        public TissuePreparation() {
            this.Construct();
        }
        public TissuePreparation(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Preparer { get; set; }
        public virtual DateTime DatePrepared { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Population> Populations {
            get { return _populations; }
        }
        public virtual ISet<Recording> Recordings {
            get { return _recordings; }
        }

        // FUNCTIONS
        private void Construct() {
            _populations = new HashSet<Population>();
            _recordings = new HashSet<Recording>();
        }
        public override object Clone() {
            return TissuePreparation.Clone(this, new EntityMap());
        }
        internal static TissuePreparation Clone(TissuePreparation tp, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            TissuePreparation clone = null;
            if (map.Contains(tp))
                clone = map.GetEntity<TissuePreparation>(tp);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(tp.GetType()) as TissuePreparation;
                map.Add(tp, clone);

                clone.Preparer = tp.Preparer;
                clone.DatePrepared = tp.DatePrepared;
                clone.Comments = tp.Comments;
                foreach (Recording r in tp.Recordings)
                    clone.Recordings.Add(Recording.Clone(r, map));
                foreach (Population p in tp.Populations)
                    clone.Populations.Add(Population.Clone(p, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}