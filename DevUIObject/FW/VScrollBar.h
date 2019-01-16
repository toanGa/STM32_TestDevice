#pragma once
#include "Control.h"
#include "IScrollable.h"
class VScrollBar :
	public Control, public IScrollable
{
protected:
	int sizePointer;
	int colorPointer;
public:
	VScrollBar();
	~VScrollBar();
protected:
	// override Control event
	virtual void OnKeyDown(KeyEventArgs e);
	virtual void OnKeyPress(KeyEventArgs e);
	virtual void OnKeyUp(KeyEventArgs e);

	// override Scroll event
	virtual void OnScrollUp();
	virtual void OnScrollDown();

	// fake
public:
	virtual void OnPaint(PaintEventArgs e);
	virtual void OnPaintBackground(PaintEventArgs pevent);
};

