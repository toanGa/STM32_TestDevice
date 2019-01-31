#include "Window.h"
#include "Application.h"

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

	PRINTF("Window Created:%s\r\n", this->Name);
}


Window::~Window()
{
	OnDestroy();
	PRINTF("Window Destroyed:%s\r\n", this->Name);
}

// API from user
void Window::Start()
{
//	OnStart();
	// just call app api from user API
	Application *app = Application::AppCurrent();
	FWASSERT(app != NULL);

	Window* currWd = app->CurrentWindow();
	FWASSERT(currWd != NULL);

	currWd->OnPause();

	app->StartWindow(this);
	currWd = app->CurrentWindow();
	currWd->OnStart();
}

void Window::Stop()
{
	Application *app = Application::AppCurrent();
	assert(app != NULL);

	Window* currWd = app->CurrentWindow();
	if(currWd != app->MainWindow())
	{
		currWd->OnStop();

		currWd = app->CurrentWindow();
		currWd->OnResume();
	}
	else
	{
		Application::Exit();
	}
}

void Window::Dispose()
{
	EnableControlTimer(false);

	Control::Dispose();
}

void Window::OnCreate()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowCreate != NULL)
	{
		(this->*WindowCreate)(this, e);
	}
}

void Window::OnStart()
{
	this->Show();
	
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowStart != NULL)
	{
		(this->*WindowStart)(this, e);
	}
}

void Window::OnResume()
{
	this->Show();

	// TODO: implement event with detail args
	EventArgs e;

	if(this->AppropFocus != NULL)
	{
		(this->*AppropFocus)(this, e);
	}


	if (WindowResume != NULL)
	{
		(this->*WindowResume)(this, e);
	}
}

// this window has interrupted by another window
void Window::OnPause()
{
	// TODO: implement event with detail args
	EventArgs e;

	if(this->LostFocus != NULL)
	{
		(this->*LostFocus)(this, e);
	}

	if (WindowPause != NULL)
	{
		(this->*WindowPause)(this, e);
	}
}

void Window::OnStop()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowStop != NULL)
	{
		(this->*WindowStop)(this, e);
	}

	this->Dispose();
}

void Window::OnDestroy()
{
	// TODO: implement event with detail args
	EventArgs e;

	if (WindowDestroy != NULL)
	{
		(this->*WindowDestroy)(this, e);
	}

	this->Dispose();
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
	PRINTF("%s OnPaintBackground:", this->Name);

	// TODO: review: paint event for window
	switch (e.PaintOption)
	{
		// draw window
	case PaintEventArgs::PaintDrawControl:
	{
		PRINTF("PaintDrawControl\r\n");
		this->DisplayRectangle = GDI::Rectangle(this->Location.x, this->Location.y, this->Width, this->Height);

		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawRect(DisplayRectangle, GUI_BLACK);
			GDI::Draw::DrawPicture(*this->BackImage, 0, 0, DisplayRectangle);
		}
		else
		{
			GDI::Draw::DrawRect(DisplayRectangle, this->BackColor);
		}
	}
	break;

	case PaintEventArgs::PaintDrawPartControl:
	{
		PRINTF("PaintDrawPartControl\r\n");

		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawRect(DisplayRectangle, GUI_BLACK);
			GDI::Draw::DrawPicture(*this->BackImage, 0, 0, DisplayRectangle);
		}
		else
		{
			GDI::Draw::DrawRect(this->DisplayRectangle, this->BackColor);
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

		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawRect(DisplayRectangle, GUI_BLACK);
			GDI::Draw::DrawPicture(*this->BackImage, 0, 0, DisplayRectangle);
		}
		else
		{
			GDI::Draw::DrawRect(DisplayRectangle, this->BackColor);
		}
		GDI::Draw::OnShowScreen(DisplayRectangle);
	}
	break;

	case PaintEventArgs::PaintShowPartControl:
	{
		PRINTF("PaintShowPartControl\r\n");
		if (this->BackImage != NULL)
		{
			GDI::Draw::DrawRect(DisplayRectangle, GUI_BLACK);
			GDI::Draw::DrawPicture(*this->BackImage, 0, 0, DisplayRectangle);
		}
		else
		{
			GDI::Draw::DrawRect(this->DisplayRectangle, this->BackColor);
		}
		GDI::Draw::OnShowScreen(this->DisplayRectangle);
	}
	break;

	default:
		PRINTF("Error\r\n");
		break;
	}
}

// Handle message -> call from user
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

// Handle App call -> call from application
void Window::WndProcAppMessage(int AppMess)
{
	switch(AppMess)
	{
	case Application::WindowStart:
		this->OnStart();
		break;
	case Application::WindowResume:
		this->OnResume();
		break;
	case Application::WindowPause:
		this->OnPause();
		break;
	case Application::WindowStop:
		this->OnStop();
		break;
	default:
		PRINTF("Handle fault message\r\n");
	}
}
