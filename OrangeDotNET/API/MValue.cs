//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class MValue : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MValue(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MValue obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~MValue() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          OrangeDotNETModulePINVOKE.delete_MValue(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static MValue CreateMArray() {
    MValue ret = new MValue(OrangeDotNETModulePINVOKE.MValue_CreateMArray(), true);
    return ret;
  }

  public MValue() : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_0(), true) {
  }

  public MValue(MValue val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_1(MValue.getCPtr(val)), true) {
    if (OrangeDotNETModulePINVOKE.SWIGPendingException.Pending) throw OrangeDotNETModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public MValue(string val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_2(val), true) {
  }

  public MValue(int val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_3(val), true) {
  }

  public MValue(bool val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_4(val), true) {
  }

  public MValue(double val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_5(val), true) {
  }

  public MValue(uint val) : this(OrangeDotNETModulePINVOKE.new_MValue__SWIG_6(val), true) {
  }

  public string getString() {
    string ret = OrangeDotNETModulePINVOKE.MValue_getString(swigCPtr);
    return ret;
  }

  public int getInt() {
    int ret = OrangeDotNETModulePINVOKE.MValue_getInt(swigCPtr);
    return ret;
  }

  public bool getBool() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_getBool(swigCPtr);
    return ret;
  }

  public double getDouble() {
    double ret = OrangeDotNETModulePINVOKE.MValue_getDouble(swigCPtr);
    return ret;
  }

  public uint getULong() {
    uint ret = OrangeDotNETModulePINVOKE.MValue_getULong(swigCPtr);
    return ret;
  }

  public MArray getArray() {
    MArray ret = new MArray(OrangeDotNETModulePINVOKE.MValue_getArray(swigCPtr), true);
    return ret;
  }

  public bool isString() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isString(swigCPtr);
    return ret;
  }

  public bool isInt() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isInt(swigCPtr);
    return ret;
  }

  public bool isBool() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isBool(swigCPtr);
    return ret;
  }

  public bool isDouble() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isDouble(swigCPtr);
    return ret;
  }

  public bool isULong() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isULong(swigCPtr);
    return ret;
  }

  public bool isArray() {
    bool ret = OrangeDotNETModulePINVOKE.MValue_isArray(swigCPtr);
    return ret;
  }

  public void push(MValue key, MValue val) {
    OrangeDotNETModulePINVOKE.MValue_push(swigCPtr, MValue.getCPtr(key), MValue.getCPtr(val));
    if (OrangeDotNETModulePINVOKE.SWIGPendingException.Pending) throw OrangeDotNETModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public MValue get(MValue key) {
    MValue ret = new MValue(OrangeDotNETModulePINVOKE.MValue_get(swigCPtr, MValue.getCPtr(key)), true);
    if (OrangeDotNETModulePINVOKE.SWIGPendingException.Pending) throw OrangeDotNETModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public char type {
    set {
      OrangeDotNETModulePINVOKE.MValue_type_set(swigCPtr, value);
    } 
    get {
      char ret = OrangeDotNETModulePINVOKE.MValue_type_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_void _val {
    set {
      OrangeDotNETModulePINVOKE.MValue__val_set(swigCPtr, SWIGTYPE_p_void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = OrangeDotNETModulePINVOKE.MValue__val_get(swigCPtr);
      SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_int counter {
    set {
      OrangeDotNETModulePINVOKE.MValue_counter_set(swigCPtr, SWIGTYPE_p_int.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = OrangeDotNETModulePINVOKE.MValue_counter_get(swigCPtr);
      SWIGTYPE_p_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_int(cPtr, false);
      return ret;
    } 
  }

}