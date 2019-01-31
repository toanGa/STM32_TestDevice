#include "TextBox.h"

#include "Unicode.h"
#include "newDrawText.h"
#include "TextInfo.h"
#include "assert.h"
#include "uart_console.h"
#include "Timer.h"
#include <cstdio>

// tmp define
#define NtGetTickCount Clock_getTicks

TextBox::TextBox()
{
	Width = 222;
	Height = 29;
	this->alignLeft = this->Location.x + 5;
	this->alignRight = this->Location.x + this->Width - 9;
	enable_border = true;

	BoderColor = 0x002c2c2c;
	BackColor = 0x00383838;
	ForeColor = GUI_WHITE;
	this->FontText = GUI_FontEurostile16;
	this->heightPtr = this->FontText.height;
	this->distanceText = (29 - this->heightPtr) / 2;

	maxLenText = 32;
	this->content = (uint16_t *)calloc(maxLenText + 2, sizeof(uint16_t));

	this->isMultiLine = 1;
	this->TextType = TextTypeNormal;
	this->content_len = 0;
	this->contentIndex = -1;
	this->enableScrollBar = true;
	this->lockPointer = 0;
	this->maxLineDisplay = 1;

	this->numberLineOfContent = 1;
	this->lineStartOfContent = 0;

	this->indexStart = 0;
	this->linePoiter = 0;
	this->enableBlinking = 0;

	UpdateLocateScrollBar();
}

TextBox::~TextBox()
{
	assert(this->content != NULL);
	free(this->content);
}

void TextBox::SetText(char *content)
{
	int len = strlen(content);
	uint16_t *buffer = (uint16_t *)calloc(len, sizeof(uint16_t));

	getUniFromStr(buffer, content);
	SetText(buffer);

	free(buffer);
}

void TextBox::SetText(uint16_t *text)
{
	Reset();

	AddText(text);

	this->DisplayRectangle = GDI::Rectangle(this->Location, this->Width, this->Height);
	// Update UI
	this->Update();
}

uint16_t * TextBox::Text()
{
	return this->content;
}

int TextBox::GetTextSize()
{
	return maxLenText;
}

bool TextBox::SetTextSize(int size)
{
	maxLenText = size;
	if(this->content != NULL)
	{
		free(this->content);
		this->content = (uint16_t *)calloc(maxLenText + 1, sizeof(uint16_t));
		if(this->content == NULL)
		{
			return false;
		}
	}

	return true;
}

void TextBox::SetLocation(GDI::Point location)
{
	this->Location = location;
	RefreshConfig();
}

void TextBox::SetLocation(int x, int y)
{
	SetLocation(GDI::Point(x, y));
}

void TextBox::SetSize(int width, int height)
{
	this->Width = width;
	this->Height = height;

	RefreshConfig();
}

void TextBox::EnableScrollBar(bool value)
{
	this->enableScrollBar = value;
}

bool TextBox::IsEnabledScrollBar()
{
	return enableScrollBar;
}

void TextBox::EnableMultiLine(bool value)
{
	this->isMultiLine = value;

	if (this->isMultiLine)
	{
		// Update multiline
		int numsLine = this->Height / this->FontText.height;
		if (numsLine)
		{
			this->maxLineDisplay = numsLine;
		}
	}
	else
	{
		this->maxLineDisplay = 1;
	}
}

bool TextBox::IsEnabledMultiLine()
{
	return this->isMultiLine;
}

void TextBox::EnableBoder(bool value)
{
	this->enable_border = value;
}

bool TextBox::IsEnabledBoder()
{
	return this->enable_border;
}

void TextBox::OnKeyDown(KeyEventArgs e)
{
	GetKey(e, KeyDown);
}

void TextBox::OnKeyPress(KeyEventArgs e)
{
	GetKey(e, KeyPress);
}

void TextBox::OnPaint(PaintEventArgs e)
{
	switch (e.PaintOption)
	{
	case PaintEventArgs::PaintDrawControl:
	{
		uint8_t lineDisplay;
		uint8_t lineContain;
		uint16_t i;
		uint16_t realIdx;
		///checkChangedObject(&box, &textInfoBuffer);

		lineDisplay = this->maxLineDisplay;
		lineContain = this->numberLineOfContent - this->lineStartOfContent;

		if (lineContain < lineDisplay)
		{
			lineDisplay = lineContain;
		}
		for (i = 0; i < lineDisplay; ++i)
		{
			realIdx = getRealStartIndexOfLine(&textInfoBuffer, this->lineStartOfContent + i, this->content);
			//guiUCS2sLength(this->content + realIdx, getLengthLine(&textInfoBuffer, this->lineStartOfContent + i, this->content), this->FontText, this->colorText, layer, this->alignLeft, Location.y + this->distanceText + i * this->FontText.height);
			GDI::Draw::DrawStringFixedLen(this->alignLeft, Location.y + this->distanceText + i * this->FontText.height, this->content + realIdx, getLengthLine(&textInfoBuffer, this->lineStartOfContent + i, this->content), this->FontText, this->ForeColor);
		}

		//draw pointer if highlight content
		if (this->IsFocusing() && !this->lockPointer)
		{
			//		CheckIndexPointer();
			//		GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(xPoint, yPoint, xPoint, yPoint + this->heightPtr), ForeColor);
			///*		gui_DrawRectangle(layer, this->colorText,
			//			xPoint, yPoint, xPoint, yPoint + this->heightPtr)*/;
			//		this->enableBlinking = 0;

			//DrawPtr();

			if (this->enableBlinking && this->IsFocusing())
			{
				CheckIndexPointer();
				//gui_DrawRectangle(layer, GUI_WHITE,
				//	xPoint, yPoint, xPoint, yPoint + this->heightPtr);
				GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(xPoint, yPoint, xPoint, yPoint + this->heightPtr), GUI_WHITE);
			}
		}

		if (this->vScrollBar.GetTotal() > 1 && this->isMultiLine && this->enableScrollBar)
		{
			//this->scrollBar.draw(this->scrollBar, layer);
			PaintEventArgs pScroll;
			pScroll.PaintOption = PaintEventArgs::PaintDrawControl;
			this->vScrollBar.OnPaintBackground(pScroll);
			this->vScrollBar.OnPaint(pScroll);
		}
	}
	break;
	case PaintEventArgs::PaintDrawPartControl:
	{
		if (DisplayRectangle.Width == 1)
		{
			DrawPtr();
		}
		else
		{
			PaintEventArgs pFull;
			pFull.PaintOption = PaintEventArgs::PaintDrawControl;
			OnPaint(pFull);
		}
	}
	break;
	}
}

void TextBox::OnPaintBackground(PaintEventArgs e)
{
	switch (e.PaintOption)
	{
	case PaintEventArgs::PaintDrawControl:
	{
		if (this->enable_border) //enable border
		{
			DrawWrap();
		}
		else //disable border
		{
			// not draw background, father control is draw
			//DrawBgr();
		}
	}
	break;
	case PaintEventArgs::PaintDrawPartControl:
	{
		if (DisplayRectangle.Width == 1)
		{
			// this is update pointer,
			// not update background
		}
		else
		{
			if (this->enable_border) //enable border
			{
				DrawWrap();
			}
			else //disable border
			{
				// not draw background, father control is draw
				//DrawBgr();
			}
		}
	}
	break;
	}
}

void TextBox::OnLostFocus(EventArgs e)
{
	this->EnableControlTimer(false);
	Control::OnLostFocus(e);
}

void TextBox::OnAppropFocus(EventArgs e)
{
	this->EnableControlTimer(true);
	Control::OnAppropFocus(e);
}

void TextBox::OnControlTimer(EventArgs e)
{
	OnTimerPointer(e);
}

void TextBox::OnTimerPointer(EventArgs e)
{
	this->DisplayRectangle = Rectangle::FromLocation(xPoint, yPoint, xPoint, yPoint + this->heightPtr);
	this->Update();
}

bool TextBox::IsFocusFistLine()
{
	return (this->GetLineActive() == 0);
}

bool TextBox::IsFocusEndLine()
{
	return this->IsPointingEndLine();
}

// private method
void TextBox::Up()
{
	if (!this->isMultiLine)
	{
		keyboard.setInvolkNewkey();
		return;
	}
	uint16_t idxOldLine;
	int16_t shift;
	uint8_t enableProcess = 0;

	///checkChangedObject(box, &textInfoBuffer);
	idxOldLine = this->lineStartOfContent + this->linePoiter;
	//new
	if (this->linePoiter > 0)
	{
		this->linePoiter--;
		enableProcess = 1;
	}
	else
	{
		if (this->lineStartOfContent > 0)
		{
			this->lineStartOfContent--;
			enableProcess = 1;
		}
	}
	//end new

	if (enableProcess)
	{

		if (idxOldLine + 1 > textInfoBuffer.numsLine)
		{
			SOS_DEBUG("ERROR when when compare current line index\r\n");
			// find textinfo again
		}
		shift = this->contentIndex - getRealStartIndexOfLine(&textInfoBuffer, idxOldLine, this->content) + 1; // shift cannot lesser than 0
		if (shift < 0)
		{
			SOS_DEBUG("ERROR when detect shift < 0");
			shift = 0;
		}

		this->contentIndex = textInfoBuffer.idxLine[this->lineStartOfContent + this->linePoiter];
		uint16_t lenNew = getLengthLine(&textInfoBuffer, this->lineStartOfContent + this->linePoiter, this->content);
		if (shift)
		{
			if (shift > lenNew - 1)
			{
				if (lenNew >= 1)
				{
					shift = lenNew - 1;
				}
				else
				{
					shift = 0;
				}
			}
		}
		if (this->contentIndex > 0)
		{
			this->contentIndex += shift;

			if (this->contentIndex != -1 && // toan add
				isEmojiCode(this->content, this->contentIndex))
			{
				++this->contentIndex;
				SOS_DEBUG("UPDATE line start\r\n");
			} // end of add
		}
		else
		{
			if (idxOldLine == 1)
			{
				this->contentIndex = -1;
			}
		}
		UpdateIndex();
	}

	this->enableBlinking = 1;
	keyboard.setInvolkNewkey();
}
void TextBox::UpToFistLine()
{
	if (this->numberLineOfContent <= 1)
	{
		return;
	}

	while (this->GetLineActive() != 0)
	{
		this->Up();
	}
}
void TextBox::Down()
{
	if (!this->isMultiLine)
	{
		keyboard.setInvolkNewkey();
		return;
	}
	int16_t shift;
	uint8_t enableProcess = 0;
	uint16_t idxOldLine;

	///checkChangedObject(box, &textInfoBuffer);

	idxOldLine = this->lineStartOfContent + this->linePoiter;
	if (this->linePoiter < this->maxLineDisplay - 1)
	{
		if (this->linePoiter + this->lineStartOfContent + 1 < this->numberLineOfContent)
		{
			this->linePoiter++;
			enableProcess = 1;
		}
	}
	else
	{
		if (this->linePoiter + this->lineStartOfContent + 1 < this->numberLineOfContent)
		{
			this->lineStartOfContent++;
			enableProcess = 1;
		}
	}

	if (enableProcess)
	{

		if (idxOldLine + 1 > textInfoBuffer.numsLine)
		{
			SOS_DEBUG("ERROR when when compare current line index\r\n");
			// find textinfo again
		}
		shift = this->contentIndex - getRealStartIndexOfLine(&textInfoBuffer, idxOldLine, this->content); // shift cannot lesser than 0
		if (shift < 0)
		{
			SOS_DEBUG("ERROR when detect shift < 0");
			shift = 0;
		}

		this->contentIndex = textInfoBuffer.idxLine[this->lineStartOfContent + this->linePoiter];
		uint16_t lenNew = getLengthLine(&textInfoBuffer, this->lineStartOfContent + this->linePoiter, this->content);
		if (shift)
		{
			if (shift > lenNew - 1)
			{
				if (lenNew >= 1)
				{
					shift = lenNew - 1;
				}
				else
				{
					shift = 0;
				}
			}
		}
		this->contentIndex += shift;

		//////////////
		if (this->contentIndex != -1 && // toan add
			isEmojiCode(this->content, this->contentIndex))
		{
			++this->contentIndex;
			SOS_DEBUG("UPDATE line start\r\n");
		} // end of add

		UpdateIndex();
	}

	this->enableBlinking = 1;
	keyboard.setInvolkNewkey();
}
void TextBox::DownToEndLine()
{
	if (this->numberLineOfContent <= 1)
	{
		return;
	}

	while (!this->IsPointingEndLine())
	{
		this->Down();
	}
}
void TextBox::LeftPress()
{
	keyboard.setInvolkNewkey();
	///checkChangedObject(box, &textInfoBuffer);

	if (this->contentIndex > -1)
	{
		if (isEmojiCode(this->content,
						this->contentIndex - 1))
		{
			this->contentIndex -= 2;
		}
		else
		{
			this->contentIndex--;
		}

		uint16_t linePtrOld = this->linePoiter + this->lineStartOfContent;

		uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
		if (linePtr < this->lineStartOfContent)
		{
			this->lineStartOfContent -= 1;
			this->linePoiter = 0;
		}
		else if (linePtr < linePtrOld)
		{
			//if (this->lineStartOfContent)
			//{
			//  this->lineStartOfContent--;
			//}
			if (this->linePoiter > 0)
			{
				this->linePoiter--;
			}
		}

		if (TextTypeNormal == this->TextType)
		{
			keyboard.pressTypeChangeAuto(&this->content[0], &this->contentIndex);
		}
		else if (TextTypeName == this->TextType)
		{
			keyboard.pressTypeNameChangeAuto(&this->content[0], &this->contentIndex);
		}
		else
		{
		}

		UpdateIndex();
	}
	this->enableBlinking = 1;
}
void TextBox::RightPress()
{
	keyboard.setInvolkNewkey();
	///checkChangedObject(box, &textInfoBuffer);
	if (this->contentIndex < (int16_t)(
								 unilen(&this->content[0]) - 1))
	{
		uint16_t linePtrOld = this->linePoiter + this->lineStartOfContent;
		uint16_t linePtrNew;
		if (isEmojiCode(this->content,
						this->contentIndex + 1))
		{
			this->contentIndex += 2;
		}
		else
		{
			this->contentIndex++;
		}
		linePtrNew = getLineCurr(&textInfoBuffer, this->contentIndex);

		if (linePtrNew != linePtrOld)
		{
			// check change page
			if (this->linePoiter == this->maxLineDisplay - 1)
			{
				if (this->linePoiter + this->lineStartOfContent + 1 < this->numberLineOfContent)
				{
					this->lineStartOfContent++;
				}
			}
			else
			{
				// just chage line
				this->linePoiter++;
			}
		}
		else
		{
			// normal case
		}

		if (TextTypeNormal == this->TextType)
		{
			keyboard.pressTypeChangeAuto(&this->content[0],
										 &this->contentIndex);
		}
		else if (TextTypeName == this->TextType)
		{
			keyboard.pressTypeNameChangeAuto(&this->content[0], &this->contentIndex);
		}
		else
		{
		}

		UpdateIndex();
	}
	this->enableBlinking = 1;
}

void TextBox::AddKeyboardChar(uint8_t keyChar)
{
	uint8_t isAddNewKey = 0;
	uint16_t lenInstance = unilen(this->content);
	if (lenInstance >= this->maxLenText + 1)
	{
		return;
	}

	if (lenInstance < this->maxLenText)
	{
		keyboard.getMsgContent(&this->content[0], this->maxLenText, keyChar,
							    &this->contentIndex, this->TextType);
		mTimeClock = NtGetTickCount();
	}
	else
	{
		if ((keyboard.PressType >= keyboard.PRESS_TYPE_VI_LOWERCASE && keyboard.PressType <= keyboard.PRESS_TYPE_VI_UPPERCASE_ALL) && keyChar == '*')
		{
		}
		else
		{
			if (NtGetTickCount() - mTimeClock > 1000 || mOldKey != keyChar)
			{
				mTimeClock -= 1000; // prevent press end of character
				return;
			}
		}

		//		tmpBox = *this;
		//		isAddNewKey = keyboard.getMsgContent(&this->content[0], this->maxLenText + 1, keyChar,
		//			&keyboard.PressType, &this->contentIndex, this->TextType);
		//		if (isAddNewKey)
		//		{
		//			*this = tmpBox;
		//			return;
		//		}

		uint16_t *bufferText = (uint16_t *)calloc(this->maxLenText + 1, sizeof(uint16_t));
		unicpy(bufferText, this->content);
		int16_t oldPresType = keyboard.PressType;
		int16_t oldContenIndex = this->contentIndex;

		isAddNewKey = keyboard.getMsgContent(&this->content[0], this->maxLenText + 1, keyChar,
											 &this->contentIndex, this->TextType);
		if (isAddNewKey)
		{
			////*this = tmpBox;
			unicpy(this->content, bufferText);
			keyboard.PressType = oldPresType;
			this->contentIndex = oldContenIndex;
			free(bufferText);
			return;
		}
		else
		{
			free(bufferText);
		}

		mTimeClock = NtGetTickCount();
	}

	getTextInfo(&textInfoBuffer, this->content, this->FontText, this->alignLeft, this->alignRight);
	this->numberLineOfContent = textInfoBuffer.numsLine;

	uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
	if (linePtr > this->lineStartOfContent)
	{
		if (linePtr - this->lineStartOfContent + 1 > this->maxLineDisplay)
		{
			this->lineStartOfContent += 1;
			this->linePoiter = this->maxLineDisplay - 1;
		}
	}

	this->enableBlinking = 1;
	UpdateIndex();
	mOldKey = keyChar;
}

void TextBox::ClearChar()
{
	keyboard.setInvolkNewkey();
	uint16_t Charactor = this->content[this->contentIndex];
	if (this->content[0])
	{
		if (this->contentIndex > 0)
		{
			if (isEmojiCode(this->content, this->contentIndex - 1))
			{
				keyboard.clearUCS2Content(&this->content[0],
										  &this->contentIndex);
				keyboard.clearUCS2Content(&this->content[0],
										  &this->contentIndex);
			}
			else
			{
				keyboard.clearUCS2Content(&this->content[0],
										  &this->contentIndex);
			}
		}
		else
		{
			keyboard.clearUCS2Content(&this->content[0],
									  &this->contentIndex);
		}
		// end of find text info
		// update text info
		uint16_t linePtrOld = this->linePoiter + this->lineStartOfContent;

		getTextInfo(&textInfoBuffer, this->content, this->FontText, this->alignLeft, this->alignRight);
		this->numberLineOfContent = textInfoBuffer.numsLine;

		uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
		if (linePtr < this->lineStartOfContent)
		{
			this->lineStartOfContent -= 1;
			this->linePoiter = 0;
		}
		else if (linePtr < linePtrOld)
		{
			if (this->lineStartOfContent)
			{
				this->lineStartOfContent--;
				this->linePoiter = linePtr - this->lineStartOfContent;
			}
		}

		if (TextTypeNormal == this->TextType)
		{
			keyboard.pressTypeChangeAuto(&this->content[0],
										 &this->contentIndex);
		}
		else if (TextTypeName == this->TextType)
		{
			keyboard.pressTypeNameChangeAuto(&this->content[0], &this->contentIndex);
		}
		else
		{
		}

		if (FindUppercaseCharactor(&Charactor) && (this->TextType == TextTypeName || this->TextType == TextTypeNormal) && keyboard.PressType != keyboard.PRESS_TYPES_NUMBER_ONLY && keyboard.PressType != keyboard.PRESS_TYPE_EN_UPPERCASE_ALL && keyboard.PressType != keyboard.PRESS_TYPE_VI_UPPERCASE_ALL)
		{
			keyboard.reset_typePress();
		}

		UpdateIndex();
	}
	this->enableBlinking = 1;
}
void TextBox::ForceClearChar()
{
	keyboard.setInvolkNewkey();
	uint16_t Charactor = this->content[this->contentIndex];
	if (this->content[0])
	{
		if (this->contentIndex > 0)
		{
			if (isEmojiCode(this->content, this->contentIndex - 1)
				/*|| (10 == this->content[1] && 10 == this->content[0])*/)
			{
				keyboard.forceClearUnicode(&this->content[0],
										   &this->contentIndex);
				keyboard.forceClearUnicode(&this->content[0],
										   &this->contentIndex);
			}
			else
			{
				keyboard.forceClearUnicode(&this->content[0],
										   &this->contentIndex);
			}
		}
		else
		{
			keyboard.forceClearUnicode(&this->content[0],
									   &this->contentIndex);
		}
		// end of find text info
		// update text info
		uint16_t linePtrOld = this->linePoiter + this->lineStartOfContent;

		getTextInfo(&textInfoBuffer, this->content, this->FontText, this->alignLeft, this->alignRight);
		this->numberLineOfContent = textInfoBuffer.numsLine;

		uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
		if (linePtr < this->lineStartOfContent)
		{
			this->lineStartOfContent -= 1;
			this->linePoiter = 0;
		}
		else if (linePtr < linePtrOld)
		{
			if (this->lineStartOfContent)
			{
				this->lineStartOfContent--;
				this->linePoiter = linePtr - this->lineStartOfContent;
			}
		}

		if (TextTypeNormal == this->TextType)
		{
			keyboard.pressTypeChangeAuto(&this->content[0],
										 &this->contentIndex);
		}
		else if (TextTypeName == this->TextType)
		{
			keyboard.pressTypeNameChangeAuto(&this->content[0], &this->contentIndex);
		}
		else
		{
		}

		if (FindUppercaseCharactor(&Charactor) && (this->TextType == TextTypeName || this->TextType == TextTypeNormal) && keyboard.PressType != keyboard.PRESS_TYPES_NUMBER_ONLY && keyboard.PressType != keyboard.PRESS_TYPE_EN_UPPERCASE_ALL && keyboard.PressType != keyboard.PRESS_TYPE_VI_UPPERCASE_ALL)
		{
			keyboard.reset_typePress();
		}

		UpdateIndex();
	}
	this->enableBlinking = 1;
}

void TextBox::AddChar(int16_t keyChar)
{
	uint8_t isAddNewKey = 0;
	uint16_t lenInstance = unilen(this->content);
	if (lenInstance >= this->maxLenText + 1)
	{
		return;
	}

	if (lenInstance < this->maxLenText)
	{
		keyboard.getMsgContent(&this->content[0], this->maxLenText, keyChar,
							   &this->contentIndex, this->TextType);
		mTimeClock = NtGetTickCount();
	}
	else
	{
		if ((keyboard.PressType >= keyboard.PRESS_TYPE_VI_LOWERCASE && keyboard.PressType <= keyboard.PRESS_TYPE_VI_UPPERCASE_ALL) && keyChar == '*')
		{
		}
		else
		{
			if (NtGetTickCount() - mTimeClock > 1000 || mOldKey != keyChar)
			{
				mTimeClock -= 1000; // prevent press end of character
				return;
			}
		}

		////tmpBox = *this;
		uint16_t *bufferText = (uint16_t *)calloc(this->maxLenText + 1, sizeof(uint16_t));
		unicpy(bufferText, this->content);
		int16_t oldPresType = keyboard.PressType;
		int16_t oldContenIndex = this->contentIndex;

		isAddNewKey = keyboard.getMsgContent(&this->content[0], this->maxLenText + 1, keyChar,
											 &this->contentIndex, this->TextType);
		if (isAddNewKey)
		{
			////*this = tmpBox;
			unicpy(this->content, bufferText);
			keyboard.PressType = oldPresType;
			this->contentIndex = oldContenIndex;
			free(bufferText);
			return;
		}
		else
		{
			free(bufferText);
		}

		mTimeClock = NtGetTickCount();
	}

	getTextInfo(&textInfoBuffer, this->content, this->FontText, this->alignLeft, this->alignRight);
	this->numberLineOfContent = textInfoBuffer.numsLine;

	uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
	if (linePtr > this->lineStartOfContent)
	{
		if (linePtr - this->lineStartOfContent + 1 > this->maxLineDisplay)
		{
			this->lineStartOfContent += 1;
			this->linePoiter = this->maxLineDisplay - 1;
		}
	}

	this->enableBlinking = 1;
	UpdateIndex();
	mOldKey = keyChar;
}
void TextBox::AddText(uint16_t *string)
{
	uint16_t lenAdd = unilen(string);
	static uint16_t buff[MAX_TEXT];

	if (unilen(this->content) + lenAdd > MAX_TEXT - 1)
	{
		return;
	}
	unicpy(buff, this->content + this->contentIndex + 1);

	unicpy(this->content + this->contentIndex + 1, string);
	unicat(this->content, buff);

	this->contentIndex += lenAdd;

	getTextInfo(&textInfoBuffer, this->content, this->FontText, this->alignLeft, this->alignRight);
	this->numberLineOfContent = textInfoBuffer.numsLine;

	uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
	if (linePtr > this->lineStartOfContent)
	{
		while (linePtr - this->lineStartOfContent > this->maxLineDisplay)
		{
			this->lineStartOfContent += 1;
		}
		this->linePoiter = this->maxLineDisplay - 1;
	}

	this->enableBlinking = 1;

	UpdateIndex();
}

/*
* re check to calc true index pointer
*/
void TextBox::CheckIndexPointer()
{
	const int WIDTH = abs(this->alignLeft - this->alignRight) + 1;

	int currWidth = 0;
	uint16_t currUni = 0;
	GUI_CHARINFO *fontInfo;
	uint16_t linePtr = getLineCurr(&textInfoBuffer, this->contentIndex);
	uint8_t spanLine = linePtr - this->lineStartOfContent;
	uint16_t i = getRealStartIndexOfLine(&textInfoBuffer, linePtr, this->content);

	xPoint = this->alignLeft;
	if (this->isMultiLine)
	{
		yPoint = Location.y + this->distanceText + spanLine * this->FontText.height;
	}
	else
	{
		yPoint = Location.y + this->distanceText;
	}

	while (*(this->content + i) != 0 && i <= this->contentIndex)
	{

		currUni = *(this->content + i);
		if (currUni == '\n')
		{
			break;
		}
		else if (0x1B == currUni || // esc
				 0x1A == currUni || // substitute
				 0x0D == currUni || // '\r'
				 '\t' == currUni)   // '\t'
		{
			// do nothing
			if ('\t' == currUni)
			{
				charactorInformation(' ', this->FontText, &fontInfo);
				currWidth += fontInfo->width * 4;
			}
		}
		else if (isEmojiCode(this->content, i))
		{
			currWidth += GDI::Draw::EmojiFont->x + EXTRA_EMOJI * 2;
		}
		else
		{
			charactorInformation(currUni, this->FontText, &fontInfo);
			currWidth += fontInfo->width;
		}
		if (isEmojiCode(this->content, i))
		{
			i += 2;
		}
		else
		{
			i += 1;
		}
	}

	xPoint += currWidth;
}

void TextBox::UpdateLocateScrollBar()
{
	uint8_t widthBar = 3;
	uint16_t xBar = this->Location.x + this->Width - widthBar - 1;
	vScrollBar.Location = GDI::Point(xBar, this->Location.y + 1);
	vScrollBar.Width = widthBar;
	vScrollBar.Height = this->Height - 2;
}

void TextBox::RefreshConfig()
{
	this->alignLeft = this->Location.x + 5;
	this->alignRight = this->Location.x + this->Width - 9;
	this->heightPtr = this->FontText.height;
	this->distanceText = (29 - this->heightPtr) / 2;
	UpdateLocateScrollBar();
}

void TextBox::GetKey(KeyEventArgs e, KeyEventHandler KeyEventFn)
{
	// split event up dow, left right, right press(clear), and key to get character
	switch (e.KeyChar)
	{
	case KEYUP:
		if (this->IsFocusFistLine())
		{
			this->FocusNextControl(false);
			return;
		}
		else
		{
			this->Up();
			goto update_ui;
		}
		
	case KEYDOWN:
		if (this->IsFocusFistLine())
		{
			this->FocusNextControl(true);
			return;
		}
		else
		{
			this->Down();
			goto update_ui;
		}
		
	case KEYLEFT:
		this->LeftPress();
		goto update_ui;
	case KEYRIGHT:
		this->RightPress();
		goto update_ui;
	case KEYRIGHTSELECT:
		this->ClearChar();
		goto update_ui;
	default:
		break;
	}

	// filter event
	switch (e.KeyChar)
	{
	case KEY_0:
	case KEY_1:
	case KEY_2:
	case KEY_3:
	case KEY_4:
	case KEY_5:
	case KEY_6:
	case KEY_7:
	case KEY_8:
	case KEY_9:
	case KEY_STAR:
		this->AddKeyboardChar(e.KeyChar);

		if (TextChanged != NULL)
		{
			(this->*TextChanged)(this, e);
		}
		break;
	case KEY_HASHTAG:
		if(TextTypeNumber == this->TextType)
		{
			this->AddKeyboardChar(e.KeyChar);

			if (TextChanged != NULL)
			{
				(this->*TextChanged)(this, e);
			}
		}
		else
		{
			keyboard.changePressType(this->content, &this->contentIndex);
		}
	default:
		break;
	}

update_ui:
	this->DisplayRectangle = GDI::Rectangle(Location, Width, Height);
	this->Update();

	if (KeyEventFn != NULL)
	{
		(this->*KeyEventFn)(this, e);
	}
}

void TextBox::DrawPtr()
{
	if (this->lockPointer)
	{
		return;
	}

	///checkChangedObject(box, &textInfoBuffer);
	CheckIndexPointer();
	if (this->enableBlinking)
	{
		//gui_DrawRectangle(layer, GUI_WHITE,
		//	xPoint, yPoint, xPoint, yPoint + this->heightPtr);
		GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(xPoint, yPoint, xPoint, yPoint + this->heightPtr), GUI_WHITE);
	}
	else
	{
		if (this->enable_border)
		{
			GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(xPoint, yPoint, xPoint, yPoint + this->heightPtr), BackColor);
			//gui_DrawRectangle(layer, this->colorBackground,
			//	xPoint, yPoint, xPoint, yPoint + this->heightPtr);
		}
		else
		{
			// draw bmBGR
			// TODO: redraw background on Control

			//guiDrawPictureCustom(bmBGR, layer, 0, 0,
			//	xPoint, yPoint,
			//	xPoint, yPoint + this->heightPtr);
		}
	}
	this->enableBlinking = !this->enableBlinking;
}

void TextBox::DrawWrap()
{
	GDI::Draw::DrawRect(GDI::Rectangle(Location, 1, 1), 0x002c2c2c);

	//gui_DrawRectangle(layer, 0x002c2c2c,
	//	box.x, box.y,
	//	box.x, box.y);

	GDI::Draw::DrawRect(GDI::Rectangle(GDI::Point(Location.x + Width - 1, Location.y), 1, 1), 0x002c2c2c);
	//gui_DrawRectangle(layer, 0x002c2c2c,
	//	box.x + box.width - 1, box.y,
	//	box.x + box.width - 1, box.y);

	GDI::Draw::DrawRect(GDI::Rectangle(GDI::Point(Location.x, Location.y + Height - 1), 1, 1), 0x002c2c2c);
	//gui_DrawRectangle(layer, 0x002c2c2c,
	//	box.x, box.y + box.height - 1,
	//	box.x, box.y + box.height - 1);

	GDI::Draw::DrawRect(GDI::Rectangle(GDI::Point(Location.x + Width - 1, Location.y + Height - 1), 1, 1), 0x002c2c2c);
	//gui_DrawRectangle(layer, 0x002c2c2c,
	//	box.x + box.width - 1, box.y + box.height - 1,
	//	box.x + box.width - 1, box.y + box.height - 1);

	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + 1, Location.y,
													 Location.x + Width - 2, Location.y),
						BoderColor);
	//gui_DrawRectangle(layer, box.colorWrap,
	//	box.x + 1, box.y,
	//	box.x + box.width - 2, box.y);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + 1, Location.y + Height - 1,
													 Location.x + Width - 2, Location.y + Height - 1),
						BoderColor);

	//GDI::Draw::DrawRect(layer, box.colorWrap,
	//	Location.x + 1, Location.y + Height - 1,
	//	Location.x + Width - 2, Location.y + Height - 1);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x, Location.y + 1,
													 Location.x, Location.y + Height - 2),
						BoderColor);
	//GDI::Draw::DrawRect(layer, box.colorWrap,
	//	Location.x, Location.y + 1,
	//	Location.x, Location.y + Height - 2);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + Width - 1, Location.y + 1,
													 Location.x + Width - 1, Location.y + Height - 2),
						BoderColor);
	//GDI::Draw::DrawRect(layer, box.colorWrap,
	//	Location.x + Width - 1, Location.y + 1,
	//	Location.x + Width - 1, Location.y + Height - 2);

	// draw background
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + 1, Location.y + 1,
													 Location.x + Width - 2, Location.y + Height - 2),
						BackColor);
	//GDI::Draw::DrawRect(layer, box.colorBackground,
	//	Location.x + 1, Location.y + 1,
	//	Location.x + Width - 2, Location.y + Height - 2);

	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + 1, Location.y + 1,
													 Location.x + 1, Location.y + 1),
						BackColor);
	//GDI::Draw::DrawRect(layer, 0x00434343,
	//	Location.x + 1, Location.y + 1,
	//	Location.x + 1, Location.y + 1);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + Width - 2, Location.y + 1,
													 Location.x + Width - 2, Location.y + 1),
						BackColor);
	//GDI::Draw::DrawRect(layer, 0x00434343,
	//	Location.x + Width - 2, Location.y + 1,
	//	Location.x + Width - 2, Location.y + 1);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + 1, Location.y + Height - 2,
													 Location.x + 1, Location.y + Height - 2),
						BackColor);
	//GDI::Draw::DrawRect(layer, 0x00434343,
	//	Location.x + 1, Location.y + Height - 2,
	//	Location.x + 1, Location.y + Height - 2);
	GDI::Draw::DrawRect(GDI::Rectangle::FromLocation(Location.x + Width - 2, Location.y + Height - 2,
													 Location.x + Width - 2, Location.y + Height - 2),
						BackColor);
	//GDI::Draw::DrawRect(layer, 0x00434343,
	//	Location.x + Width - 2, Location.y + Height - 2,
	//	Location.x + Width - 2, Location.y + Height - 2);
}
//void TextBox::DrawBackground(color_t* layer)
//{
//
//}

uint8_t TextBox::IsPointingEndLine()
{
	if (this->linePoiter + this->lineStartOfContent == this->numberLineOfContent - 1)
	{
		return 1;
	}
	if (0 == this->numberLineOfContent)
	{
		return 1;
	}
	return 0;
}
uint16_t TextBox::GetLineActive()
{
	return this->linePoiter + this->lineStartOfContent;
}

void TextBox::UpdateIndex()
{
	uint16_t idxLinePtr = getLineCurr(&textInfoBuffer, this->contentIndex);

	this->linePoiter = idxLinePtr - this->lineStartOfContent;

	/* This is a case of ASSERTION */
	if (this->linePoiter >= this->maxLineDisplay)
	{
		SOS_DEBUG("ASSERTION\r\n");
		if (this->maxLineDisplay >= 1)
		{
			this->linePoiter = this->maxLineDisplay - 1;
		}
		else
		{
			this->linePoiter = 0;
		}
		this->lineStartOfContent = idxLinePtr - this->linePoiter;
	}

	// TODO: review
	this->vScrollBar.SetRatio(this->lineStartOfContent + this->linePoiter, this->numberLineOfContent);

	if (idxLinePtr < this->lineStartOfContent)
	{
		SOS_DEBUG("OS exit\r\n");
	}
	if (this->numberLineOfContent != textInfoBuffer.numsLine)
	{
		SOS_DEBUG("OS exit\r\n");
	}
	if (this->linePoiter >= this->maxLineDisplay)
	{
		SOS_DEBUG("OS exit\r\n");
	}

	assert(idxLinePtr >= this->lineStartOfContent);
	assert(this->numberLineOfContent == textInfoBuffer.numsLine);
	/* Never assert here because prevent previous */
	assert(this->linePoiter < this->maxLineDisplay);
}
void TextBox::Reset()
{
	memset((uint16_t *)this->content, 0, sizeof(this->content));
	this->content_len = 0;
	this->contentIndex = -1;

	this->numberLineOfContent = 0;
	this->lineStartOfContent = 0;
	//    this->lineSelectOfContent = 0;

	this->indexStart = 0;
	this->linePoiter = 0;
	this->enableBlinking = 0;

	this->vScrollBar.SetActive(0);
	this->vScrollBar.SetTotal(0);
}
