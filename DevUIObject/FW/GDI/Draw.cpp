#include "Draw.h"
#include "Unicode.h"

extern GUI_EMOJI current_emoji_font;
int DEBUG_GDI = 0;
namespace GDI
{
	const color_t* Draw::Drawlayer = &g_layer1[0][0];
	const GUI_EMOJI* Draw::EmojiFont = &current_emoji_font;
	const Image* Draw::BackgroundImage = &bmBGR;
	Draw::Draw()
	{
		
	}


	Draw::~Draw()
	{
	}

	void Draw::DrawPicture(Image img, int x, int y)
	{
		guiDrawPicture(img, (color_t*)Drawlayer, x, y);
		if(DEBUG_GDI)
		{
			OnShowScreen(GDI::Rectangle(x, y, img.x, img.y));
		}
	}

	void Draw::DrawPicture(Image img, int x, int y, int x1, int y1, int x2, int y2)
	{
		guiDrawPictureCustom(img, (color_t*)Drawlayer, x, y, x1, y1, x2, y2);
		if(DEBUG_GDI)
		{
			OnShowScreen(GDI::Rectangle::FromLocation(x1, y1, x2, y2));
		}
	}

	void Draw::DrawPicture(Image img, int x, int y, Rectangle baud)
	{
		DrawPicture(img, x, y, baud.X, baud.Y, baud.X + baud.Width - 1, baud.Y + baud.Height - 1);
	}

	void Draw::DrawPicture(Image img, Point location)
	{
		DrawPicture(img, location.x, location.y);
	}

	void Draw::DrawRect(Rectangle rect, Color color)
	{
		gui_DrawRectangle((color_t*)Drawlayer, color, rect.X, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height - 1);
		if(DEBUG_GDI)
		{
			OnShowScreen(rect);
		}
	}

	void Draw::DrawRectTransparent(Rectangle rect, Color color)
	{
		gui_DrawRecTransparent((color_t*)Drawlayer, color, rect.X, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height - 1);
		if(DEBUG_GDI)
		{
			OnShowScreen(rect);
		}
	}

	void Draw::DrawString(Point p, const char * text, Font font, Color color)
	{
		DrawString(p.x, p.y, text, font, color);
	}

	void Draw::DrawString(int x, int y, const char * text, Font font, Color color)
	{
		guiChars((char*)text, font, color, (color_t*)Drawlayer, FONT_TYPE_8BIT, x, y);
	}

	void Draw::DrawString(Point p, const uint16_t * text, Font font, Color color)
	{
		DrawString(p.x, p.y, text, font, color);
	}

	void Draw::DrawString(int x, int y, const uint16_t * text, Font font, Color color)
	{
		guiUCS2sLength((uint16_t*)text, unilen((uint16_t*)text), font, color, (color_t*)Drawlayer, x, y);
	}

	void Draw::DrawString(Rectangle baud, const char * text, Font font, Color color)
	{
		uint16_t lenText = strlen(text);
		uint16_t* buff = new uint16_t[lenText + 1];
		getUniFromStr(buff, (char*)text);

		DrawString(baud, buff, font, color);
		delete(buff);
	}

	void Draw::DrawString(Rectangle baud, const uint16_t * text, Font font, Color color)
	{
		guiUCS2Auto((uint16_t*)text, font, color, (color_t*)Drawlayer, baud.X, baud.Y, baud.X + baud.Width, baud.Y + baud.Height);
	}

	void Draw::DrawStringFixedLen(int x, int y, const uint16_t * text, int numsCharacter, Font font, Color color)
	{
		guiUCS2sLength((uint16_t *)text, numsCharacter, font, color, (color_t*)Drawlayer, x, y);
	}

	int Draw::PixelLen(uint16_t * text, Font font)
	{
		return (int) getPixelLength(text, font);
	}

	void Draw::OnShowScreen(Rectangle rect)
	{
		guiLayerDisplay((color_t*)Drawlayer, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
	}
}

