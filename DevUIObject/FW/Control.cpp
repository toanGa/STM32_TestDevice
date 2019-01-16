#include "Control.h"
#include <stdio.h>

const int Control::DEFAULT_TEXT_SIZE = 256;
const Font Control::DefaultFont = GUI_FontEurostile13;
const Color Control::DefaultForeColor = GUI_WHITE;
const Color Control::DefaultBackColor = GUI_BLACK;
Timer Control::ControlTimer = Timer(1000, Control::CallBackControlTimer);

void Control::CallBackControlTimer(void* sender, EventArgs e)
{
	// TODO: implement here\r\n
	PRINTF("OnControlTimer\r\n");
	// Find window active -> Global list window

	static int fake = 1;
	if(fake)
	{
		void WindowProcTimer();
		WindowProcTimer();
	}

	// Send message to window
}

Control::Control()
{
    Name = (char*)"Control";
    ControlType = ControlBase;
	MasterControl = NULL;
	Focusing = NULL;
	Visible = true;
	Enable = true;
    Text = NULL;
	SetTextSize(DEFAULT_TEXT_SIZE);
	FontText = FONT_USSD;

    TextChanged = NULL;
    KeyDown = NULL;
    KeyPress = NULL;
    KeyUp = NULL;
	AppropFocus = NULL;
	LostFocus = NULL;

	Width = 0;
	Height = 0;
	Location.x = 0;
	Location.y = 0;
	Tag = NULL;
	TabIndex = 0;

	FontText = DefaultFont;
	BackColor = DefaultBackColor;
	ForeColor = DefaultForeColor;
	BoderColor = BackColor;
	BoderSize = 0;

	DisplayRectangle.X = Location.x;
	DisplayRectangle.Y = Location.y;
	DisplayRectangle.Width = Width;
	DisplayRectangle.Height = Height;

//	if(ControlTimer == NULL)
//	{
//		if(this->ControlType == ControlWindow)
//		{
//			ControlTimer = new Timer(1000, Control::CallBackControlTimer);
//		}
//	}
}

Control::~Control()
{
	if (Text != NULL)
	{
		free(Text);
	}
}

void Control::EnableControlTimer(bool enable)
{
	ControlTimer.Enable(enable);
//	if(ControlTimer != NULL)
//	{
//		ControlTimer->Enable(enable);
//	}
}

// Handler all event
void Control::WndProc(Message m)
{
	// TODO: implement detail argument
	EventArgs e;
	KeyEventArgs kE;
	// fake
	
	switch (m.Msg)
	{
	case Message::MessageKB0Up:
		kE.KeyChar = '0';
		OnKeyUp(kE);
		break;
	case Message::MessageKB0Down:
		kE.KeyChar = '0';
		OnKeyDown(kE);
		break;
	case Message::MessageKB0Press:
		kE.KeyChar = '0';
		OnKeyPress(kE);
		break;
	case Message::MessageKB1Up:
		kE.KeyChar = '1';
		OnKeyUp(kE);
		break;
	case Message::MessageKB1Down:
		kE.KeyChar = '1';
		OnKeyDown(kE);
		break;
	case Message::MessageKB1Press:
		kE.KeyChar = '1';
		OnKeyPress(kE);
		break;
	case Message::MessageKB2Up:
		kE.KeyChar = '2';
		OnKeyUp(kE);
		break;
	case Message::MessageKB2Down:
		kE.KeyChar = '2';
		OnKeyDown(kE);
		break;
	case Message::MessageKB2Press:
		kE.KeyChar = '2';
		OnKeyPress(kE);
		break;
	case Message::MessageKB3Up:
		kE.KeyChar = '3';
		OnKeyUp(kE);
		break;
	case Message::MessageKB3Down:
		kE.KeyChar = '3';
		OnKeyDown(kE);
		break;
	case Message::MessageKB3Press:
		kE.KeyChar = '3';
		OnKeyPress(kE);
		break;
	case Message::MessageKB4Up:
		kE.KeyChar = '4';
		OnKeyUp(kE);
		break;
	case Message::MessageKB4Down:
		kE.KeyChar = '4';
		OnKeyDown(kE);
		break;
	case Message::MessageKB4Press:
		kE.KeyChar = '4';
		OnKeyPress(kE);
		break;
	case Message::MessageKB5Up:
		kE.KeyChar = '5';
		OnKeyUp(kE);
		break;
	case Message::MessageKB5Down:
		kE.KeyChar = '5';
		OnKeyDown(kE);
		break;
	case Message::MessageKB5Press:
		kE.KeyChar = '5';
		OnKeyPress(kE);
		break;
	case Message::MessageKB6Up:
		kE.KeyChar = '6';
		OnKeyUp(kE);
		break;
	case Message::MessageKB6Down:
		kE.KeyChar = '6';
		OnKeyDown(kE);
		break;
	case Message::MessageKB6Press:
		kE.KeyChar = '6';
		OnKeyPress(kE);
		break;
	case Message::MessageKB7Up:
		kE.KeyChar = '7';
		OnKeyUp(kE);
		break;
	case Message::MessageKB7Down:
		kE.KeyChar = '7';
		OnKeyDown(kE);
		break;
	case Message::MessageKB7Press:
		kE.KeyChar = '7';
		OnKeyPress(kE);
		break;
	case Message::MessageKB8Up:
		kE.KeyChar = '8';
		OnKeyUp(kE);
		break;
	case Message::MessageKB8Down:
		kE.KeyChar = '8';
		OnKeyDown(kE);
		break;
	case Message::MessageKB8Press:
		kE.KeyChar = '8';
		OnKeyPress(kE);
		break;
	case Message::MessageKB9Up:
		kE.KeyChar = '9';
		OnKeyUp(kE);
		break;
	case Message::MessageKB9Down:
		kE.KeyChar = '9';
		OnKeyDown(kE);
		break;
	case Message::MessageKB9Press:
		kE.KeyChar = '9';
		OnKeyPress(kE);
		break;
	case Message::MessageKBStarUp:
		kE.KeyChar = '*';
		OnKeyUp(kE);
		break;
	case Message::MessageKBStarDown:
		kE.KeyChar = '*';
		OnKeyDown(kE);
		break;
	case Message::MessageKBStarPress:
		kE.KeyChar = '*';
		OnKeyPress(kE);
		break;
	case Message::MessageKBHashtagUp:
		kE.KeyChar = '#';
		OnKeyUp(kE);
		break;
	case Message::MessageKBHashtagDown:
		kE.KeyChar = '#';
		OnKeyDown(kE);
		break;
	case Message::MessageKBHashtagPress:
		kE.KeyChar = '#';
		OnKeyPress(kE);
		break;
	case Message::MessageKBUpUp:
		kE.KeyChar = KEYUP;
		OnKeyUp(kE);
		break;
	case Message::MessageKBUpDown:
		kE.KeyChar = KEYUP;
		OnKeyDown(kE);
		break;
	case Message::MessageKBUpPress:
		kE.KeyChar = KEYUP;
		OnKeyPress(kE);
		break;
	case Message::MessageKBDownUp:
		kE.KeyChar = KEYDOWN;
		OnKeyUp(kE);
		break;
	case Message::MessageKBDownDown:
		kE.KeyChar = KEYDOWN;
		OnKeyDown(kE);
		break;
	case Message::MessageKBDownPress:
		kE.KeyChar = KEYDOWN;
		OnKeyPress(kE);
		break;
	case Message::MessageKBLeftUp:
		kE.KeyChar = KEYLEFT;
		OnKeyUp(kE);
		break;
	case Message::MessageKBLeftDown:
		kE.KeyChar = KEYLEFT;
		OnKeyDown(kE);
		break;
	case Message::MessageKBLeftPress:
		kE.KeyChar = KEYLEFT;
		OnKeyPress(kE);
		break;
	case Message::MessageKBRightUp:
		kE.KeyChar = KEYRIGHT;
		OnKeyUp(kE);
		break;
	case Message::MessageKBRightDown:
		kE.KeyChar = KEYRIGHT;
		OnKeyDown(kE);
		break;
	case Message::MessageKBRightPress:
		kE.KeyChar = KEYRIGHT;
		OnKeyPress(kE);
		break;


	case Message::MessageKBLeftSelectUp:
		kE.KeyChar = KEYLEFTSELECT;
		OnKeyUp(kE);
		break;
	case Message::MessageKBLeftSelectDown:
		kE.KeyChar = KEYLEFTSELECT;
		OnKeyDown(kE);
		break;
	case Message::MessageKBLeftSelectPress:
		kE.KeyChar = KEYLEFTSELECT;
		OnKeyPress(kE);
		break;

	case Message::MessageKBRightSelectUp:
		kE.KeyChar = KEYRIGHTSELECT;
		OnKeyUp(kE);
		break;
	case Message::MessageKBRightSelectDown:
		kE.KeyChar = KEYRIGHTSELECT;
		OnKeyDown(kE);
		break;
	case Message::MessageKBRightSelectPress:
		kE.KeyChar = KEYRIGHTSELECT;
		OnKeyPress(kE);
		break;


	case Message::MessageKBHomeUp:
		kE.KeyChar = KEYHOME;
		OnKeyUp(kE);
		break;// end call
	case Message::MessageKBHomeDown:
		kE.KeyChar = KEYHOME;
		OnKeyDown(kE);
		break;
	case Message::MessageKBHomePress:
		kE.KeyChar = KEYHOME;
		OnKeyPress(kE);
		break;
	case Message::MessageKBCallUp:
		kE.KeyChar = KEYCALL;
		OnKeyUp(kE);
		break;
	case Message::MessageKBCallDown:
		kE.KeyChar = KEYCALL;
		OnKeyDown(kE);
		break;
	case Message::MessageKBCallPress:
		kE.KeyChar = KEYCALL;
		OnKeyPress(kE);
		break;
	case Message::MessageKBVolupUp:
		kE.KeyChar = KEYVOLUP;
		OnKeyUp(kE);
		break;
	case Message::MessageKBVolupDown:
		kE.KeyChar = KEYVOLUP;
		OnKeyDown(kE);
		break;
	case Message::MessageKBVolupPress:
		kE.KeyChar = KEYVOLUP;
		OnKeyPress(kE);
		break;
	case Message::MessageKBVoldownUp:
		kE.KeyChar = KEYVOLDOWN;
		OnKeyUp(kE);
		break;
	case Message::MessageKBVoldownDown:
		kE.KeyChar = KEYVOLDOWN;
		OnKeyDown(kE);
		break;
	case Message::MessageKBVoldownPress:
		kE.KeyChar = KEYVOLDOWN;
		OnKeyPress(kE);
		break;
	case Message::MessageKBPowerUp:
		kE.KeyChar = KEYPOWER;
		OnKeyUp(kE);
		break;
	case Message::MessageKBPowerDown:
		kE.KeyChar = KEYPOWER;
		OnKeyDown(kE);
		break;
	case Message::MessageKBPowerPress:
		kE.KeyChar = KEYPOWER;
		OnKeyPress(kE);
		break;
	case Message::MessageTimer:
		OnControlTimer(e);
		break;
	default:
		break;
	}
}

char * Control::ToString()
{
	return Name;
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
	PRINTF("%s Control::OnKeyDown\r\n", this->Name);

	// implement for switch focusing
	switch(e.KeyChar)
	{
	case KEYUP:
		this->FocusNextControl(false);
		break;
	case KEYDOWN:
		this->FocusNextControl(true);
		break;
	default:
		break;
	}

	if (KeyDown != NULL)
	{
		KeyDown(this, e);
	}
}

void Control::OnKeyPress(KeyEventArgs e)
{
	PRINTF("%s Control::OnKeyPress\r\n", this->Name);

	// implement for switch focusing
	switch(e.KeyChar)
	{
	case KEYUP:
		this->FocusNextControl(false);
		break;
	case KEYDOWN:
		this->FocusNextControl(true);
		break;
	default:
		break;
	}

	if (KeyPress != NULL)
	{
		KeyPress(this, e);
	}
}

void Control::OnKeyUp(KeyEventArgs e)
{
	PRINTF("%s Control::OnKeyUp\r\n", this->Name);
	if (KeyUp != NULL)
	{
		KeyUp(this, e);
	}
}

void Control::OnControlTimer(EventArgs e)
{
	// depend on specific control to handler control
	PRINTF("Detect leak Timer \r\n");

	ControlTimer.Enable(false);

//	if(ControlTimer != NULL)
//	{
//		ControlTimer->Enable(false);
//	}
}

void Control::OnLostFocus(EventArgs e)
{
	if (LostFocus != NULL)
	{
		LostFocus(this, e);
	}
}

void Control::OnAppropFocus(EventArgs e)
{
	if (AppropFocus != NULL)
	{
		AppropFocus(this, e);
	}
}

void Control::OnPaint(PaintEventArgs e)
{
	// paint component
	PRINTF("%s: OnPaint\r\n", this->Name);
}

void Control::OnPaintBackground(PaintEventArgs pevent)
{
	PRINTF("%s: OnPaintBackground\r\n", this->Name);
}

void Control::OnUpdateControl(Control * control)
{
	if ((this->ControlType == this->ControlWindow) && control->Visible)
	{
		// TODO: confirm rectangle
		// update window: draw
		this->DisplayRectangle = control->DisplayRectangle;
		this->Update();

		// update control: draw
		PaintEventArgs pArg;
		pArg.PaintOption = PaintEventArgs::PaintDrawPartControl;

		control->OnPaintBackground(pArg);
		control->OnPaint(pArg);

		// show on screen: show
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
}

void Control::OnHideControl(Control * control)
{
	if ((this->ControlType == this->ControlWindow) && control->Visible)
	{
		// TODO: confirm rectangle
		this->DisplayRectangle = control->DisplayRectangle;
		this->Update();

		control->Visible = false;

		// Donot update UI if not visible
		//PaintEventArgs pArg;
		//pArg.PaintOption = PaintEventArgs::PaintHideControl;

		//control->OnPaintBackground(pArg);
		//control->OnPaint(pArg);

		if (this->Focusing == control)
		{
			bool focusStat = this->FocusNextControl(true);
			if (!focusStat)
			{
				this->FocusNextControl(false);
			}
		}

		// show on screen
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
}

void Control::OnShowControl(Control * control)
{
	if (this->ControlType == this->ControlWindow)
	{
		// Update window
		// TODO: confirm rectangle
		this->DisplayRectangle = control->DisplayRectangle;
		this->Update();

		// update control
		control->Visible = true;

		PaintEventArgs pArg;
		pArg.PaintOption = PaintEventArgs::PaintShowControl;

		control->OnPaintBackground(pArg);
		control->OnPaint(pArg);

		// show on screen
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
}

void Control::OnDrawControl(Control * control)
{
	if ((this->ControlType == this->ControlWindow) && control->Visible)
	{
		// TODO: confirm rectangle
		this->DisplayRectangle = control->DisplayRectangle;
		this->Update();

		PaintEventArgs pArg;
		pArg.PaintOption = PaintEventArgs::PaintDrawPartControl;

		control->OnPaintBackground(pArg);
		control->OnPaint(pArg);
	}

}

// Multi window control -> implement later
void Control::BringToFront()
{
	//Control* wd = FindWindow();
	//if (wd != NULL)
	//{
	//	wd->Focusing = this;

	//	PaintEventArgs pArg;
	//	pArg.PainOption = PaintEventArgs::PaintShowControl;

	//	OnPaintBackground(pArg);
	//	OnPaint(pArg);
	//}
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

	if (Focusing == NULL)
	{
		Focusing = value;
	}
	else
	{
		if (value->TabIndex < Focusing->TabIndex)
		{
			Focusing = value;
		}
	}
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

// this version, not get next in case cycle
Control * Control::GetNextControl(Control * ctl, bool forward)
{
	Control * next = NULL;

	int totalControl = ListControlAdded.size();
	if (totalControl > 1)
	{
		int oldTabIdx = Focusing->TabIndex;
		int currTabIdx = oldTabIdx;
		bool first = true;
		if (forward)
		{
			int i;
			for (i = 0; i < totalControl; i++)
			{
				if ( (ListControlAdded.at(i) != ctl) && (ListControlAdded.at(i)->TabIndex >= oldTabIdx) && (ListControlAdded.at(i)->Visible))
				{
					if (first)
					{
						currTabIdx = ListControlAdded.at(i)->TabIndex;
						next = ListControlAdded.at(i);
						first = false;
					}
					else
					{
						if (ListControlAdded.at(i)->TabIndex < currTabIdx)
						{
							currTabIdx = ListControlAdded.at(i)->TabIndex;
							next = ListControlAdded.at(i);
						}
					}
					
				}
			}
		}
		else
		{
			int i;
			for (i = 0; i < totalControl; i++)
			{
				if ( (ListControlAdded.at(i) != ctl) && (ListControlAdded.at(i)->TabIndex <= oldTabIdx) && (ListControlAdded.at(i)->Visible))
				{
					if (first)
					{
						currTabIdx = ListControlAdded.at(i)->TabIndex;
						next = ListControlAdded.at(i);
						first = false;
					}
					else
					{
						if (ListControlAdded.at(i)->TabIndex > currTabIdx)
						{
							currTabIdx = ListControlAdded.at(i)->TabIndex;
							next = ListControlAdded.at(i);
						}
					}

				}
			}
		}
	}
	else
	{
		if (totalControl == 1)
		{
			next = ListControlAdded.at(0);
		}
	}
	return next;
}

// using window call
bool Control::FocusNextControl(bool forward)
{
	Control* wd = this->FindWindow();

	if(wd != NULL)
	{
		Control* next = wd->GetNextControl(wd->Focusing, forward);
		Control* focusing = wd->Focusing;

		if (next != NULL)
		{
			if(next != focusing)
			{
				wd->Focusing = next;

				wd->Refresh();

				// Implement detail event argument
				EventArgs e;

				focusing->OnLostFocus(e);
				next->OnAppropFocus(e);
			}
			return true;
		}
	}

	return false;
}

GDI::Point Control::RelativeLocation()
{
	GDI::Point relativePoint = this->Location;
	Control* wd = FindWindow();
	if (wd != NULL && (this->ControlType != ControlWindow))
	{
		relativePoint.x += wd->Location.x;
		relativePoint.y += wd->Location.y;
	}
	return relativePoint;
}

GDI::Rectangle Control::ControlRectangle()
{
	return GDI::Rectangle(this->Location, this->Width, this->Height);
}

// Update with Rectangle call in child
// Draw function
void Control::Update()
{
	Control* wd = FindWindow();
	if (wd != NULL && this->ControlType != ControlWindow)
	{
		wd->OnUpdateControl(this);
	}
	else
	{
		if (this->ControlType == ControlWindow)
		{
			// privious call must set part of rect show
			PaintEventArgs pArg;
			pArg.PaintOption = PaintEventArgs::PaintDrawPartControl;

			this->OnPaintBackground(pArg);
			this->OnPaint(pArg);
		}
	}
}

void Control::Hide()
{
	Control* wd = FindWindow();
	if (wd != NULL && this->ControlType != ControlWindow)
	{
		wd->OnHideControl(this);
	}


}

void Control::Show()
{
	Control* wd = FindWindow();
	if (wd != NULL)
	{
		if (this->ControlType != ControlWindow)
		{
			wd->OnShowControl(this);
		}
		else
		{
			wd->Refresh();
		}
	}
}

void Control::Draw()
{
	Control* wd = FindWindow();
	if (wd != NULL && this->ControlType != ControlWindow)
	{
		wd->OnDrawControl(this);
	}
}

// Implement
void Control::Dispose()
{
	this->Enable = false;

	// clean resource
}

bool Control::Focus()
{
	Control* wd = FindWindow();
	Control* focusOld = wd->Focusing;

	if (wd != NULL)
	{
		wd->Focusing = this;
		// TODO: Implement detail event
		EventArgs lostEvent;
		EventArgs AppropEvent;

		focusOld->OnLostFocus(lostEvent);
		this->OnAppropFocus(AppropEvent);

		// Update UI
		wd->OnShowControl(this);

		return true;
	}
	return false;
}

bool Control::IsFocusing()
{
	Control* wd = FindWindow();
	if (wd != NULL)
	{
		Control* focusing = wd->Focusing;
		if (this == focusing)
		{
			return true;
		}
	}
	return false;
}

// return if fined window
// return itselt if it is window
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
		if (wd == NULL)
		{
			return NULL;
		}
	}
	while (wd->MasterControl != NULL);

	if (wd->ControlType == ControlWindow)
	{
		return wd;
	}

	return NULL;
}

// Text has dynamic allocation
// Text must be private
char * Control::GetText()
{
	return Text;
}

void Control::SetText(char * content)
{
	strcpy(Text, content);
}

// size in byte
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

// window call
void Control::Refresh()
{
	// Update all
	if (this->ControlType == ControlWindow)
	{
		// TODO: implemet refresh all control
		// paint background
		PaintEventArgs pE;
		int numChilds = ListControlAdded.size();
		int i;

		pE.PaintOption = PaintEventArgs::PaintDrawControl;

		// paint for window
		this->OnPaintBackground(pE);
		this->OnPaint(pE);
		// paint child
		for(i = 0; i < numChilds; i++)
		{
			ListControlAdded.at(i)->OnPaintBackground(pE);
			ListControlAdded.at(i)->OnPaint(pE);
		}
		// draw child component
		// show on screen: show
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
	else
	{
		this->Show();
	}
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
