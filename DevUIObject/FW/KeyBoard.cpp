#include "KeyBoard.h"
#include <string.h>
#include "ti/sysbios/knl/Clock.h"
#include "TextInfo.h"

const uint16_t KeyBoard::g_EngUppercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH] =
{
	{ 2, ' ', '0' },
{ 14, '.', ',', '?', '!', '\'', '\"', '1', '-', '(', ')', '@', '/', ':', '_' },
{ 4, 'A', 'B', 'C', '2' },
{ 4, 'D', 'E', 'F', '3' },
{ 4, 'G', 'H', 'I', '4' },
{ 4, 'J', 'K', 'L', '5' },
{ 4, 'M', 'N', 'O', '6' },
{ 5, 'P', 'Q', 'R', 'S', '7' },
{ 4, 'T', 'U', 'V', '8' },
{ 5, 'W', 'X', 'Y', 'Z', '9' },
{ 2, '*', '+' }, };
// lowercase
const uint16_t KeyBoard::g_EngLowerCase[KEY_MESS_NUMBER][KEY_MESS_LENGTH] =
{
	{ 2, ' ', '0' },
{ 14, '.', ',', '?', '!', '\'', '\"', '1', '-', '(', ')', '@', '/', ':', '_' },
{ 4, 'a', 'b', 'c', '2' },
{ 4, 'd', 'e', 'f', '3' },
{ 4, 'g', 'h', 'i', '4' },
{ 4, 'j', 'k', 'l', '5' },
{ 4, 'm', 'n', 'o', '6' },
{ 5, 'p', 'q', 'r', 's', '7' },
{ 4, 't', 'u', 'v', '8' },
{ 5, 'w', 'x', 'y', 'z', '9' },
{ 2, '*', '+' }, };

// viet nam lowercase
// Vietkey message
const uint16_t KeyBoard::g_VietLowercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH] =
{
	{ 2, ' ', '0' },
{ 14, '.', ',', '?', '!', '\'', '\"', '1', '-', '(', ')', '@', '/', ':', '_' },
{ 6, 'a', aw, aa, 'b', 'c', '2' },
{ 6, 'd', dd, 'e', ee, 'f', '3' },
{ 4, 'g', 'h', 'i', '4' },
{ 4, 'j', 'k', 'l', '5' },
{ 6, 'm', 'n', 'o', oo, ow, '6' },
{ 5, 'p', 'q', 'r', 's', '7' },
{ 5, 't', 'u', uw, 'v', '8' },
{ 5, 'w', 'x', 'y', 'z', '9' },
{ 1, '*' }, };

// viet nam lowercase
// Vietkey message
const uint16_t KeyBoard::g_VietUppercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH] =
{
	{ 2, ' ', '0' },
{ 14, '.', ',', '?', '!', '\'', '\"', '1', '-', '(', ')', '@', '/', ':', '_' },
{ 6, 'A', AW, AA, 'B', 'C', '2' },
{ 6, 'D', DD, 'E', EE, 'F', '3' },
{ 4, 'G', 'H', 'I', '4' },
{ 4, 'J', 'K', 'L', '5' },
{ 6, 'M', 'N', 'O', OO, OW, '6' },
{ 5, 'P', 'Q', 'R', 'S', '7' },
{ 5, 'T', 'U', UW, 'W', '8' },
{ 5, 'W', 'X', 'Y', 'Z', '9' },
{ 1, '*' }, };

//table vowel in vietnamses
const uint16_t KeyBoard::vowel[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR] =
{
	{ 'a', 0x00E1, 0x00E0, 0x1EA3, 0x00E3, 0x1EA1 },
{ 0x0103, 0x1EAF, 0x1EB1, 0x1EB3, 0x1EB5, 0x1EB7 },
{ 0x00E2, 0x1EA5, 0x1EA7, 0x1EA9, 0x1EAB, 0x1EAD },
{ 'e', 0x00E9, 0x00E8, 0x1EBB, 0x1EBD, 0x1EB9 },
{ 0x00EA, 0x1EBF, 0x1EC1, 0x1EC3, 0x1EC5, 0x1EC7 },
{ 'i', 0x00ED, 0x00EC, 0x1EC9, 0x0129, 0x1ECB },
{ 'o', 0x00F3, 0x00F2, 0x1ECF, 0x00F5, 0x1ECD },
{ 0x00F4, 0x1ED1, 0x1ED3, 0x1ED5, 0x1ED7, 0x1ED9 },
{ 0x01A1, 0x1EDB, 0x1EDD, 0x1EDF, 0x1EE1, 0x1EE3 },
{ 'u', 0x00FA, 0x00F9, 0x1EE7, 0x0169, 0x1EE5 },
{ 0x01B0, 0x1EE9, 0x1EEB, 0x1EED, 0x1EEF, 0x1EF1 },
{ 'y', 0x00FD, 0x1EF3, 0x1EF7, 0x1EF9, 0x1EF5 },
{ 'A', 0x00C1, 0x00C0, 0x1EA2, 0x00C3, 0x1EA0 },
{ 0x0102, 0x1EAE, 0x1EB0, 0x1EB2, 0x1EB4, 0x1EB6 },
{ 0x00C2, 0x1EA4, 0x1EA6, 0x1EA8, 0x1EAA, 0x1EAC },
{ 'E', 0x00C9, 0x00C8, 0x1EBA, 0x1EBC, 0x1EB8 },
{ 0x00CA, 0x1EBE, 0x1EC0, 0x1EC2, 0x1EC4, 0x1EC6 },
{ 'I', 0x00CD, 0x00CC, 0x1EC8, 0x0128, 0x1ECA },
{ 'O', 0x00D3, 0x00D2, 0x1ECE, 0x00D5, 0x1ECC },
{ 0x00D4, 0x1ED0, 0x1ED2, 0x1ED4, 0x1ED6, 0x1ED8 },
{ 0x01A0, 0x1EDA, 0x1EDC, 0x1EDE, 0x1EE0, 0x1EE2 },
{ 'U', 0x00DA, 0x00D9, 0x1EE6, 0x0168, 0x1EE4 },
{ 0x01AF, 0x1EE8, 0x1EEA, 0x1EEC, 0x1EEE, 0x1EF0 },
{ 'Y', 0x00DD, 0x1EF2, 0x1EF6, 0x1EF8, 0x1EF4 }, };


//table vowel in vietnamses
const uint16_t KeyBoard::vowel_low[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR] =
{
	{ 5, as, af, ar, ax, aj },
{ 5, aws, awf, awr, awx, awj },
{ 5, aas, aaf, aar, aax, aaj },
{ 5, es, ef, er, ex, ej },
{ 5, ees, eef, eer, eex, eej },
{ 5, is, 0x00EC, ir, ix, ij },
{ 5, os, of, __or , ox, oj },
{ 5, oos, oof, oor, oox, ooj },
{ 5, ows, owf, owr, owx, owj },
{ 5, us, uf, ur, ux, uj },
{ 5, uws, uwf, uwr, uwx, uwj },
{ 5, ys, yf, yr, yx, yj },

};

const uint16_t KeyBoard::vowel_Up[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR] =
{
	{ 5, AS, AF, AR, AX, AJ },
{ 5, AWS, AWF, AWR, AWX, AWJ },
{ 5, AAS, AAF, AAR, AAX, AAJ },
{ 5, ES, EF, ER, EX, EJ },
{ 5, EES, EEF, EER, EEX, EEJ },
{ 5, IS, 0x00CC, IR, IX, IJ },
{ 5, OS, OF, OR, OX, OJ },
{ 5, OOS, OOF, OOR, OOX, OOJ },
{ 5, OWS, OWF, OWR, OWX, OWJ },
{ 5, US, UF, UR, UX, UJ },
{ 5, UWS, UWF, UWR, UWX, UWJ },
{ 5, YS, YF, YR, YX, YJ },
};


void KeyBoard::getOneCharFromString(char * string, uint8_t keyIsPressed, int16_t * pointIndex)
{
	int16_t stringIndex;
	(*pointIndex)++;
	stringIndex = strlen(string);
	while (stringIndex >= (*pointIndex))
	{
		if (stringIndex == (*pointIndex))
		{
			string[stringIndex] = keyIsPressed;
		}
		else
		{
			string[stringIndex] = string[stringIndex - 1];
		}
		stringIndex--;
	}
}

uint8_t KeyBoard::get_srcRow(uint16_t keyIsPressed)
{
	switch (keyIsPressed)
	{
	case 'a':
	case 'A':
		return 0;
	case  aw:
	case  AW:
		return 1;
	case  aa:
	case  AA:
		return 2;
	case 'e':
	case 'E':
		return 3;
	case  ee:
	case  EE:
		return 4;
	case 'i':
	case 'I':
		return 5;
	case 'o':
	case 'O':
		return 6;
	case  oo:
	case  OO:
		return 7;
	case  ow:
	case  OW:
		return 8;
	case 'u':
	case 'U':
		return 9;
	case  uw:
	case  UW:
		return 10;
	case 'y':
	case 'Y':
		return 11;
	default:
		return 12;
	}
}

uint8_t KeyBoard::getContentEng(uint16_t * string, int16_t sizeOf, uint8_t keyIsPressed, int16_t * pointIndex, uint16_t * srcCharactor)
{
	uint8_t srcRow;

	mIsAddNewKey = 1;
	mCheck_Star_Press_again = 0;
	if (keyIsPressed == '*')
	{
		srcRow = 10;
	}
	else
	{
		srcRow = keyIsPressed - '0';
	}

	int16_t stringLength = strlen16(string);
	if ((*pointIndex) < sizeOf)
	{
		if (keyIsPressed != mKeyOld || mIsInvolkNewkey)
		{
			mSrcColum = 1;
			getOneUCS2FromString(string,
				srcCharactor[srcRow * KEY_MESS_LENGTH + mSrcColum], pointIndex);
		}
		else
		{
			if ((Clock_getTicks() - mTimeClock) > 1000)
			{
				mSrcColum = 1;

				getOneUCS2FromString(string,
					srcCharactor[srcRow * KEY_MESS_LENGTH + mSrcColum],
					pointIndex);
			}
			else
			{
				if (mSrcColum < srcCharactor[srcRow * KEY_MESS_LENGTH])
				{
					mSrcColum++;
				}
				else
				{
					mSrcColum = 1;
				}
				string[*pointIndex] = srcCharactor[srcRow * KEY_MESS_LENGTH
					+ mSrcColum];

				mIsAddNewKey = 0;
			}

		}
		mTimeClock = Clock_getTicks();
	}

	mKeyOld = keyIsPressed;
	releaseInvolkNewkey();

	return mIsAddNewKey;
}

uint8_t KeyBoard::getContentPressStar(uint16_t * string, int16_t sizeOf, uint8_t keyIsPressed, int16_t * pointIndex, uint16_t * srcCharactor)
{
	mIsAddNewKey = 1;

	if (mIsInvolkNewkey)
	{
		mCheck_Star_Press_again = 0;
	}

	if (string[0] == 0)
	{
		setInvolkNewkey();
		return mIsAddNewKey;
	}

	if (mCheck_Star_Press_again == 0)
	{
		mSrcRow = get_srcRow(string[*pointIndex]);
	}

	if (mSrcRow == 12)
	{
		setInvolkNewkey();
		return mIsAddNewKey;
	}
	else
	{
		int16_t stringLength = unilen(string);
		if ((*pointIndex) < sizeOf)
		{
			if (keyIsPressed != mKeyOld || mIsInvolkNewkey)
			{
				mSrcColum_star = 1;
				string[*pointIndex] = srcCharactor[mSrcRow * VOWEL_SIZE_CHAR + mSrcColum_star];
				mIsAddNewKey = 0;
			}
			else
			{
				if (mSrcColum_star < 5)
				{
					mSrcColum_star++;
				}
				else
				{
					mSrcColum_star = 1;
				}
				string[*pointIndex] = srcCharactor[mSrcRow * VOWEL_SIZE_CHAR
					+ mSrcColum_star];

				mIsAddNewKey = 0;
			}
			mCheck_Star_Press_again = 1;
		}
	}

	mKeyOld = keyIsPressed;
	releaseInvolkNewkey();

	return mIsAddNewKey;
}

void KeyBoard::getOneCharFromStringOnly(uint16_t * string, uint8_t keyIsPressed, int16_t * pointIndex)
{
	int16_t stringIndex;
	(*pointIndex)++;
	stringIndex = unilen(string);
	while (stringIndex >= (*pointIndex))
	{
		if (stringIndex == (*pointIndex))
		{
			string[stringIndex] = keyIsPressed;
		}
		else
		{
			string[stringIndex] = string[stringIndex - 1];
		}
		stringIndex--;
	}
}

KeyBoard::KeyBoard()
{
	PressType = PRESS_TYPE_EN_UPPERCASE_FIRST;

	mKeyOld = 0;
	mIsInvolkNewkey = 0;
	mIsAddNewKey = 1;
	m_old_state_press_type = PRESS_TYPE_EN_UPPERCASE_FIRST;
	mCheck_Star_Press_again = 0;
	mOld_point_index = -2;
	mSrcColum_star = 0;
	mCharStartIsSelected;
	mUppercaseFirstIsPressed = 0;
	mPointIndexOld = 0;
}

KeyBoard::KeyBoard(int initType)
{
	KeyBoard();
	PressType = initType;
}

KeyBoard::~KeyBoard()
{

}

void KeyBoard::reset_typePress()
{
	if (PressType >= PRESS_TYPE_VI_UPPERCASE_FIRST && PressType <= PRESS_TYPE_VI_LOWERCASE)
	{
		PressType = PRESS_TYPE_VI_UPPERCASE_FIRST;
	}
	else if (PressType >= PRESS_TYPE_EN_UPPERCASE_FIRST && PressType <= PRESS_TYPE_EN_LOWERCASE)
	{
		PressType = PRESS_TYPE_EN_UPPERCASE_FIRST;
	}
	else
	{
		PressType = PRESS_TYPES_NUMBER_ONLY;
	}
}

void KeyBoard::getOneUCS2FromString(uint16_t *string, uint16_t charactorInput,
	int16_t *pointIndex)
{
	int16_t stringIndex;
	(*pointIndex)++;
	stringIndex = (int16_t)(unilen(string));
	while (stringIndex >= (*pointIndex))
	{
		if (stringIndex == (*pointIndex))
		{
			string[stringIndex] = charactorInput;
		}
		else
		{
			string[stringIndex] = string[stringIndex - 1];
		}
		stringIndex--;
	}
}

void KeyBoard::getEmojiForString(uint16_t *string,
	emojiU16 emojiCode, int16_t *pointIndex)
{
	getOneUCS2FromString(string, emojiCode.high, pointIndex);
	getOneUCS2FromString(string, emojiCode.low, pointIndex);
}

uint8_t KeyBoard::getPhoneNumberOnly(uint16_t * string, int16_t sizeOf, uint8_t keyIsPressed, int16_t * pointIndex)
{
	char charStarInclue[5] =
	{ '*', '+', 'p', 'w', 4 };

	mIsAddNewKey = 1;

	if ((*pointIndex) < sizeOf)
	{
		if (keyIsPressed == '*')
		{
			if (keyIsPressed != mKeyOld || mIsInvolkNewkey)
			{
				mCharStartIsSelected = 0;
				getOneCharFromStringOnly(string, keyIsPressed, pointIndex);
				mTimeClock = Clock_getTicks();
			}
			else
			{
				if ((Clock_getTicks() - mTimeClock) > 1000)
				{
					mCharStartIsSelected = 0;

					getOneCharFromStringOnly(string, keyIsPressed, pointIndex);
				}
				else
				{
					mCharStartIsSelected++;
					if (mCharStartIsSelected == charStarInclue[4])
					{
						mCharStartIsSelected = 0;
					}
					string[*pointIndex] = charStarInclue[mCharStartIsSelected];
					mIsAddNewKey = 0;
				}
				mTimeClock = Clock_getTicks();
			}
		}
		else
		{
			getOneCharFromStringOnly(string, keyIsPressed, pointIndex);
			mTimeClock = Clock_getTicks();
		}
	}
	mKeyOld = keyIsPressed;
	releaseInvolkNewkey();
	return mIsAddNewKey;
}

uint8_t KeyBoard::KeyBoard::getMsgContent(uint16_t *string, int16_t sizeOf, uint8_t keyIsPressed,
	int16_t* pressType, int16_t *pointIndex, uint8_t isTextName)
{
	mIsAddNewKey = 1;

	if ((*pressType >= PRESS_TYPE_VI_LOWERCASE && *pressType <= PRESS_TYPE_VI_UPPERCASE_ALL)
		&& keyIsPressed == '*')
	{
		// add: fix bug when *pointIndex = -1
		if (*pointIndex < 0)
		{
			return mIsAddNewKey;
		}

		if (is_Upper_character(&string[*pointIndex]))
		{
			mIsAddNewKey = getContentPressStar(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&vowel_Up[0][0]);
		}
		else
		{
			mIsAddNewKey = getContentPressStar(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&vowel_low[0][0]);
		}
	}
	else
	{
		switch (*pressType)
		{
		case PRESS_TYPE_EN_UPPERCASE_FIRST:
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_EngUppercase[0][0]);
			mUppercaseFirstIsPressed = 1; // is pressed
			*pressType = PRESS_TYPE_EN_LOWERCASE;
			break;

		case PRESS_TYPE_EN_UPPERCASE_ALL:
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_EngUppercase[0][0]);
			break;

		case PRESS_TYPE_EN_LOWERCASE:
			mPointIndexOld = *pointIndex;
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_EngLowerCase[0][0]);

			if (mUppercaseFirstIsPressed && (mPointIndexOld == *pointIndex))
			{
				lowercaseToUppercaseCharactor(string + *pointIndex);
			}
			else
			{
				mUppercaseFirstIsPressed = 0;
			}
			break;

		case PRESS_TYPES_NUMBER_ONLY:
			mIsAddNewKey = getPhoneNumberOnly(string, sizeOf, keyIsPressed, pointIndex);
			break;

		case PRESS_TYPE_VI_UPPERCASE_FIRST:
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_VietUppercase[0][0]);
			mUppercaseFirstIsPressed = 1; // is pressed
			*pressType = PRESS_TYPE_VI_LOWERCASE;
			break;

		case PRESS_TYPE_VI_UPPERCASE_ALL:
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_VietUppercase[0][0]);
			break;

		case PRESS_TYPE_VI_LOWERCASE:
			mPointIndexOld = *pointIndex;
			mIsAddNewKey = getContentEng(string, sizeOf, keyIsPressed, pointIndex,
				(uint16_t*)&g_VietLowercase[0][0]);

			if (mUppercaseFirstIsPressed && (mPointIndexOld == *pointIndex))
			{
				lowercaseToUppercaseCharactor(string + *pointIndex);
			}
			else
			{
				mUppercaseFirstIsPressed = 0;
			}
			break;

		default:
			break;
		}
	}

	if (0 == isTextName)
	{
		pressTypeChangeAuto(string, pressType, pointIndex);
	}
	else
	{
		pressTypeNameChangeAuto(string, pressType, pointIndex);
	}

	return mIsAddNewKey;
}


void KeyBoard::clearUCS2Content(uint16_t *string, int16_t* pressType,
	int16_t *pointIndex)
{
	int16_t stringLength = unilen(string);
	int16_t stringIndex = *pointIndex;
	uint8_t i;
	uint8_t j;
	// CLEAR VOWEL
	if ((*pointIndex == 0) || *(string + *pointIndex - 1) != 0xFFFE) // not a emoji
	{
		for (i = 0; i < VOWEL_NUM_OF_CHAR; ++i)
		{
			for (j = 1; j < VOWEL_SIZE_CHAR; ++j)
			{
				if (*(string + *pointIndex) == vowel[i][j])
				{
					*(string + *pointIndex) = vowel[i][0];
					return;
				}
			}
		}
	}

	if ((stringLength > 0) && (stringIndex >= 0))
	{
		while (stringIndex <= (stringLength - 1))
		{
			if (stringIndex == (stringLength - 1))
			{
				string[stringIndex] = 0;
			}
			else
			{
				string[stringIndex] = string[stringIndex + 1];
			}
			stringIndex++;
		}
		(*pointIndex)--;
	}
}
void KeyBoard::forceClearUnicode(uint16_t *string,
	int16_t* pressType,
	int16_t *pointIndex)
{
	int16_t stringLength = unilen(string);
	int16_t stringIndex = *pointIndex;

	if ((stringLength > 0) && (stringIndex >= 0))
	{
		while (stringIndex <= (stringLength - 1))
		{
			if (stringIndex == (stringLength - 1))
			{
				string[stringIndex] = 0;
			}
			else
			{
				string[stringIndex] = string[stringIndex + 1];
			}
			stringIndex++;
		}
		(*pointIndex)--;
	}
}

void KeyBoard::pressTypeChangeAuto(uint16_t *string, int16_t* pressType,
	int16_t *pointIndex)
{
	uint8_t enableChangePressType = checkEnableChangeTheFirstUppercase(string,
		pointIndex);
	if (enableChangePressType)
	{
		switch (*pressType)
		{
		case PRESS_TYPE_EN_UPPERCASE_FIRST:
			break;
		case PRESS_TYPE_EN_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_EN_LOWERCASE:
			*pressType = PRESS_TYPE_EN_UPPERCASE_FIRST;
			break;
		case PRESS_TYPES_NUMBER_ONLY:
			break;
		case PRESS_TYPE_VI_UPPERCASE_FIRST:
			break;
		case PRESS_TYPE_VI_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_VI_LOWERCASE:
			*pressType = PRESS_TYPE_VI_UPPERCASE_FIRST;
			break;
		default:
			break;
		}
		enableChangePressType = 0;
	}
	else
	{
		switch (*pressType)
		{
		case PRESS_TYPE_EN_UPPERCASE_FIRST:
			*pressType = PRESS_TYPE_EN_LOWERCASE;
			break;
		case PRESS_TYPE_EN_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_EN_LOWERCASE:
			break;
		case PRESS_TYPES_NUMBER_ONLY:
			break;
		case PRESS_TYPE_VI_UPPERCASE_FIRST:
			*pressType = PRESS_TYPE_VI_LOWERCASE;
			break;
		case PRESS_TYPE_VI_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_VI_LOWERCASE:
			break;
		default:
			break;
		}
	}
}

void KeyBoard::pressTypeNameChangeAuto(uint16_t *string, int16_t* pressType,
	int16_t *pointIndex)
{
	uint8_t enableChangePressType = 0;
	enableChangePressType = checkEnableNewName(string, pointIndex);
	if (enableChangePressType)
	{
		switch (*pressType)
		{
		case PRESS_TYPE_EN_UPPERCASE_FIRST:
			break;
		case PRESS_TYPE_EN_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_EN_LOWERCASE:
			*pressType = PRESS_TYPE_EN_UPPERCASE_FIRST;
			break;
		case PRESS_TYPES_NUMBER_ONLY:
			break;
		case PRESS_TYPE_VI_UPPERCASE_FIRST:
			break;
		case PRESS_TYPE_VI_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_VI_LOWERCASE:
			*pressType = PRESS_TYPE_VI_UPPERCASE_FIRST;
			break;
		default:
			break;
		}
		enableChangePressType = 0;
	}
	else
	{
		switch (*pressType)
		{
		case PRESS_TYPE_EN_UPPERCASE_FIRST:
			*pressType = PRESS_TYPE_EN_LOWERCASE;
			break;
		case PRESS_TYPE_EN_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_EN_LOWERCASE:
			break;
		case PRESS_TYPES_NUMBER_ONLY:
			break;
		case PRESS_TYPE_VI_UPPERCASE_FIRST:
			*pressType = PRESS_TYPE_VI_LOWERCASE;
			break;
		case PRESS_TYPE_VI_UPPERCASE_ALL:
			break;
		case PRESS_TYPE_VI_LOWERCASE:
			break;
		default:
			break;
		}
	}
}
int16_t KeyBoard::getPressTypeDefaultStart()
{
	int16_t defaultType = PRESS_TYPE_EN_UPPERCASE_FIRST;
	switch (getLanguage())
	{
	case ENGLISH:
		defaultType = PRESS_TYPE_EN_UPPERCASE_FIRST;
		break;
		// TODO: Implement another language type here!
	case FRENCH:
	case ITALIAN:
	case GERMAN:
	case SPANISH:
	case CHINESE:
		break;
	case VIETNAMESE:
		defaultType = PRESS_TYPE_VI_UPPERCASE_FIRST;
		break;
	default:
		break;
	}
	return defaultType;
}

uint8_t KeyBoard::checkEnableChangeTheFirstUppercase(uint16_t *string,
	int16_t *pointIndex)
{
	uint8_t enableChangePressType = 0;
	if (*pointIndex >= 1)
	{
		if (((*(string + *pointIndex - 1) == '.')
			&& (*(string + *pointIndex) == ' '))
			|| ((*(string + *pointIndex - 1) == '!') && (*(string + *pointIndex)
				== ' '))
			|| ((*(string + *pointIndex - 1) == '?') && (*(string + *pointIndex)
				== ' ')))
		{
			enableChangePressType = 1;
		}
	}
	if (*(string + *pointIndex) == 0x13)
	{
		enableChangePressType = 1;
	}
	if (-1 == *pointIndex)
	{
		enableChangePressType = 1;
	}
	return (enableChangePressType);
}
uint8_t KeyBoard::checkEnableNewName(uint16_t *string, int16_t *pointIndex)
{
	if (-1 == *pointIndex)
	{
		return 1;
	}
	if (*(string + *pointIndex) == ' ')
	{
		return 1;
	}
	if (*pointIndex >= 1)
	{
		if (((*(string + *pointIndex - 1) == '.')
			&& (*(string + *pointIndex) == ' '))
			|| ((*(string + *pointIndex - 1) == '!') && (*(string + *pointIndex)
				== ' '))
			|| ((*(string + *pointIndex - 1) == '?') && (*(string + *pointIndex)
				== ' ')))
		{
			return 1;
		}
	}

	return 0;
}
void KeyBoard::changePressType(uint16_t *string,
	int16_t* pressType,
	int16_t *pointIndex)
{
	uint8_t language = getLanguage();

	switch (language)
	{
	case VIETNAMESE:
	case ENGLISH:
		(*pressType)++;
		if (*pressType == PRESS_TYPE_END)
		{
			(*pressType) = PRESS_TYPE_EN_LOWERCASE;
		}
		break;
	case FRENCH:
		break;
	case ITALIAN:
		break;
	case GERMAN:
		break;
	case SPANISH:
		break;
	case CHINESE:
		break;
	default:
		break;
	}

	setInvolkNewkey();
}

uint16_t KeyBoard::strlenBeforeEncodeEmoji(uint16_t* content)
{
	uint16_t i;
	uint16_t content_len = 0;

	for (i = 0; i< 0xffff; i++)
	{
		if (*(content + i) == 0)
		{
			break;
		}
		else if (isEmojiCode(content, i))
		{
			i++;
			if (*(content + i) == 0)
			{
				break;
			}
			content_len += calNumOfCharEmoji(*(content + i) - 1); // input = indexNAND - 1
		}
		else
		{
			content_len++;
		}
	}
	return content_len;
}
void KeyBoard::setInvolkNewkey()
{
	mIsInvolkNewkey = 1;
}

uint8_t KeyBoard::getInvolkNewkey()
{
	return mIsInvolkNewkey;
}

void KeyBoard::releaseInvolkNewkey()
{
	mIsInvolkNewkey = 0;
}

uint8_t KeyBoard::getNumMessFromContent(uint16_t* content, uint8_t* num_char)
{
	uint16_t content_len = strlenBeforeEncodeEmoji(content);
	uint8_t isUnicode = isUnicodeString(content, strlen16(content));//content_len);//
	uint8_t num_mess;

	if (isUnicode)
	{
		if (content_len <= 70)
		{
			num_mess = 1;
			if (num_char != NULL)
			{
				*num_char = 70 - content_len;
			}
		}
		else
		{
			num_mess = (content_len % 67 == 0) ? (content_len / 67) : (content_len / 67 + 1);
			if (num_char != NULL)
			{
				*num_char = (content_len % 67 == 0) ? 0 : (67 - content_len % 67);
			}
		}
	}
	else
	{
		if (content_len <= 160)
		{
			num_mess = 1;
			if (num_char != NULL)
			{
				*num_char = 160 - content_len;
			}
		}
		else
		{
			num_mess = (content_len % 153 == 0) ? (content_len / 153) : (content_len / 153 + 1);
			if (num_char != NULL)
			{
				*num_char = (content_len % 153 == 0) ? 0 : (153 - content_len % 153);
			}

		}
	}

	return num_mess;
}

char* KeyBoard::ToString()
{
	char* typeName = "Unknow type";
	switch (PressType)
	{
	case PRESS_TYPE_EN_LOWERCASE:
		typeName = "PRESS_TYPE_EN_LOWERCASE";
		break;
	case PRESS_TYPE_EN_UPPERCASE_FIRST:
		typeName = "PRESS_TYPE_EN_UPPERCASE_FIRST";
		break;
	case PRESS_TYPE_EN_UPPERCASE_ALL:
		typeName = "PRESS_TYPE_EN_UPPERCASE_ALL";
		break;
	case PRESS_TYPES_NUMBER_ONLY:
		typeName = "PRESS_TYPES_NUMBER_ONLY";
		break;
	case PRESS_TYPE_VI_LOWERCASE:
		typeName = "PRESS_TYPE_VI_LOWERCASE";
		break;
	case PRESS_TYPE_VI_UPPERCASE_FIRST:
		typeName = "PRESS_TYPE_VI_UPPERCASE_FIRST";
		break;
	case PRESS_TYPE_VI_UPPERCASE_ALL:
		typeName = "PRESS_TYPE_VI_UPPERCASE_ALL";
		break;
	case PRESS_TYPE_END:
		//typeName = "PRESS_TYPE_EN_LOWERCASE";
		break;
	default:
		break;
	}
	return typeName;
}
