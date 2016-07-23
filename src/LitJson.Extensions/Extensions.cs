using System;
using System.Collections;
using System.Collections.Generic;

namespace LitJson {
    public static class Extensions {
        public static bool AsBoolean(this IJsonWrapper source, bool defaultValue = false) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Boolean: return source.GetBoolean();
                case JsonType.Int: return source.GetInt() != 0;
                case JsonType.Long: return source.GetLong() != 0;
                case JsonType.Double: return source.GetDouble() != 0;
                case JsonType.String:
                    bool value;
                    if(bool.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return source.Count > 0;
            }
            return defaultValue;
        }

        public static sbyte AsInt8(this IJsonWrapper source, sbyte defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (sbyte)source.GetInt();
                case JsonType.Long: return (sbyte)source.GetLong();
                case JsonType.Double: return (sbyte)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? (sbyte)1 : (sbyte)0;
                case JsonType.String:
                    sbyte value;
                    if(sbyte.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (sbyte)source.Count;
            }
            return defaultValue;
        }

        public static short AsInt16(this IJsonWrapper source, short defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (short)source.GetInt();
                case JsonType.Long: return (short)source.GetLong();
                case JsonType.Double: return (short)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? (short)1 : (short)0;
                case JsonType.String:
                    short value;
                    if(short.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (short)source.Count;
            }
            return defaultValue;
        }

        public static int AsInt32(this IJsonWrapper source, int defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return (int)source.GetLong();
                case JsonType.Double: return (int)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1 : 0;
                case JsonType.String:
                    int value;
                    if(int.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
            }
            return defaultValue;
        }

        public static long AsInt64(this IJsonWrapper source, long defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return source.GetLong();
                case JsonType.Double: return (long)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1L : 0L;
                case JsonType.String:
                    long value;
                    if(long.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
            }
            return defaultValue;
        }

        public static byte AsUInt8(this IJsonWrapper source, byte defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (byte)source.GetInt();
                case JsonType.Long: return (byte)source.GetLong();
                case JsonType.Double: return (byte)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? (byte)1 : (byte)0;
                case JsonType.String:
                    byte value;
                    if(byte.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (byte)source.Count;
            }
            return defaultValue;
        }

        public static ushort AsUInt16(this IJsonWrapper source, ushort defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (ushort)source.GetInt();
                case JsonType.Long: return (ushort)source.GetLong();
                case JsonType.Double: return (ushort)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? (ushort)1 : (ushort)0;
                case JsonType.String:
                    ushort value;
                    if(ushort.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (ushort)source.Count;
            }
            return defaultValue;
        }

        public static uint AsUInt32(this IJsonWrapper source, uint defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (uint)source.GetInt();
                case JsonType.Long: return (uint)source.GetLong();
                case JsonType.Double: return (uint)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1U : 0U;
                case JsonType.String:
                    uint value;
                    if(uint.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (uint)source.Count;
            }
            return defaultValue;
        }

        public static ulong AsUInt64(this IJsonWrapper source, ulong defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return (ulong)source.GetInt();
                case JsonType.Long: return (ulong)source.GetLong();
                case JsonType.Double: return (ulong)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1UL : 0UL;
                case JsonType.String:
                    ulong value;
                    if(ulong.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return (ulong)source.Count;
            }
            return defaultValue;
        }

        public static float AsSingle(this IJsonWrapper source, float defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Double: return (float)source.GetDouble();
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return source.GetLong();
                case JsonType.Boolean: return source.GetBoolean() ? 1F : 0F;
                case JsonType.String:
                    float value;
                    if(float.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
            }
            return defaultValue;
        }

        public static double AsDouble(this IJsonWrapper source, double defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Double: return source.GetDouble();
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return source.GetLong();
                case JsonType.Boolean: return source.GetBoolean() ? 1D : 0D;
                case JsonType.String:
                    double value;
                    if(double.TryParse(source.GetString(), out value))
                        return value;
                    break;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
            }
            return defaultValue;
        }

        public static string AsString(this IJsonWrapper source, string defaultValue = "") {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.String: return source.GetString();
                case JsonType.Double: return source.GetDouble().ToString();
                case JsonType.Int: return source.GetInt().ToString();
                case JsonType.Long: return source.GetLong().ToString();
                case JsonType.Boolean: return source.GetBoolean().ToString();
                case JsonType.Array:
                case JsonType.Object: return source.Count.ToString();
            }
            return defaultValue;
        }

        public static bool TryGetChild(this IJsonWrapper source, string key, out IJsonWrapper child) {
            if(source != null && !string.IsNullOrEmpty(key)) {
                if(source.IsObject && (source as IDictionary).Contains(key)) {
                    child = source[key as object] as IJsonWrapper;
                    return true;
                }
                if(source.IsArray) {
                    int index;
                    if(int.TryParse(key, out index) && index > 0 && index < source.Count) {
                        child = (source as IList)[index] as IJsonWrapper;
                        return true;
                    }
                }
            }
            child = null;
            return false;
        }

        public static bool TryGetChild(this IJsonWrapper source, int index, out IJsonWrapper child) {
            if(source != null) {
                if(source.IsArray && index > 0 && index < source.Count) {
                    child = (source as IList)[index] as IJsonWrapper;
                    return true;
                }
                if(source.IsObject) {
                    string key = index.ToString();
                    if((source as IDictionary).Contains(key)) {
                        child = source[key as object] as IJsonWrapper;
                        return true;
                    }
                }
            }
            child = null;
            return false;
        }

        public static bool TryGetChild(this IJsonWrapper source, out IJsonWrapper child, params object[] path) {
            child = source;
            if(path != null)
                foreach(var entry in path) {
                    if(entry == null)
                        child = null;
                    else if(entry is int)
                        TryGetChild(child, (int)entry, out child);
                    else
                        TryGetChild(child, entry.ToString(), out child);
                    if(child == null) break;
                }
            return child != null;
        }

        public static IJsonWrapper GetChild(this IJsonWrapper source, string key) {
            IJsonWrapper child;
            TryGetChild(source, key, out child);
            return child;
        }

        public static IJsonWrapper GetChild(this IJsonWrapper source, int index) {
            IJsonWrapper child;
            TryGetChild(source, index, out child);
            return child;
        }

        public static IJsonWrapper GetChild(this IJsonWrapper source, params object[] path) {
            IJsonWrapper child;
            TryGetChild(source, out child, path);
            return child;
        }

        private class PlaceHolder {
            private ArrayList arrayList;
            private Hashtable hashtable;
            private int index;
            private object key;

            public PlaceHolder(ArrayList arrayList, int index) {
                this.arrayList = arrayList;
                this.index = index;
            }

            public PlaceHolder(Hashtable hashtable, object key) {
                this.hashtable = hashtable;
                this.key = key;
            }

            public void Assign(object value) {
                if(arrayList != null)
                    arrayList[index] = value;
                else if(hashtable != null)
                    hashtable[key] = value;
            }
        }
    
        public static object Box(this IJsonWrapper source) {
            if(source == null) return null;
            var checkList = new Dictionary<IJsonWrapper, PlaceHolder>();
            KeyValuePair<IJsonWrapper, PlaceHolder>[] buffer = null;
            object result, rootResult = null;
            IJsonWrapper parent, child;
            PlaceHolder placeHolder;
            int bufferCount, bufferIndex, i;
            checkList.Add(source, null);
            while((bufferCount = checkList.Count) > 0) {
                if(buffer == null)
                    buffer = new KeyValuePair<IJsonWrapper, PlaceHolder>[bufferCount];
                else if(buffer.Length < bufferCount)
                    Array.Resize(ref buffer, bufferCount);
                (checkList as ICollection<KeyValuePair<IJsonWrapper, PlaceHolder>>).CopyTo(buffer, 0);
                checkList.Clear();
                bufferIndex = 0;
                foreach(var kv in buffer) {
                    if(++bufferIndex > bufferCount) break;
                    parent = kv.Key;
                    placeHolder = kv.Value;
                    result = null;
                    switch(parent.GetJsonType()) {
                        case JsonType.Boolean: result = parent.GetBoolean(); break;
                        case JsonType.Int: result = parent.GetInt(); break;
                        case JsonType.Long: result = parent.GetLong(); break;
                        case JsonType.Double: result = parent.GetDouble(); break;
                        case JsonType.String: result = parent.GetString(); break;
                        case JsonType.Array: {
                                int count = parent.Count;
                                ArrayList resultList = ArrayList.Repeat(null, count);
                                IList jsonArray = parent as IList;
                                for(i = 0; i < count; i++) {
                                    child = jsonArray[i] as IJsonWrapper;
                                    if(child != null && child.GetJsonType() != JsonType.None)
                                        checkList[child] = new PlaceHolder(resultList, i);
                                }
                                result = resultList;
                            }
                            break;
                        case JsonType.Object: {
                                Hashtable resultTable = new Hashtable();
                                foreach(DictionaryEntry entry in parent as IDictionary) {
                                    child = entry.Value as IJsonWrapper;
                                    if(child != null && child.GetJsonType() != JsonType.None)
                                        checkList[child] = new PlaceHolder(resultTable, entry.Key);
                                }
                                result = resultTable;
                            }
                            break;
                    }
                    if(placeHolder != null)
                        placeHolder.Assign(result);
                    else if(parent == source)
                        rootResult = result;
                }
            }
            return rootResult;
        }
    }
}
