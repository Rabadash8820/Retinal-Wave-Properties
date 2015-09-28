using System;
using System.Collections.Generic;

namespace MeaData {

    public class Tissue : Entity {
        // VARIABLES
        private ISet<Population> _populations;
        private ISet<Recording> _recordings;

        // CONSTRUCTORS
        public Tissue() {
            this.Construct();
        }
        public Tissue(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Strain Strain { get; set; }
        public virtual TissueType TissueType { get; set; }
        public virtual double Age { get; set; }
        public virtual AgeUnit AgeUnit { get; set; }
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
            return Tissue.Clone(this, new EntityMap());
        }
        internal static Tissue Clone(Tissue t, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Tissue clone = null;
            if (map.Contains(t))
                clone = map.GetEntity<Tissue>(t);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(t.GetType()) as Tissue;
                map.Add(t, clone);

                clone.Age = t.Age;
                clone.Preparer = t.Preparer;
                clone.DatePrepared = t.DatePrepared;
                clone.Comments = t.Comments;
                foreach (Recording r in t.Recordings)
                    clone.Recordings.Add(Recording.Clone(r, map));
                foreach (Population p in t.Populations)
                    clone.Populations.Add(Population.Clone(p, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Strain = map.GetEntity<Strain>(Strain.Clone(t.Strain, map));
            clone.TissueType = map.GetEntity<TissueType>(TissueType.Clone(t.TissueType, map));
            clone.AgeUnit = map.GetEntity<AgeUnit>(AgeUnit.Clone(t.AgeUnit, map));
            return clone;
        }
    }

}