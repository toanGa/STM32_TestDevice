#include "VScrollBar.h"



VScrollBar::VScrollBar()
{
	Name = (char*)"VScrollBar";
	ControlType = ControlVScrollBar;

	BackColor = GUI_GRAY;
	colorPointer = GUI_WHITE;
	sizePointer = 5;
}


VScrollBar::~VScrollBar()
{

}

void VScrollBar::OnKeyDown(KeyEventArgs e)
{
	switch (e.KeyChar)
	{
	case KEYUP:
		OnScrollUp();
		break;
	case KEYDOWN:
		OnScrollDown();
		break;
	default:
		break;
	}


	this->DisplayRectangle = GDI::Rectangle(this->Location, this->Width, this->Height);

	// call to parent method
	// update by Window
	this->Update();
}

void VScrollBar::OnKeyPress(KeyEventArgs e)
{
	// action same OnKeyDown
	OnKeyDown(e);
}

// not process when release key
void VScrollBar::OnKeyUp(KeyEventArgs e)
{
	// nothing
}

void VScrollBar::OnScrollUp()
{
	OnScrollDec();
}

void VScrollBar::OnScrollDown()
{
	OnScrollInc();
}

void VScrollBar::OnPaint(PaintEventArgs e)
{
	int16_t barActive_y = this->Location.y +
		(Height - sizePointer)*(GetActive()) / (GetTotal() - 1);

	GDI::Draw::DrawRect(GDI::Rectangle(Location.x, barActive_y, Width,
		sizePointer), colorPointer);

}

void VScrollBar::OnPaintBackground(PaintEventArgs pevent)
{

	GDI::Draw::DrawRect(GDI::Rectangle(Location, Width, Height), BackColor);

	// draw backgorund
	if (BackImage != NULL)
	{
		GDI::Draw::DrawPicture(*BackImage, Location);
	}
}
	
