%module OrangeDotNETMono
%{
	#include "API.h"
	#include "CVector3.h"
%}

%include "API.h"
%include "CVector3.h"

%typemap(cscode) APIBase %{
	private API APIReference;
	internal void addReference(API api) {
		APIReference = API;
	}
%}

%typemap(csout, excode=SWIGEXCODE) APIBase& getAPIBase {
	IntPtr cPtr = $imcall;$excode
	$csclassname ret = null;
	if (cPtr != IntPtr.Zero) {
		ret = new $csclassname(cPtr, $owner);
		ret.addReference(this);
	}
	return ret;
}