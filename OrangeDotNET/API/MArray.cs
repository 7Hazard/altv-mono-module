//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class MArray : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MArray(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MArray obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~MArray() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          OrangeDotNETMonoPINVOKE.delete_MArray(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_std__mapT_int_MValue_p_t ikeys {
    set {
      OrangeDotNETMonoPINVOKE.MArray_ikeys_set(swigCPtr, SWIGTYPE_p_std__mapT_int_MValue_p_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = OrangeDotNETMonoPINVOKE.MArray_ikeys_get(swigCPtr);
      SWIGTYPE_p_std__mapT_int_MValue_p_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__mapT_int_MValue_p_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_std__mapT_std__string_MValue_p_t skeys {
    set {
      OrangeDotNETMonoPINVOKE.MArray_skeys_set(swigCPtr, SWIGTYPE_p_std__mapT_std__string_MValue_p_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = OrangeDotNETMonoPINVOKE.MArray_skeys_get(swigCPtr);
      SWIGTYPE_p_std__mapT_std__string_MValue_p_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__mapT_std__string_MValue_p_t(cPtr, false);
      return ret;
    } 
  }

  public MArray() : this(OrangeDotNETMonoPINVOKE.new_MArray(), true) {
  }

}
