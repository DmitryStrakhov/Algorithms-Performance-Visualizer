using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Performance_Visualizer.Data {
    #region HashMapDataKey

    [DebuggerDisplay("HashMapDataKey(ID={ID})")]
    public class HashMapDataKey {
        readonly int id;

        public HashMapDataKey(int id) {
            this.id = id;
        }
        public override bool Equals(object obj) {
            HashMapDataKey other = obj as HashMapDataKey;
            return other != null && ID == other.ID;
        }
        public override int GetHashCode() {
            return ID.GetHashCode();
        }

        public int ID { get { return id; } }
    }

    #endregion

    #region HashMapDataValue

    [DebuggerDisplay("HashMapDataValue(Value={Value})")]
    public class HashMapDataValue {
        readonly string value;

        public HashMapDataValue(string value) {
            this.value = value;
        }
        public override bool Equals(object obj) {
            HashMapDataValue other = obj as HashMapDataValue;
            return other != null && Equals(Value, other.Value);
        }
        public override int GetHashCode() {
            return Value.GetHashCode();
        }
        public string Value { get { return value; } }
    }

    #endregion
}
