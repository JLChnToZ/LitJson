using System;

namespace LitJson {
    public partial class JsonData: IJsonWrapper, IEquatable<JsonData>, IConvertible {
        TypeCode IConvertible.GetTypeCode() {
            switch(type) {
                case JsonType.Boolean: return TypeCode.Boolean;
                case JsonType.Int: return TypeCode.Int32;
                case JsonType.Long: return TypeCode.Int64;
                case JsonType.Double: return TypeCode.Double;
                case JsonType.String: return TypeCode.String;
                case JsonType.Object:
                case JsonType.Array: return TypeCode.Object;
                default: return TypeCode.Empty;
            }
        }

        object GetPrimitive() {
            switch(type) {
                case JsonType.Boolean: return inst_boolean;
                case JsonType.Int: return inst_int;
                case JsonType.Long: return inst_long;
                case JsonType.Double: return inst_double;
                case JsonType.String: return inst_string;
                default: return null;
            }
        }

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            switch(type) {
                case JsonType.Boolean: return inst_boolean;
                case JsonType.Int: return inst_int != 0;
                case JsonType.Long: return inst_long != 0;
                case JsonType.Double: return inst_double != 0;
            }
            return Convert.ToBoolean(GetPrimitive(), provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return (sbyte)inst_int;
                case JsonType.Long: return (sbyte)inst_long;
                case JsonType.Double: return (sbyte)inst_double;
                case JsonType.Boolean: return inst_boolean ? (sbyte)1 : (sbyte)0;
            }
            return Convert.ToSByte(GetPrimitive(), provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return (short)inst_int;
                case JsonType.Long: return (short)inst_long;
                case JsonType.Double: return (short)inst_double;
                case JsonType.Boolean: return inst_boolean ? (short)1 : (short)0;
            }
            return Convert.ToInt16(GetPrimitive(), provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return inst_int;
                case JsonType.Long: return (int)inst_long;
                case JsonType.Double: return (int)inst_double;
                case JsonType.Boolean: return inst_boolean ? 1 : 0;
            }
            return Convert.ToInt32(GetPrimitive(), provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            switch(type) {
                case JsonType.Long: return inst_long;
                case JsonType.Int: return inst_int;
                case JsonType.Double: return (long)inst_double;
                case JsonType.Boolean: return inst_boolean ? 1L : 0L;
            }
            return Convert.ToInt64(GetPrimitive(), provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return (byte)inst_int;
                case JsonType.Long: return (byte)inst_long;
                case JsonType.Double: return (byte)inst_double;
                case JsonType.Boolean: return inst_boolean ? (byte)1 : (byte)0;
            }
            return Convert.ToByte(GetPrimitive(), provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return (ushort)inst_int;
                case JsonType.Long: return (ushort)inst_long;
                case JsonType.Double: return (ushort)inst_double;
                case JsonType.Boolean: return inst_boolean ? (ushort)1 : (ushort)0;
            }
            return Convert.ToUInt16(GetPrimitive(), provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return (uint)inst_int;
                case JsonType.Long: return (uint)inst_long;
                case JsonType.Double: return (uint)inst_double;
                case JsonType.Boolean: return inst_boolean ? 1U : 0U;
            }
            return Convert.ToUInt32(GetPrimitive(), provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            switch(type) {
                case JsonType.Long: return (ulong)inst_long;
                case JsonType.Int: return (ulong)inst_int;
                case JsonType.Double: return (ulong)inst_double;
                case JsonType.Boolean: return inst_boolean ? 1UL : 0UL;
            }
            return Convert.ToUInt64(GetPrimitive(), provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            switch(type) {
                case JsonType.Double: return (float)inst_double;
                case JsonType.Int: return inst_int;
                case JsonType.Long: return inst_long;
                case JsonType.Boolean: return inst_boolean ? 1F : 0F;
            }
            return Convert.ToSingle(GetPrimitive(), provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            switch(type) {
                case JsonType.Double: return inst_double;
                case JsonType.Int: return inst_int;
                case JsonType.Long: return inst_long;
                case JsonType.Boolean: return inst_boolean ? 1D : 0D;
            }
            return Convert.ToDouble(GetPrimitive(), provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider) {
            switch(type) {
                case JsonType.Int: return inst_int;
                case JsonType.Long: return inst_long;
                case JsonType.Double: return (decimal)inst_double;
                case JsonType.Boolean: return inst_boolean ? 1M : 0M;
            }
            return Convert.ToDecimal(GetPrimitive(), provider);
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            return Convert.ToChar(GetPrimitive(), provider);
        }

        string IConvertible.ToString(IFormatProvider provider) {
            if(type == JsonType.String) return inst_string;
            return Convert.ToString(GetPrimitive(), provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime(GetPrimitive(), provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
            if(conversionType == typeof(JsonData))
                return this;
            IConvertible rawValue = GetPrimitive() as IConvertible;
            if(rawValue == this)
                throw new NotSupportedException();
            return rawValue.ToType(conversionType, provider);
        }
    }
}
