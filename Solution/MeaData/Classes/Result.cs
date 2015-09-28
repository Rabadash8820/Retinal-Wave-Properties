using System;
using System.Collections.Generic;

namespace MeaData {

    public class Result : Entity {
        // CONSTRUCTORS
        public Result() {
            this.Construct();
        }
        public Result(Guid g)
            : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Population Population { get; set; }
        public virtual ResultType ResultType { get; set; }
        public virtual double Value { get; set; }

        // FUNCTIONS
        private void Construct(){
        }
        public override object Clone() {
            return Result.Clone(this, new EntityMap());
        }
        internal static Result Clone(Result r, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Result clone = null;
            if (map.Contains(r))
                clone = map.GetEntity<Result>(r);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(r.GetType()) as Result;
                map.Add(r, clone);

            }

            // Clone any remaining object members of the object, and return the clone
            clone.Population = map.GetEntity<Population>(r.Population);
            clone.ResultType = map.GetEntity<ResultType>(r.ResultType);
            return clone;
        }
    }

}