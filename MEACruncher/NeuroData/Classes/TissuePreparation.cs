using System;
using System.Collections.Generic;

namespace Neuro {

    public class TissuePreparation : Entity {
        // VARIABLES
        private ISet<TissueCondition> _tissueConditions;

        // CONSTRUCTORS
        public TissuePreparation() {
            this.Construct();
        }
        public TissuePreparation(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Strain Strain { get; set; }
        public virtual NervousSystemRegion NervousSystemRegion { get; set; }
        public virtual DateTime DatePrepared { get; set; }
        public virtual Experimenter Preparer { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissueCondition> TissueConditions {
            get { return _tissueConditions; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissueConditions = new HashSet<TissueCondition>();
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

                clone.DatePrepared = tp.DatePrepared;
                clone.Comments = tp.Comments;
                foreach (TissueCondition tc in tp.TissueConditions)
                    clone.TissueConditions.Add(TissueCondition.Clone(tc, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Strain = map.GetEntity<Strain>(Strain.Clone(tp.Strain, map));
            clone.NervousSystemRegion = map.GetEntity<NervousSystemRegion>(NervousSystemRegion.Clone(tp.NervousSystemRegion, map));
            clone.Preparer = map.GetEntity<Experimenter>(Experimenter.Clone(tp.Preparer, map));
            return clone;
        }
    }

}