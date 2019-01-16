#include "Label.h"
#include "Unicode.h"

Label::Label()
{
	Name = (char*)"Lable";
	ControlType = ControlLabel;
	
	// default Lable method
	Height = FontText.height;
}

Label::~Label()
{

}

void Label::SetText(char * content)
{
	// call parent methhod
	Control::SetText(content);

	// update width
	uint16_t* buff = new uint16_t[strlen(GetText()) + 1];
	getUniFromStr(buff, GetText());
	Width = getPixelLength(buff, FontText);
	this->DisplayRectangle = GDI::Rectangle(this->Location, this->Width, this->Height);
	delete buff;

	// Update UI
	this->Update();

}

// TODO: handler event from OS
void Label::WndProc(Message m)
{
	// call to parent method
	Control::WndProc(m);
}

void Label::OnPaint(PaintEventArgs e)
{
	// not need check: Checked in control parent
	PRINTF("%s OnPaint:", this->Name);
	Control* wd = FindWindow();
	if (wd == NULL)
	{
		return;
	}

	//GDI::Rectangle paintRect = GDI::Rectangle(wd->Location.x + this->Location.x, wd->Location.y + this->Location.y, this->Width, this->Height);
	GDI::Point location = RelativeLocation();
	// TODO: control draw over it's window
	GDI::Draw::DrawString(location, this->GetText(), this->FontText, this->ForeColor);

	// paint event for window
	switch (e.PaintOption)
	{
	case PaintEventArgs::PaintDrawControl:
	{
		PRINTF("PaintDrawControl\r\n");
	}
	break;

	case PaintEventArgs::PaintDrawPartControl:
	{
		PRINTF("PaintDrawPartControl\r\n");
	}
	break;

	case PaintEventArgs::PaintHideControl:
	{
		PRINTF("PaintHideControl\r\n");
	}
	break;

	case PaintEventArgs::PaintShowControl:
	{
		PRINTF("PaintShowControl\r\n");
	}
	break;

	case PaintEventArgs::PaintShowPartControl:
	{
		PRINTF("PaintShowPartControl\r\n");
	}
	break;

	default:
		PRINTF("Error\r\n");
		break;
	}
}

void Label::OnPaintBackground(PaintEventArgs e)
{
	// Paint background for window
	PRINTF("%s OnPaintBackground:", this->Name);

	// paint event for window
	switch (e.PaintOption)
	{
	case PaintEventArgs::PaintDrawControl:
	{
		PRINTF("PaintDrawControl\r\n");
	}
	break;

	case PaintEventArgs::PaintDrawPartControl:
	{
		PRINTF("PaintDrawPartControl\r\n");
	}
	break;

	case PaintEventArgs::PaintHideControl:
	{
		PRINTF("PaintHideControl\r\n");
	}
	break;

	case PaintEventArgs::PaintShowControl:
	{
		PRINTF("PaintShowControl\r\n");
	}
	break;

	case PaintEventArgs::PaintShowPartControl:
	{
		PRINTF("PaintShowPartControl\r\n");
	}
	break;

	default:
		PRINTF("Error\r\n");
		break;
	}
}
