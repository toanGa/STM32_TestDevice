// DevUIObject.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

#include "TestCpp/Button.h"
#include "TestCpp/Label.h"
#include "TestCpp/Window.h"
#include "TestCpp/Panel.h"
#include <stdlib.h>
#include "DevUIObject.h"

void KeyPress(void* sender, KeyEventArgs e)
{
	Control* c = (Control*)sender;
	c->ToString();
	int m = 0;

	c->SetText((char*)"Haha");
}

int main()
{

	Button b1;
	b1.Name = (char*)"button1";
	b1.TabIndex = 1;

	Button b2;
	b2.Name = (char*)"button2";
	b2.TabIndex = 2;

	Label l3;
	l3.Name = (char*)"Lable3";
	l3.TabIndex = 3;

	Label l4;
	l4.Name = (char*)"Lable4";
	l4.TabIndex = 5;

	Window wd = Window();
	Panel panel;
	panel.TabIndex = 4;
	panel.Add(&b1);
	panel.Add(&b2);

	wd.Add(&panel);
	wd.Add(&l3);
	wd.Add(&l4);

	l3.Show();

	l3.KeyPress = KeyPress;
	l4.KeyPress = KeyPress;

	Message m;
	m.Msg = 2;

	wd.WndProc(m);

	wd.FocusNextControl(true);
	wd.WndProc(m);

	wd.FocusNextControl(true);
	wd.WndProc(m);


	Control* testControl = b1.FindWindow();
	testControl = b2.FindWindow();
	testControl = l3.FindWindow();
	testControl = panel.FindWindow();





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
	system("pause");
    return 0;
}

