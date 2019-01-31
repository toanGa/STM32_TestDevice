#include "MenuWindow.h"
#include "../../FW/Application.h"
#include "../CurrentExchange/CurrentExchange.h"

int idxApp;
char* OptionWindow[NUM_APPS];

MenuWindow::MenuWindow()
{
	InitializeComponent();

	idxApp = 0;
	int i;
	for (i = 0; i < NUM_APPS; i++)
	{
		OptionWindow[i] = (char*)malloc(100);
	}

	strcpy(OptionWindow[0], "Current Exchange");
	strcpy(OptionWindow[1], "Caculator");
	strcpy(OptionWindow[2], "People Info");
	strcpy(OptionWindow[3], "Camera");
	strcpy(OptionWindow[4], "SPhone");

	lblInfo.SetText(OptionWindow[idxApp]);
}


MenuWindow::~MenuWindow()
{
	int i;
	for (i = 0; i < NUM_APPS; i++)
	{
		free(OptionWindow[i]);
		OptionWindow[i] = NULL;
	}
}

void MenuWindow::InitializeComponent()
{
	PTM_WARNING_DISABLE

	__pragma(warning(push))							   
	__pragma(warning(disable: 4640))

	this->Width = 240;
	this->Height = 320;
	this->BackImage = (Image*)GDI::Draw::BackgroundImage;
	this->Name = "CurrentExchange";

	lblUp.Name = "lblUp";
	lblUp.Location = GDI::Point(10, 60);
	lblUp.ForeColor = GUI_WHITE;
	lblUp.SetText("^");

	lblInfo.Name = "lblInfo";
	lblInfo.Location = GDI::Point(10, 80);
	lblInfo.ForeColor = GUI_GREEN;
	lblInfo.SetText("");
	lblInfo.TabIndex = 1;
	lblInfo.KeyDown = ON_KEY_CALLBACK(MenuWindow::LabelKeyDown);
	lblInfo.KeyPress = ON_KEY_CALLBACK(MenuWindow::LabelKeyPress);

	lblDown.Name = "lblDown";
	lblDown.Location = GDI::Point(10, 100);
	lblDown.ForeColor = GUI_WHITE;
	lblDown.SetText("v");

	this->Add(&lblUp);
	this->Add(&lblInfo);
	this->Add(&lblDown);

	this->Disposed = ON_EVENT_CALLBACK(MenuWindow::WindowDisposed);
	lblInfo.Focus();

	__pragma(warning(pop))
	PTM_WARNING_RESTORE
}

void MenuWindow::LabelKeyDown(void * sender, KeyEventArgs e)
{
	switch (e.KeyChar)
	{
	case KEYUP:
		idxApp++;
		if (idxApp >= NUM_APPS)
		{
			idxApp = 0;
		}
		break;
	case KEYDOWN:
		idxApp--;
		if (idxApp < 0)
		{
			idxApp = NUM_APPS - 1;
		}
		break;
	case KEYHOME:
		Application::Exit();
		return;
	case KEYENTER:
		if (idxApp == 0)
		{
			CurrentExchange* currentExchange = new CurrentExchange();
			currentExchange->Start();
			return;
		}
		break;
	}

	Control* lbl = this->FindControl("lblInfo");
	lbl->SetText(OptionWindow[idxApp]);
}

void MenuWindow::LabelKeyPress(void * sender, KeyEventArgs e)
{
	LabelKeyDown(sender, e);
}

void MenuWindow::WindowDisposed(void * obj, EventArgs e)
{
	int i;
	for (i = 0; i < NUM_APPS; i++)
	{
		free(OptionWindow[i]);
		OptionWindow[i] = NULL;
	}
}
