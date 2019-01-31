#pragma once
#include "FW\Window.h"
#include "../FW/Label.h"




class MenuWindow :
	public Window
{
#define NUM_APPS   5
private:
	Label lblUp;
	Label lblDown;
	Label lblInfo;
	

	void InitializeComponent();
	
public:
	MenuWindow();
	~MenuWindow();

private:
	void LabelKeyDown(void * sender, KeyEventArgs e);
	void LabelKeyPress(void * obj, KeyEventArgs e);
	void WindowDisposed(void * obj, EventArgs e);
};

