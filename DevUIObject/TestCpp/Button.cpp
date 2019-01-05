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

class A
{
public:
	A()
	{
		printf("A constuctor\r\n");
	}
	A(int, int)
	{
		printf("A int constuctor\r\n");
	}
};

class B: public A
{
public:
	B(int x) :A(0, x)
	{
		int bb = 1;
	}

	B() : A()
	{
		int bb = 1;
	}
};

class C : public A
{

};

void TestABC()
{
	B b();
	C c();
}