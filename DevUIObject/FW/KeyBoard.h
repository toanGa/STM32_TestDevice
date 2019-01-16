#pragma once
#include <stdint.h>
#include "Unicode.h"
#include "int16.h"
#include "libs/setting/phone.h"
#include "guiObjects/Emoji/Emoji.h"

class KeyBoard
{
private:
#define 				KEY_MESS_LENGTH		(20)
#define 				KEY_MESS_NUMBER		(11)
#define 				VOWEL_NUM_OF_CHAR 	(24)
#define 				VOWEL_SIZE_CHAR		(6)
	/*******************************************************************************
	**                      INTERNAL VARIABLE DEFINITIONS
	*******************************************************************************/
	static const uint16_t g_EngUppercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH];
	// lowercase
	static const uint16_t g_EngLowerCase[KEY_MESS_NUMBER][KEY_MESS_LENGTH];

	// viet nam lowercase
	// Vietkey message
	static const uint16_t g_VietLowercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH];

	// viet nam lowercase
	// Vietkey message
	static const uint16_t g_VietUppercase[KEY_MESS_NUMBER][KEY_MESS_LENGTH];

	//table vowel in vietnamses
	static const uint16_t vowel[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR];


	//table vowel in vietnamses
	static const uint16_t vowel_low[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR];

	static const uint16_t vowel_Up[VOWEL_NUM_OF_CHAR][VOWEL_SIZE_CHAR];


	char mKeyOld;
	uint8_t mIsInvolkNewkey;
	uint8_t mIsAddNewKey;
	uint8_t m_old_state_press_type;
	uint8_t mCheck_Star_Press_again;
	int16_t mOld_point_index;

	uint8_t mSrcColum;
	uint32_t mTimeClock;
	uint8_t mSrcRow;
	uint8_t mSrcColum_star;
	uint8_t mCharStartIsSelected;
	uint8_t mUppercaseFirstIsPressed;
	uint16_t mPointIndexOld;

	void getOneCharFromString(char *string, uint8_t keyIsPressed,
		int16_t *pointIndex);
	uint8_t get_srcRow(uint16_t keyIsPressed);
	uint8_t getContentEng(uint16_t *string, int16_t sizeOf,
		uint8_t keyIsPressed, int16_t *pointIndex,
		uint16_t *srcCharactor);

	uint8_t getContentPressStar(uint16_t *string,
		int16_t sizeOf,
		uint8_t keyIsPressed,
		int16_t *pointIndex,
		uint16_t *srcCharactor);
	void getOneCharFromStringOnly(uint16_t *string, uint8_t keyIsPressed,
		int16_t *pointIndex);
public:
	typedef enum
	{
		PRESS_TYPE_EN_LOWERCASE = 0,
		PRESS_TYPE_EN_UPPERCASE_FIRST,
		PRESS_TYPE_EN_UPPERCASE_ALL,
		PRESS_TYPES_NUMBER_ONLY,
		PRESS_TYPE_VI_LOWERCASE,
		PRESS_TYPE_VI_UPPERCASE_FIRST,
		PRESS_TYPE_VI_UPPERCASE_ALL,
		PRESS_TYPE_END
	}EPressType;

	KeyBoard();
	KeyBoard(int initType);
	~KeyBoard();
	
	int16_t PressType;
	void reset_typePress();
	void getOneUCS2FromString(uint16_t *string, uint16_t charactorInput,
		int16_t *pointIndex);
	void getEmojiForString(uint16_t *string,
		emojiU16 emojiCode, int16_t *pointIndex);
	uint8_t getPhoneNumberOnly(uint16_t *string, int16_t sizeOf,
		uint8_t keyIsPressed, int16_t *pointIndex);
	uint8_t getMsgContent(uint16_t *string, int16_t sizeOf, uint8_t keyIsPressed,
		int16_t* pressType, int16_t *pointIndex, uint8_t isTextName);
	void clearUCS2Content(uint16_t *string, int16_t* pressType,
		int16_t *pointIndex);
	void forceClearUnicode(uint16_t *string,
		int16_t* pressType,
		int16_t *pointIndex);
	void pressTypeChangeAuto(uint16_t *string, int16_t* pressType,
		int16_t *pointIndex);
	void pressTypeNameChangeAuto(uint16_t *string, int16_t* pressType,
		int16_t *pointIndex);
	int16_t getPressTypeDefaultStart();
	uint8_t checkEnableChangeTheFirstUppercase(uint16_t *string,
		int16_t *pointIndex);
	uint8_t checkEnableNewName(uint16_t *string, int16_t *pointIndex);
	void changePressType(uint16_t *string,
		int16_t* pressType,
		int16_t *pointIndex);
	uint16_t strlenBeforeEncodeEmoji(uint16_t* content);
	void setInvolkNewkey();
	uint8_t getInvolkNewkey();
	void releaseInvolkNewkey();
	uint8_t getNumMessFromContent(uint16_t* content, uint8_t* num_char);

	char* ToString();
};
