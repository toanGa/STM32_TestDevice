#pragma once
#include "../FW/Window.h"
#include "../FW/Label.h"
#include "../FW/TextBox.h"
class CurrentExchange: 
	public Window
{
private:
	Label lblUSD;
	Label lblResult;
	Label lblDisplayResult;
	TextBox tbUsd;

	void InitializeComponent();
public:
	void OnTextBoxKeyDown(void * sender, KeyEventArgs e);
	void OnTextBoxKeyPress(void * obj, KeyEventArgs e);
	CurrentExchange();
	~CurrentExchange();
private:

};

