#include "CurrentExchange.h"
#include "../../Application.h"
void CurrentExchange::OnTextBoxKeyDown(void* sender, KeyEventArgs e)
{
	TextBox* tb = (TextBox*)sender;
	uint16_t* text = tb->Text();

	char* arr = (char*)malloc(unilen(text) + 1);
	getStrFromUni(arr, text);

	int value = atoi(arr)*23;
	char buff[10];
	sprintf(buff, "%d", value);
	
	Control* lbl = this->FindControl("lblDisplayResult");

	lbl->SetText(buff);
	free(arr);
}

void CurrentExchange::OnTextBoxKeyPress(void* sender, KeyEventArgs e)
{
	OnTextBoxKeyDown(sender, e);
}


CurrentExchange::CurrentExchange()
{
	InitializeComponent();
}

CurrentExchange::~CurrentExchange()
{
}

void CurrentExchange::InitializeComponent()
{
	this->Width = 240;
	this->Height = 320;
	this->BackImage = (Image*)GDI::Draw::BackgroundImage;
	this->Name = "CurrentExchange";

	lblUSD.Name = "lblUSD";
	lblUSD.Location = GDI::Point(10, 20);
	lblUSD.ForeColor = GUI_WHITE;
	lblUSD.SetText("USD:");

	tbUsd.Name = "tbUsd";
	tbUsd.SetLocation(10, 45);
	//tbUsd.SetSize(tbUsd.Width, 50);
	tbUsd.EnableScrollBar(false);
	tbUsd.EnableMultiLine(false);
	tbUsd.TabIndex = 1;
	tbUsd.TextType = TextBox::TextTypeNumber;
	tbUsd.KeyDown = ON_KEY_CALLBACK(CurrentExchange::OnTextBoxKeyDown);
	tbUsd.KeyPress = ON_KEY_CALLBACK(CurrentExchange::OnTextBoxKeyPress);


	lblResult.Name = "lblResult";
	lblResult.Location = GDI::Point(10, 80);
	lblResult.ForeColor = GUI_GREEN;
	lblResult.SetText("VND:");

	lblDisplayResult.Name = "lblDisplayResult";
	lblDisplayResult.Location = GDI::Point(10, 100);
	lblDisplayResult.ForeColor = GUI_WHITE;
	lblDisplayResult.SetText("");

	this->Add(&lblUSD);
	this->Add(&tbUsd);
	this->Add(&lblResult);
	this->Add(&lblDisplayResult);
	//tbUsd.Focus();
}

void RunCurrentExchange()
{
	Application::Run(new CurrentExchange());
}