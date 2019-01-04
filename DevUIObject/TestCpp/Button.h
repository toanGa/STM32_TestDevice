#pragma once
#include "Control.h"
class Button :
	public Control
{
public:
	Button();
	~Button();
	char * ToString();
	void run();
	void go();
};

