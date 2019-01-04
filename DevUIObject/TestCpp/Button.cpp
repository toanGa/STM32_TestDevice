#include "Button.h"
#include "Control.h"


Button::Button()
{
	Name = (char*)"Button";
	ControlType = ControlButton;
	Width = 10;
	Height = 20;
}


Button::~Button()
{
}

char* Button::ToString()
{
	printf("Button toString\r\n");
	Control::ToString();
	return (char*)"";
}

void Button::run()
{
	printf("Button run\r\n");
}

void Button::go()
{
	printf("Button Go");
}
