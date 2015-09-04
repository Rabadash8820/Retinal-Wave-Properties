using System;
using System.Collections.Generic;

namespace MeaData {

    public class ResultType : Entity {
        // VARIABLES
        private ISet<Result> _results;

        // CONSTRUCTORS
        public ResultType() {
            this.Construct();
        }
        public ResultType(Guid g)
            : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Result> Results {
            get { return _results; }
    }

        // FUNCTIONS
        private void Construct() {
            _results = new HashSet<Result>();
        }
        public override object Clone() {
            return ResultType.Clone(this, new EntityMap());
        }
        internal static ResultType Clone(ResultType rt, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            ResultType clone = null;
            if (map.Contains(rt))
                clone = map.GetEntity<ResultType>(rt);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(rt.GetType()) as ResultType;
                map.Add(rt, clone);

                clone.Description = rt.Description;
                clone.Comments = rt.Comments;
                foreach (Result r in rt.Results)
                    clone.Results.Add(Result.Clone(r, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}