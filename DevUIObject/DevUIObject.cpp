// DevUIObject.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

#include "TestCpp/Button.h"
#include "TestCpp/Label.h"
#include <stdlib.h>
#include "DevUIObject.h"

void KeyPress(void* sender, KeyEventArgs e)
{
	Control* c = (Control*)sender;
	c->ToString();
	int m = 0;
}

int main()
{
	Button b1;
	Button b2;
	Message m;
	m.Msg = 2;

	b1.KeyPress = KeyPress;
	b1.WndProc(m);
	

	b1.ToString();
	b2.ToString();
	
	Label lbl;
	Label* lblPtr;

	Control* ctl = new Button();
	Control base;

	//b.toString();
	//b.run();
	//ctl = &b;

	ctl->run();
	ctl->ToString();

	ctl = &lbl;
	ctl->Name;

	//lblPtr = (Label*)&b;
	void TestABC();

	TestABC();
	system("pause");
    return 0;
}

