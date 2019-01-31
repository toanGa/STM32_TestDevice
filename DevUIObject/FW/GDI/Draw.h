#pragma once
#include "GUI.h"
#include "Rectangle.h"
#include "Point.h"
#define Color uint32_t
#define Image GUI_BITMAP
#define Font  GUI_FONT

namespace GDI
{
	class Draw
	{
	private:
		static const color_t * Drawlayer;
	public:
		static const Image* BackgroundImage;
		static const GUI_EMOJI * EmojiFont;
		Draw();
		~Draw();
		static void DrawPicture(Image img, int x, int y);
		static void DrawPicture(Image img, int x, int y, int x1, int y1, int x2, int y2);
		static void DrawPicture(Image img, int x, int y, Rectangle baud);
		static void DrawPicture(Image img, Point location);
		static void DrawRect(Rectangle rect, Color color);
		static void DrawRectTransparent(Rectangle rect, Color color);
		static void DrawString(Point p, const char* text, Font font, Color color);
		static void DrawString(int x, int y, const char* text, Font font, Color color);
		static void DrawString(Point p, const uint16_t* text, Font font, Color color);
		static void DrawString(int x, int y, const uint16_t* text, Font font, Color color);
		static void DrawString(Rectangle baud, const char* text, Font font, Color color);
		static void DrawString(Rectangle baud, const uint16_t* text, Font font, Color color);
		static void DrawStringFixedLen( int x, int y, const uint16_t* text, int numsCharacter, Font font, Color color);
		static int  PixelLen(uint16_t* text, Font font);

		static void OnShowScreen(Rectangle rect);
	//protected:
	//	virtual void OnShowScreen(Rectangle rect);
	};

}

