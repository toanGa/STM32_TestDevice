#include "Control.h"
#include <stdio.h>


Control::Control()
{
    Name = (char*)"Control";
    ControlType = ControlBase;
	MasterControl = NULL;
	Focusing = this;
	Visible = false;
	Enable = true;
    Text = NULL;
	SetTextSize(128);

    TextChanged = NULL;
    KeyDown = NULL;
    KeyPress = NULL;
    KeyUp = NULL;

	DisplayRectangle.X = Location.x;
	DisplayRectangle.Y = Location.y;
	DisplayRectangle.Width = Width;
	DisplayRectangle.Height = Height;
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

void Control::OnLostFocus(EventArgs e)
{
	if (LostFocus != NULL)
	{
		LostFocus(this, e);
	}
}

void Control::OnPaint(PaintEventArgs e)
{
	// paint component
}

void Control::OnPaintBackground(PaintEventArgs pevent)
{
	// Paint background color
	// Paint background image
}

void Control::BringToFront()
{
	Control* wd = FindWindow();
	if (wd != NULL)
	{
		wd->Focusing = this;

		PaintEventArgs pArg;
		pArg.PainOption = PaintEventArgs::PaintShowControl;

		OnPaintBackground(pArg);
		OnPaint(pArg);
	}
}

bool Control::Contains(Control * ctl)
{
	// TODO: implement
	return false;
}

void Control::Add(Control * value)
{
	// TODO: assert control is existed (same name)
	// TODO: value is added by another component
	ListControlAdded.push_back(value);
	value->MasterControl = this;
}

void Control::Clear()
{
	// TODO: implement
}

void Control::Remove(Control * value)
{
	int totalControl = ListControlAdded.size();
	if (totalControl > 0)
	{
		int i;
		for (i = 0; i < totalControl; i++)
		{
			if (ListControlAdded.at(i) == value)
			{
				ListControlAdded.erase(ListControlAdded.begin() + i);
				value->MasterControl = NULL;
			}
		}
	}
}

Control * Control::GetNextControl(Control * ctl, bool forward)
{
	Control * next = NULL;

	int totalControl = ListControlAdded.size();
	if (totalControl)
	{
		int currTabIdx = Focusing->TabIndex;
		if (forward)
		{
			int i;
			for (i = 0; i < totalControl; i++)
			{
				if (ListControlAdded.at(i)->TabIndex >= currTabIdx)
				{
					next = ListControlAdded.at(i);
					break;
				}
			}
		}
		else
		{
			int i;
			for (i = 0; i < totalControl; i++)
			{
				if (ListControlAdded.at(i)->TabIndex <= currTabIdx)
				{
					next = ListControlAdded.at(i);
					break;
				}
			}
		}
	}
	return next;
}

// Update with Rectangle call in child
void Control::Update()
{
	PaintEventArgs pArg;
	pArg.PainOption = PaintEventArgs::PaintShowPartControl;

	OnPaintBackground(pArg);
	OnPaint(pArg);
}

void Control::Hide()
{
	this->Visible = false;

	PaintEventArgs pArg;
	pArg.PainOption = PaintEventArgs::PaintHideControl;

	OnPaintBackground(pArg);
	OnPaint(pArg);
}

void Control::Show()
{
	this->Visible = true;

	PaintEventArgs pArg;
	pArg.PainOption = PaintEventArgs::PaintShowControl;

	OnPaintBackground(pArg);
	OnPaint(pArg);
}

void Control::Draw()
{
	PaintEventArgs pArg;
	pArg.PainOption = PaintEventArgs::PaintDrawPartControl;

	OnPaintBackground(pArg);
	OnPaint(pArg);
}

void Control::Dispose()
{
	this->Enable = false;

	// clean resource
}

bool Control::Focus()
{
	Control* wd = FindWindow();
	if (wd != NULL)
	{
		wd->Focusing = this;
		return true;
	}
	return false;
}

Control * Control::FindWindow()
{
	Control* wd = this;

	do
	{
		if (wd->ControlType == ControlWindow)
		{
			return wd;
		}
		wd = wd->MasterControl;
	}
	while (wd->MasterControl != NULL);

	if (wd->ControlType == ControlWindow)
	{
		return wd;
	}

	return NULL;
}

char * Control::GetText()
{
	return Text;
}

void Control::SetText(char * content)
{
	strcpy(Text, content);
}

int Control::GetTextSize()
{
	return TextSize;
}

bool Control::SetTextSize(int size)
{
	// assert size >= 0
	if (Text != NULL)
	{
		free(Text);
	}
	Text = (char*)malloc(size + 1);
	if (Text != NULL)
	{
		memset(Text, 0, size + 1);
		TextSize = size;
		return true;
	}
	return false;
}

void Control::Refresh()
{
	// Update all
}

void Control::ResetBackColor()
{
	// Implementation
}

void Control::ResetFont()
{
	// Implementation
}

void Control::ResetForeColor()
{
	// Implementation
}
