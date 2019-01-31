/*
 * TestObj.cpp
 *
 *  Created on: Jan 12, 2019
 *      Author: tranvantoan
 */

#include "Control.h"
#include "Label.h"
#include "TextBox.h"
#include "Window.h"
#include "uart_console.h"
/*
 *@function : keyboardNumber
 *@brief    : implementation for Keyboard0-9, star,hashtag event
 *@parameter: userStatePtr
 *@return   : none
 */
Window* window = NULL;
Label* lable1;
Label *lable2;
TextBox* textbox1;
TextBox* textbox2;

static void LostFocus(void* sender, EventArgs e)
{
	PRINTF("%s Lost focus\r\n", ((Control*)sender)->Name);
}

static void AppropFocus(void* sender, EventArgs e)
{
	PRINTF("%s Approp focus\r\n", ((Control*)sender)->Name);
}

#ifdef __cplusplus
extern "C"
{
#include "user_handler_events.h"
void keyboardTest (userStatePtr* state);
void TestTimer();
void keyboardFunc(char key);
}
#endif

void WindowProcTimer()
{
	Window* wd = window;
	Message m;
	m.Msg = Message::MessageTimer;
	wd->WndProc(m);
}

void keyboardFunc(char key)
{
	//
	Message m;
	switch(key)
	{
	case '0':
		m.Msg = Message::MessageKB0Press;
		break;
	case '1':
		m.Msg = Message::MessageKB1Press;
		break;
	case '2':
		m.Msg = Message::MessageKB2Press;
		break;
	case '3':
		m.Msg = Message::MessageKB3Press;
		break;
	case '4':
		m.Msg = Message::MessageKB4Press;
		break;
	case '5':
		m.Msg = Message::MessageKB5Press;
		break;
	case '6':
		m.Msg = Message::MessageKB6Press;
		break;
	case '7':
		m.Msg = Message::MessageKB7Press;
		break;
	case '8':
		m.Msg = Message::MessageKB8Press;
		break;
	case '9':
		m.Msg = Message::MessageKB9Press;
		break;
	case '*':
		m.Msg = Message::MessageKBStarPress;
		break;
	case '#':
		m.Msg = Message::MessageKBHashtagPress;
		break;
	case KEYUP:
		m.Msg = Message::MessageKBUpPress;
		break;
	case KEYDOWN:
		m.Msg = Message::MessageKBDownPress;
		break;
	case KEYLEFT:
		m.Msg = Message::MessageKBLeftPress;
		break;
	case KEYRIGHT:
		m.Msg = Message::MessageKBRightPress;
		break;
	default:
		return;
	}
	if(window != NULL)
	{
		window->WndProc(m);
	}
}

void keyboardTest (userStatePtr* state)
{
	static int init = 1;
	if (init)
	{
		window = new Window();
		lable1 = new Label();
		lable2 = new Label();
		textbox1 = new TextBox();
		textbox2 = new TextBox();

		window->Width = 240;
		window->Height = 320;
		window->BackColor = GUI_BLACK;
		//window.BackImage = (Image*)GDI::Draw::BackgroundImage;

		lable1->Name = "lable1";
		lable1->Location = GDI::Point(10, 20);
		lable1->DisplayRectangle = GDI::Rectangle(lable1->Location, lable1->Width, lable1->Height);
		lable1->ForeColor = GUI_WHITE;
		lable1->SetText("this is lable 1");
		//lable1->LostFocus = LostFocus;
		//lable1->AppropFocus = AppropFocus;
		lable1->TabIndex = 1;


		lable2->Name = "lable2";
		lable2->Location = GDI::Point(10, 100);
		lable2->DisplayRectangle = GDI::Rectangle(lable2->Location, lable2->Width, lable2->Height);
		lable2->ForeColor = GUI_RED;
		lable2->SetText("this is lable 2");
		//lable2->LostFocus = LostFocus;
		//lable2->AppropFocus = AppropFocus;
		lable2->TabIndex = 2;



		textbox1->Name = "Textbox1";
		textbox1->SetLocation(10, 120);
		textbox1->SetSize(textbox1->Width, 50);
		textbox1->EnableScrollBar(true);
		textbox1->EnableMultiLine(true);
		//textbox1->LostFocus = LostFocus;
		//textbox1->AppropFocus = AppropFocus;
		textbox1->TabIndex = 3;



		textbox2->Name = "Textbox2";
		textbox2->SetLocation(30, 200);
		textbox2->SetSize(textbox1->Width/2, 100);
		textbox2->EnableScrollBar(true);
		textbox2->EnableMultiLine(true);
		//textbox2->LostFocus = LostFocus;
		//textbox2->AppropFocus = AppropFocus;
		textbox2->TabIndex = 4;

		window->Add(lable1);
		window->Add(lable2);
		window->Add(textbox1);
		window->Add(textbox2);

		window->Start();
		textbox1->Focus();
//		lable1->Show();
//		lable2->Show();
//		textbox1->Show();
//		textbox2->Show();

		lable1->Focus();

		init = 0;
	}
	else
	{
		int fake = 0;
		if(fake == 1)
		{
			window->FocusNextControl(true);
		}
		else if(fake == 2)
		{
			window->FocusNextControl(false);
		}
		else if(fake == 3)
		{
			Message m;
			m.Msg = Message::MessageKB6Press;

			window->WndProc(m);
		}

		guiLayerDisplay(&g_layer1[0][0], 0, 0, 239, 319);
	}
}

#include "Timer.h"
Timer* tm;
void TimerTick(void* sender, EventArgs e)
{
	Timer* tm = (Timer*)sender;
	PRINTF("Timer %s callback\r\n", tm->Name);
}

void TestTimer()
{
	static int init = 1;
	if(init)
	{
		tm = new Timer();

		tm->SetInterval(1000);
		tm->Tick = TimerTick;
		tm->Name = "Timer Toan";
		tm->Enable(true);
		init = 0;
	}
	else
	{
		int fake = 0;
		if(fake)
		{
			tm->Enable(false);
		}
	}
}
