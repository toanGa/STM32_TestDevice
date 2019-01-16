#pragma once
#include "EventArgs.h"
class KeyEventArgs : public EventArgs
{
public:
	char KeyChar;
	// implement
	//virtual char* ToString();
};

typedef void(*KeyEventHandler)(void* sender, KeyEventArgs e);
