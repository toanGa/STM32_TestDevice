#include "Control.h"
#include <stdio.h>


Control::Control()
{

}


Control::~Control()
{

}

void Control::WndProc(Message m)
{
	EventArgs e;
	KeyEventArgs kE;
	// fake
	switch (m.Msg)
	{
	case 0:
		OnTextChanged(e);
		break;
	case 1:
		OnKeyDown(kE);
		break;
	case 2:
		OnKeyPress(kE);
		break;
	case 3:
		OnKeyUp(kE);
		break;
	default:
		break;
	}
}

char * Control::ToString()
{
	printf("Control toString\r\n");
	return Name;
}

void Control::run()
{
	printf("Control run\r\n");
}

void Control::OnTextChanged(EventArgs e)
{
	if (TextChanged != NULL)
	{
		TextChanged(this, e);
	}
}

void Control::OnKeyDown(KeyEventArgs e)
{
	if (KeyDown != NULL)
	{
		KeyDown(this, e);
	}
}

void Control::OnKeyPress(KeyEventArgs e)
{
	if (KeyPress != NULL)
	{
		KeyPress(this, e);
	}
}

void Control::OnKeyUp(KeyEventArgs e)
{
	if (KeyUp != NULL)
	{
		KeyUp(this, e);
	}
}

void Control::BringToFront()
{
}

bool Control::Contains(Control * ctl)
{
	return false;
}

void Control::Add(Control * value)
{
}

void Control::Clear()
{
}

void Control::Remove(Control * value)
{
}

void Control::Update()
{
}

void Control::Hide()
{
}

void Control::Show()
{
}

void Control::Draw()
{
}

void Control::Refresh()
{
}

void Control::ResetBackColor()
{
}

void Control::ResetFont()
{
}

void Control::ResetForeColor()
{
}
