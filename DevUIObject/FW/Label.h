#pragma once
#include "Control.h"
class Label :
	public Control
{
public:
	Label();
	~Label();
	virtual void SetText(char* content);
	virtual void WndProc(Message m);
protected:
	virtual void OnPaint(PaintEventArgs e);
	virtual void OnPaintBackground(PaintEventArgs pevent);
};

