#pragma once
#include "Control.h"
#include "KeyBoard.h"
#include "VScrollBar.h"
#include "TextInfo.h"
#include "Timer.h"
class TextBox :
	public Control
{
private:
	#define MAX_TEXT 2019

	uint32_t colorWrap;
	uint16_t distanceText;
	uint8_t isMultiLine;
	// 0: 019497493
	// 1: Toi di hoc
	// 2: Tran Van Toan
	uint8_t isTypeTextName; // isTypeTextName = 0 - 1 - 2
	bool enableScrollBar;
	uint16_t alignLeft;
	uint16_t alignRight;
	//    uint8_t ptrIndex;
	uint8_t enable_border; //1: enable border
						   //0: disable
						   //2: disable have transparent
	uint8_t lockPointer;
	uint16_t* content;
	uint16_t content_len;
	int16_t contentIndex;
	uint8_t maxLineDisplay;
	uint16_t maxLenText;
	uint16_t numberLineOfContent; // total line of content
	uint16_t lineStartOfContent; // line start display

	uint16_t indexStart;
	//    uint16_t                lineSelectOfContent;
	uint16_t linePoiter;     // LOCAL: dong chua con tro hien thi
							 // toan add
	uint8_t enableBlinking;

	// global in EditText
	int16_t xPoint;
	int16_t yPoint;
	TextInfo textInfoBuffer;

	void Up();
	void UpToFistLine ();
	void Down();
	void DownToEndLine();
	void LeftPress();
	void RightPress();
		 
	void AddKeyboardChar(uint8_t kbChar);
	void ClearChar();
	void ForceClearChar();
	void AddChar(int16_t uniChar);
	void AddText(uint16_t* text);
		 
	void DrawPtr();

	uint8_t IsPointingEndLine( );
	uint16_t GetLineActive( );

	void UpdateIndex();
	void Reset();
private:
	KeyBoard keyboard;
	bool enableScrollbar;
	uint8_t mOldKey;
	uint32_t mTimeClock;
	//void DrawBgr();
	void DrawWrap();
	void CheckIndexPointer();
	void UpdateLocateScrollBar();
	void RefreshConfig();
	void GetKey(KeyEventArgs e, KeyEventHandler KeyEventFn);
protected:
	int heightPtr;
	VScrollBar vScrollBar;
public:
	TextBox();
	~TextBox();
	virtual void SetText(char* content);
	virtual void SetText(uint16_t*);
	virtual int GetTextSize();
	virtual bool SetTextSize(int size);
	void SetLocation(GDI::Point location);
	void SetLocation(int x, int y);
	void SetSize(int width, int height);
	void EnableScrollBar(bool value);
	bool IsEnabledScrollBar();
	void EnableMultiLine(bool value);
	bool IsEnabledMultiLine();
	void EnableBoder(bool value);
	bool IsEnabledBoder();
	Color BoderColor;
protected:
	virtual void OnKeyDown(KeyEventArgs e);
	virtual void OnKeyPress(KeyEventArgs e);

	virtual void OnPaint(PaintEventArgs e);
	virtual void OnPaintBackground(PaintEventArgs pevent);

	// override control
	virtual void OnLostFocus(EventArgs e);
	virtual void OnAppropFocus(EventArgs e);

	virtual bool IsFocusFistLine();
	virtual bool IsFocusEndLine();
private:
	// override from callback
	void OnControlTimer(EventArgs e);
	// handle timer event to blink pointer
	void OnTimerPointer(EventArgs e);
};

