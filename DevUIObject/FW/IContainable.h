#pragma once
#include "Control.h"
class IContainable
{
public:
	IContainable();
	~IContainable();
protected:
	virtual void OnUpdateControl(Control* control);
	virtual void OnHideControl(Control* control);
	virtual void OnShowControl(Control* control);
	virtual void OnDrawControl(Control* control);
};

