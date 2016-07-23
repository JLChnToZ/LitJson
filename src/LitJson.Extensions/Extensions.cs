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
                case JsonType.Array:
                case JsonType.Object: return source.Count > 0;
                default: return defaultValue;
            }
        }

        public static sbyte AsInt8(this IJsonWrapper source, sbyte defaultValue = 0) {
            return (sbyte)AsInt32(source, defaultValue);
        }

        public static short AsInt16(this IJsonWrapper source, short defaultValue = 0) {
            return (short)AsInt32(source, defaultValue);
        }

        public static int AsInt32(this IJsonWrapper source, int defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return (int)source.GetLong();
                case JsonType.Double: return (int)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1 : 0;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
                default: return defaultValue;
            }
        }

        public static long AsInt64(this IJsonWrapper source, long defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return source.GetLong();
                case JsonType.Double: return (long)source.GetDouble();
                case JsonType.Boolean: return source.GetBoolean() ? 1 : 0;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
                default: return defaultValue;
            }
        }

        public static byte AsUInt8(this IJsonWrapper source, byte defaultValue = 0) {
            return (byte)AsInt32(source, defaultValue);
        }

        public static ushort AsUInt16(this IJsonWrapper source, ushort defaultValue = 0) {
            return (ushort)AsInt32(source, defaultValue);
        }

        public static uint AsUInt32(this IJsonWrapper source, uint defaultValue = 0) {
            return (uint)AsInt64(source, defaultValue);
        }

        public static ulong AsUInt64(this IJsonWrapper source, ulong defaultValue = 0) {
            return (ulong)AsInt64(source, (long)defaultValue);
        }

        public static float AsSingle(this IJsonWrapper source, float defaultValue = 0) {
            return (float)AsDouble(source, defaultValue);
        }

        public static double AsDouble(this IJsonWrapper source, double defaultValue = 0) {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Double: return source.GetDouble();
                case JsonType.Int: return source.GetInt();
                case JsonType.Long: return source.GetLong();
                case JsonType.Boolean: return source.GetBoolean() ? 1 : 0;
                case JsonType.Array:
                case JsonType.Object: return source.Count;
                default: return defaultValue;
            }
        }

        public static string AsString(this IJsonWrapper source, string defaultValue = "") {
            if(source == null) return defaultValue;
            switch(source.GetJsonType()) {
                case JsonType.Array:
                case JsonType.Object: return source.Count.ToString();
                case JsonType.None: return defaultValue;
                default: return source.ToString();
            }
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

    }
}
