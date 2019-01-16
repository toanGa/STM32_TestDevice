#pragma once
#include "EventArgs.h"

class PaintEventArgs : public EventArgs
{
public:
	typedef enum
	{
		PaintDrawControl,
		PaintShowControl,
		PaintHideControl,
		PaintDrawPartControl,
		PaintShowPartControl
	}EPaintOption;
	// modify here
	EPaintOption PaintOption;
};
