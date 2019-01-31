#pragma once

// Key definition
#define KEYUP              1
#define KEYDOWN            2
#define KEYLEFT            3
#define KEYRIGHT           4
#define KEYLEFTSELECT      5
#define KEYRIGHTSELECT     6
#define KEYENTER           7
#define KEYHOME            8
#define KEYCALL            9
#define KEYVOLUP           10
#define KEYVOLDOWN         11
#define KEYPOWER           12
#define KEY_0              '0'
#define KEY_1              '1'
#define KEY_2              '2'
#define KEY_3              '3'
#define KEY_4              '4'
#define KEY_5              '5'
#define KEY_6              '6'
#define KEY_7              '7'    
#define KEY_8              '8'              
#define KEY_9              '9'
#define KEY_STAR           '*'
#define KEY_HASHTAG        '#'
class Message
{
public:
	typedef enum
	{
		MessageUndefined,
		MessageKB0Up,
		MessageKB0Down,
		MessageKB0Press,
		MessageKB1Up,
		MessageKB1Down,
		MessageKB1Press,
		MessageKB2Up,
		MessageKB2Down,
		MessageKB2Press,
		MessageKB3Up,
		MessageKB3Down,
		MessageKB3Press,
		MessageKB4Up,
		MessageKB4Down,
		MessageKB4Press,
		MessageKB5Up,
		MessageKB5Down,
		MessageKB5Press,
		MessageKB6Up,
		MessageKB6Down,
		MessageKB6Press,
		MessageKB7Up,
		MessageKB7Down,
		MessageKB7Press,
		MessageKB8Up,
		MessageKB8Down,
		MessageKB8Press,
		MessageKB9Up,
		MessageKB9Down,
		MessageKB9Press,
		MessageKBStarUp,
		MessageKBStarDown,
		MessageKBStarPress,
		MessageKBHashtagUp,
		MessageKBHashtagDown,
		MessageKBHashtagPress,
		MessageKBUpUp,
		MessageKBUpDown,
		MessageKBUpPress,
		MessageKBDownUp,
		MessageKBDownDown,
		MessageKBDownPress,
		MessageKBLeftUp,
		MessageKBLeftDown,
		MessageKBLeftPress,
		MessageKBRightUp,
		MessageKBRightDown,
		MessageKBRightPress,

		MessageKBEnterUp,
		MessageKBEnterDown,
		MessageKBEnterPress,

		MessageKBLeftSelectUp,
		MessageKBLeftSelectDown,
		MessageKBLeftSelectPress,

		MessageKBRightSelectUp,
		MessageKBRightSelectDown,
		MessageKBRightSelectPress,

		MessageKBHomeUp,// end call
		MessageKBHomeDown,
		MessageKBHomePress,
		MessageKBCallUp,
		MessageKBCallDown,
		MessageKBCallPress,
		MessageKBVolupUp,
		MessageKBVolupDown,
		MessageKBVolupPress,
		MessageKBVoldownUp,
		MessageKBVoldownDown,
		MessageKBVoldownPress,
		MessageKBPowerUp,
		MessageKBPowerDown,
		MessageKBPowerPress,
		MessageTimer
	}EMessage;
	Message();
	Message(EMessage msg);
	~Message();
	int Msg;
	char* ToString();
};
