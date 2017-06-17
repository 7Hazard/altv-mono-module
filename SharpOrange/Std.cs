// ----------------------------------------------------------------------------
// <auto-generated>
// This is autogenerated code by CppSharp.
// Do not edit this file or all your changes will be lost after re-generation.
// </auto-generated>
// ----------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Std
{
    public unsafe partial class Lockit
    {
        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int _Locktype;
        }
    }
}

namespace Std
{
    public unsafe partial class ExceptionPtr
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Data1;

            [FieldOffset(8)]
            internal global::System.IntPtr _Data2;
        }
    }
}

public unsafe partial class StdExceptionData
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct __Internal
    {
        [FieldOffset(0)]
        internal global::System.IntPtr _What;

        [FieldOffset(8)]
        internal byte _DoFree;
    }
}

namespace Std
{
    public unsafe partial class CharTraits : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public unsafe partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0?$char_traits@D@std@@QEAA@AEBU01@@Z")]
            internal static extern global::System.IntPtr cctorc__N_std_S_char_traits__C_1(global::System.IntPtr instance, global::System.IntPtr _0);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?compare@?$char_traits@D@std@@SAHPEBD0_K@Z")]
            internal static extern int Comparec__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _First1, [MarshalAs(UnmanagedType.LPStr)] string _First2, ulong _Count);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?length@?$char_traits@D@std@@SA_KPEBD@Z")]
            internal static extern ulong Lengthc__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _First);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?copy@?$char_traits@D@std@@SAPEADPEADPEBD_K@Z")]
            internal static extern sbyte* Copyc__N_std_S_char_traits__C_0(sbyte* _First1, [MarshalAs(UnmanagedType.LPStr)] string _First2, ulong _Count);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?_Copy_s@?$char_traits@D@std@@SAPEADPEAD_KPEBD1@Z")]
            internal static extern sbyte* CopySc__N_std_S_char_traits__C_0(sbyte* _First1, ulong _Size_in_bytes, [MarshalAs(UnmanagedType.LPStr)] string _First2, ulong _Count);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?find@?$char_traits@D@std@@SAPEBDPEBD_KAEBD@Z")]
            internal static extern global::System.IntPtr Findc__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _First, ulong _Count, [MarshalAs(UnmanagedType.LPStr)] string _Ch);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?move@?$char_traits@D@std@@SAPEADPEADPEBD_K@Z")]
            internal static extern sbyte* Movec__N_std_S_char_traits__C_0(sbyte* _First1, [MarshalAs(UnmanagedType.LPStr)] string _First2, ulong _Count);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?assign@?$char_traits@D@std@@SAPEADPEAD_KD@Z")]
            internal static extern sbyte* Assignc__N_std_S_char_traits__C_0(sbyte* _First, ulong _Count, sbyte _Ch);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?assign@?$char_traits@D@std@@SAXAEADAEBD@Z")]
            internal static extern void Assignc__N_std_S_char_traits__C_1(sbyte* _Left, [MarshalAs(UnmanagedType.LPStr)] string _Right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?eq@?$char_traits@D@std@@SA_NAEBD0@Z")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool Eqc__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _Left, [MarshalAs(UnmanagedType.LPStr)] string _Right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?lt@?$char_traits@D@std@@SA_NAEBD0@Z")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool Ltc__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _Left, [MarshalAs(UnmanagedType.LPStr)] string _Right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?to_char_type@?$char_traits@D@std@@SADAEBH@Z")]
            internal static extern sbyte ToCharTypec__N_std_S_char_traits__C_0(int* _Meta);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?to_int_type@?$char_traits@D@std@@SAHAEBD@Z")]
            internal static extern int ToIntTypec__N_std_S_char_traits__C_0([MarshalAs(UnmanagedType.LPStr)] string _Ch);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?eq_int_type@?$char_traits@D@std@@SA_NAEBH0@Z")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool EqIntTypec__N_std_S_char_traits__C_0(int* _Left, int* _Right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?not_eof@?$char_traits@D@std@@SAHAEBH@Z")]
            internal static extern int NotEofc__N_std_S_char_traits__C_0(int* _Meta);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?eof@?$char_traits@D@std@@SAHXZ")]
            internal static extern int Eofc__N_std_S_char_traits__C_0();
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.CharTraits> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.CharTraits>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::Std.CharTraits __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::Std.CharTraits(native.ToPointer(), skipVTables);
        }

        internal static global::Std.CharTraits __CreateInstance(global::Std.CharTraits.__Internal native, bool skipVTables = false)
        {
            return new global::Std.CharTraits(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.CharTraits.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.CharTraits.__Internal));
            *(global::Std.CharTraits.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CharTraits(global::Std.CharTraits.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected CharTraits(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public CharTraits()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::Std.CharTraits.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public CharTraits(global::Std.CharTraits _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::Std.CharTraits.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::Std.CharTraits.__Internal*) __Instance) = *((global::Std.CharTraits.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::Std.CharTraits __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public static int Compare(string _First1, string _First2, ulong _Count)
        {
            var __ret = global::Std.CharTraits.__Internal.Comparec__N_std_S_char_traits__C_0(_First1, _First2, _Count);
            return __ret;
        }

        public static ulong Length(string _First)
        {
            var __ret = global::Std.CharTraits.__Internal.Lengthc__N_std_S_char_traits__C_0(_First);
            return __ret;
        }

        public static sbyte* Copy(sbyte* _First1, string _First2, ulong _Count)
        {
            var __ret = global::Std.CharTraits.__Internal.Copyc__N_std_S_char_traits__C_0(_First1, _First2, _Count);
            return __ret;
        }

        public static sbyte* CopyS(sbyte* _First1, ulong _Size_in_bytes, string _First2, ulong _Count)
        {
            var __ret = global::Std.CharTraits.__Internal.CopySc__N_std_S_char_traits__C_0(_First1, _Size_in_bytes, _First2, _Count);
            return __ret;
        }

        public static string Find(string _First, ulong _Count, string _Ch)
        {
            var __ret = global::Std.CharTraits.__Internal.Findc__N_std_S_char_traits__C_0(_First, _Count, _Ch);
            return Marshal.PtrToStringAnsi(__ret);
        }

        public static sbyte* Move(sbyte* _First1, string _First2, ulong _Count)
        {
            var __ret = global::Std.CharTraits.__Internal.Movec__N_std_S_char_traits__C_0(_First1, _First2, _Count);
            return __ret;
        }

        public static sbyte* Assign(sbyte* _First, ulong _Count, sbyte _Ch)
        {
            var __ret = global::Std.CharTraits.__Internal.Assignc__N_std_S_char_traits__C_0(_First, _Count, _Ch);
            return __ret;
        }

        public static void Assign(sbyte* _Left, string _Right)
        {
            global::Std.CharTraits.__Internal.Assignc__N_std_S_char_traits__C_1(_Left, _Right);
        }

        public static bool Eq(string _Left, string _Right)
        {
            var __ret = global::Std.CharTraits.__Internal.Eqc__N_std_S_char_traits__C_0(_Left, _Right);
            return __ret;
        }

        public static bool Lt(string _Left, string _Right)
        {
            var __ret = global::Std.CharTraits.__Internal.Ltc__N_std_S_char_traits__C_0(_Left, _Right);
            return __ret;
        }

        public static sbyte ToCharType(ref int _Meta)
        {
            fixed (int* __refParamPtr0 = &_Meta)
            {
                var __arg0 = __refParamPtr0;
                var __ret = global::Std.CharTraits.__Internal.ToCharTypec__N_std_S_char_traits__C_0(__arg0);
                return __ret;
            }
        }

        public static int ToIntType(string _Ch)
        {
            var __ret = global::Std.CharTraits.__Internal.ToIntTypec__N_std_S_char_traits__C_0(_Ch);
            return __ret;
        }

        public static bool EqIntType(ref int _Left, ref int _Right)
        {
            fixed (int* __refParamPtr0 = &_Left)
            {
                var __arg0 = __refParamPtr0;
                fixed (int* __refParamPtr1 = &_Right)
                {
                    var __arg1 = __refParamPtr1;
                    var __ret = global::Std.CharTraits.__Internal.EqIntTypec__N_std_S_char_traits__C_0(__arg0, __arg1);
                    return __ret;
                }
            }
        }

        public static int NotEof(ref int _Meta)
        {
            fixed (int* __refParamPtr0 = &_Meta)
            {
                var __arg0 = __refParamPtr0;
                var __ret = global::Std.CharTraits.__Internal.NotEofc__N_std_S_char_traits__C_0(__arg0);
                return __ret;
            }
        }

        public static int Eof()
        {
            var __ret = global::Std.CharTraits.__Internal.Eofc__N_std_S_char_traits__C_0();
            return __ret;
        }
    }
}

namespace Std
{
    namespace Pair
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S_pair__1I____S_MValue
        {
            [FieldOffset(0)]
            internal int first;

            [FieldOffset(8)]
            internal global::System.IntPtr second;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S_pair____N_std_S__Tree_iterator____N_std_S__Tree_val____N_std_S__Tree_simple_types____N_std_S_pair__1I____S_MValue_b
        {
            [FieldOffset(0)]
            internal global::Std.TreeIterator.__Internal first;

            [FieldOffset(8)]
            internal byte second;
        }

        [StructLayout(LayoutKind.Explicit, Size = 40)]
        public unsafe partial struct __Internalc__N_std_S_pair__1__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C____S_MValue
        {
            [FieldOffset(0)]
            internal global::Std.BasicString.__Internal first;

            [FieldOffset(32)]
            internal global::System.IntPtr second;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S_pair____N_std_S__Tree_iterator____N_std_S__Tree_val____N_std_S__Tree_simple_types____N_std_S_pair__1__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C____S_MValue_b
        {
            [FieldOffset(0)]
            internal global::Std.TreeIterator.__Internal first;

            [FieldOffset(8)]
            internal byte second;
        }
    }
}

namespace Std
{
    namespace Yarn
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Yarn__C
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Myptr;

            [FieldOffset(8)]
            internal sbyte _Nul;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Yarn__W
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Myptr;

            [FieldOffset(8)]
            internal char _Nul;
        }
    }

    namespace CompressedPair
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator__C___N_std_S__String_val____N_std_S__Simple_types__C_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.StringVal.__Internal _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator__W___N_std_S__String_val____N_std_S__Simple_types__W_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.StringVal.__Internal _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator__q___N_std_S__String_val____N_std_S__Simple_types__q_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.StringVal.__Internal _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator__w___N_std_S__String_val____N_std_S__Simple_types__w_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.StringVal.__Internal _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S_less__I___N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1I____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S5__Vb1_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.CompressedPair.__Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1I____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S3__Vb1 _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1I____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S3__Vb1
        {
            [FieldOffset(0)]
            internal global::Std.TreeVal.__Internal _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S_less____N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C___N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1S1_____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S8__Vb1_Vb1
        {
            [FieldOffset(0)]
            internal global::Std.CompressedPair.__Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S3__Vb1 _Myval2;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S3__Vb1
        {
            [FieldOffset(0)]
            internal global::Std.TreeVal.__Internal _Myval2;
        }
    }
}

namespace Std
{
    public unsafe partial class Allocator : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public unsafe partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0?$allocator@D@std@@QEAA@XZ")]
            internal static extern global::System.IntPtr ctorc__N_std_S_allocator__C_0(global::System.IntPtr instance);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.Allocator> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.Allocator>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::Std.Allocator __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::Std.Allocator(native.ToPointer(), skipVTables);
        }

        internal static global::Std.Allocator __CreateInstance(global::Std.Allocator.__Internal native, bool skipVTables = false)
        {
            return new global::Std.Allocator(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.Allocator.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.Allocator.__Internal));
            *(global::Std.Allocator.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Allocator(global::Std.Allocator.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Allocator(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public Allocator()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::Std.Allocator.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            global::Std.Allocator.__Internal.ctorc__N_std_S_allocator__C_0((__Instance + __PointerAdjustment));
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::Std.Allocator __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }
    }


    public unsafe partial class Rebind
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }
    }
}

public unsafe partial class SETJMP_FLOAT128
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct __Internal
    {
        [FieldOffset(0)]
        internal fixed ulong Part[2];
    }
}

namespace Std
{
    public unsafe partial class BasicString : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::Std.CompressedPair.__Internalc__N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator__C___N_std_S__String_val____N_std_S__Simple_types__C_Vb1 _Mypair;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@QEAA@PEBDAEBV?$allocator@D@1@@Z")]
            internal static extern global::System.IntPtr ctorc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_9(global::System.IntPtr instance, [MarshalAs(UnmanagedType.LPStr)] string _Ptr, global::System.IntPtr _Al);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??1?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@QEAA@XZ")]
            internal static extern void dtorc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_0(global::System.IntPtr instance, int delete);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("Std-symbols", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="?c_str@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@QEBAPEBDXZ")]
            internal static extern global::System.IntPtr CStrc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_0(global::System.IntPtr instance);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.BasicString> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.BasicString>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::Std.BasicString __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::Std.BasicString(native.ToPointer(), skipVTables);
        }

        internal static global::Std.BasicString __CreateInstance(global::Std.BasicString.__Internal native, bool skipVTables = false)
        {
            return new global::Std.BasicString(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.BasicString.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.BasicString.__Internal));
            *(global::Std.BasicString.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private BasicString(global::Std.BasicString.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected BasicString(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public BasicString(string _Ptr, global::Std.Allocator _Al)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::Std.BasicString.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            if (ReferenceEquals(_Al, null))
                throw new global::System.ArgumentNullException("_Al", "Cannot be null because it is a C++ reference (&).");
            var __arg1 = ((global::Std.Allocator) (object) _Al).__Instance;
            global::Std.BasicString.__Internal.ctorc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_9((__Instance + __PointerAdjustment), _Ptr, __arg1);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::Std.BasicString __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (disposing)
                global::Std.BasicString.__Internal.dtorc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_0((__Instance + __PointerAdjustment), 0);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public string CStr()
        {
            var __ret = global::Std.BasicString.__Internal.CStrc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C_0((__Instance + __PointerAdjustment));
            return Marshal.PtrToStringAnsi(__ret);
        }
    }

    namespace StringVal
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::Std.StringVal.Bxty.__Internal _Bx;

            [FieldOffset(16)]
            internal ulong _Mysize;

            [FieldOffset(24)]
            internal ulong _Myres;
        }


        public unsafe partial struct Bxty
        {
            [StructLayout(LayoutKind.Explicit, Size = 0)]
            public partial struct __Internal
            {
            }
        }
    }
}

public unsafe partial class StdTypeInfoData
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct __Internal
    {
        [FieldOffset(0)]
        internal global::System.IntPtr _UndecoratedName;

        [FieldOffset(8)]
        internal fixed sbyte _DecoratedName[1];
    }
}

public unsafe partial class Ctypevec
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public partial struct __Internal
    {
        [FieldOffset(0)]
        internal uint _Page;

        [FieldOffset(8)]
        internal global::System.IntPtr _Table;

        [FieldOffset(16)]
        internal int _Delfl;

        [FieldOffset(24)]
        internal global::System.IntPtr _LocaleName;
    }
}

public unsafe partial class Cvtvec
{
    [StructLayout(LayoutKind.Explicit, Size = 44)]
    public partial struct __Internal
    {
        [FieldOffset(0)]
        internal uint _Page;

        [FieldOffset(4)]
        internal uint _Mbcurmax;

        [FieldOffset(8)]
        internal int _Isclocale;

        [FieldOffset(12)]
        internal fixed byte _Isleadbyte[32];
    }
}

namespace Std
{
    [Flags]
    public enum CodecvtMode
    {
        ConsumeHeader = 4,
        GenerateHeader = 2
    }
}

namespace Std
{
    public unsafe partial class ErrorCode
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int _Myval;

            [FieldOffset(8)]
            internal global::System.IntPtr _Mycat;
        }
    }
}

namespace Std
{
    namespace Literals
    {
    }
}

namespace Std
{
}

namespace Std
{
}

namespace Std
{
}

namespace Std
{
}

namespace Std
{
    namespace TreeIterator
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public unsafe partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Ptr;
        }
    }

    namespace TreeVal
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Myhead;

            [FieldOffset(8)]
            internal ulong _Mysize;
        }
    }
}

namespace Std
{
    namespace Map
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public unsafe partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::Std.CompressedPair.__Internalc__N_std_S__Compressed_pair____N_std_S_less__I___N_std_S__Compressed_pair____N_std_S__Wrap_alloc____N_std_S_allocator____N_std_S__Tree_node____N_std_S_pair__1I____S_MValue__v___N_std_S__Tree_val____N_std_S__Tree_simple_types__S5__Vb1_Vb1 _Mypair;
        }
    }
}
