#include "Window.h"



Window::Window()
{
	Name = (char*)"Window";
	ControlType = ControlWindow;

	WindowCreate = NULL;
	WindowStart = NULL;
	WindowResume = NULL;
	WindowPause = NULL;
	WindowStop = NULL;
	WindowDestroy = NULL;
	BackColor = GUI_WHITE;
	ForeColor = GUI_BLACK;


	OnCreate();
}


Window::~Window()
{

	OnDestroy();
}

void Window::Start()
{
	OnStart();
}

void Window::Stop()
{
	OnStop();
}

void Window::OnCreate()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowCreate != NULL)
	{
		WindowCreate(this, e);
	}
}

void Window::OnStart()
{
//	PaintEventArgs pE;
//	pE.PaintOption = PaintEventArgs::PaintShowControl;
//
//	OnPaintBackground(pE);
//	OnPaint(pE);
//
//	GDI::Draw::OnShowScreen(GDI::Rectangle(this->Location, this->Width, this->Height));

	this->Show();
	
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowStart != NULL)
	{
		WindowStart(this, e);
	}
}

void Window::OnResume()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowResume != NULL)
	{
		WindowResume(this, e);
	}
}

// this window has interrupted by another window
void Window::OnPause()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowPause != NULL)
	{
		WindowPause(this, e);
	}
}

void Window::OnStop()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowStop != NULL)
	{
		WindowStop(this, e);
	}
}

void Window::OnDestroy()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowDestroy != NULL)
	{
		WindowDestroy(this, e);
	}
}

void Window::OnPaint(PaintEventArgs e)
{
	PRINTF("%s OnPaint:", this->Name);

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

void Window::OnPaintBackground(PaintEventArgs e)
{
	// TODO: Paint background for window
	PRINTF("%s OnPaintBackground:", this->Name);

	//GDI::Draw::DrawRect(GDI::Rectangle(this->Location.x, this->Location.y, this->Width - 1, this->Height - 1), this->BackColor);
	//if (this->BackImage != NULL)
	//{
	//	GDI::Draw::DrawPicture(*this->BackImage, this->Location.x, this->Location.y);
	//}

	// paint event for window
	switch (e.PaintOption)
	{
		// draw window
	case PaintEventArgs::PaintDrawControl:
	{
		PRINTF("PaintDrawControl\r\n");
		this->DisplayRectangle = GDI::Rectangle(this->Location.x, this->Location.y, this->Width - 1, this->Height - 1);
		GDI::Draw::DrawRect(DisplayRectangle, this->BackColor);
		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawPicture(*this->BackImage, this->Location.x, this->Location.y);
		}
	}
	break;

	case PaintEventArgs::PaintDrawPartControl:
	{
		PRINTF("PaintDrawPartControl\r\n");
		GDI::Draw::DrawRect(this->DisplayRectangle, this->BackColor);
		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawPicture(*this->BackImage, this->Location.x, this->Location.y);
		}
	}
	break;

	// window was hidden
	case PaintEventArgs::PaintHideControl:
	{
		PRINTF("PaintHideControl\r\n");
	}
	break;

	case PaintEventArgs::PaintShowControl:
	{
		PRINTF("PaintShowControl\r\n");
		this->DisplayRectangle = GDI::Rectangle(this->Location.x, this->Location.y, this->Width - 1, this->Height - 1);
		GDI::Draw::DrawRect(DisplayRectangle, this->BackColor);
		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawPicture(*this->BackImage, this->Location.x, this->Location.y);
		}
		// TODO: show method
		GDI::Draw::OnShowScreen(DisplayRectangle);
	}
	break;

	case PaintEventArgs::PaintShowPartControl:
	{
		PRINTF("PaintShowPartControl\r\n");
		GDI::Draw::DrawRect(this->DisplayRectangle, this->BackColor);
		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawPicture(*this->BackImage, this->Location.x, this->Location.y);
		}
		// TODO: show method
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
	break;

	default:
		PRINTF("Error\r\n");
		break;
	}
}

void Window::WndProc(Message m)
{
	Control* focusing = this->Focusing;
	if (focusing != NULL)
	{
		focusing->WndProc(m);
	}

	// call to parent method
	//Control::WndProc(m);
}
