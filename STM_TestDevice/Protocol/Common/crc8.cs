using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImage.Protocol.Common
{
    public class crc8
    {
        private const int CRC_POLY_16 = 0xA001;
        private const Int64 CRC_POLY_32 = 0xEDB88320L;
        private const int CRC_POLY_CCITT = 0x1021;
        private const int CRC_POLY_DNP = 0xA6BC;
        private const int CRC_POLY_KERMIT = 0x8408;
        private const int CRC_POLY_SICK = 0x8005;

        /*
         * #define CRC_START_xxxx
         *
         * The constants of the form CRC_START_xxxx define the values that are used for
         * initialization of a CRC value for common used calculation methods.
         */

        private const int CRC_START_8 = 0x00;
        private const int CRC_START_16 = 0x0000;
        private const int CRC_START_MODBUS = 0xFFFF;
        private const int CRC_START_XMODEM = 0x0000;
        private const int CRC_START_CCITT_1D0F = 0x1D0F;
        private const int CRC_START_CCITT_FFFF = 0xFFFF;
        private const int CRC_START_KERMIT = 0x0000;
        private const int CRC_START_SICK = 0x0000;
        private const int CRC_START_DNP = 0x0000;
        private const Int64 CRC_START_32 = 0xFFFFFFFFL;

        
private byte[] sht75_crc_table = {

	0,   49,  98,  83,  196, 245, 166, 151, 185, 136, 219, 234, 125, 76,  31,  46,
	67,  114, 33,  16,  135, 182, 229, 212, 250, 203, 152, 169, 62,  15,  92,  109,
	134, 183, 228, 213, 66,  115, 32,  17,  63,  14,  93,  108, 251, 202, 153, 168,
	197, 244, 167, 150, 1,   48,  99,  82,  124, 77,  30,  47,  184, 137, 218, 235,
	61,  12,  95,  110, 249, 200, 155, 170, 132, 181, 230, 215, 64,  113, 34,  19,
	126, 79,  28,  45,  186, 139, 216, 233, 199, 246, 165, 148, 3,   50,  97,  80,
	187, 138, 217, 232, 127, 78,  29,  44,  2,   51,  96,  81,  198, 247, 164, 149,
	248, 201, 154, 171, 60,  13,  94,  111, 65,  112, 35,  18,  133, 180, 231, 214,
	122, 75,  24,  41,  190, 143, 220, 237, 195, 242, 161, 144, 7,   54,  101, 84,
	57,  8,   91,  106, 253, 204, 159, 174, 128, 177, 226, 211, 68,  117, 38,  23,
	252, 205, 158, 175, 56,  9,   90,  107, 69,  116, 39,  22,  129, 176, 227, 210,
	191, 142, 221, 236, 123, 74,  25,  40,  6,   55,  100, 85,  194, 243, 160, 145,
	71,  118, 37,  20,  131, 178, 225, 208, 254, 207, 156, 173, 58,  11,  88,  105,
	4,   53,  102, 87,  192, 241, 162, 147, 189, 140, 223, 238, 121, 72,  27,  42,
	193, 240, 163, 146, 5,   52,  103, 86,  120, 73,  26,  43,  188, 141, 222, 239,
	130, 179, 224, 209, 70,  119, 36,  21,  59,  10,  89,  104, 255, 206, 157, 172
};

/*
 * uint8_t crc_8( const unsigned char *input_str, size_t num_bytes );
 *
 * The function crc_8() calculates the 8 bit wide CRC of an input string of a
 * given length.
 */

public byte crc_8(byte[] input_str, int offset, int num_bytes)
{

	int a;
	byte crc;
	byte[] ptr;

	crc = CRC_START_8;
	ptr = input_str;

	if ( ptr != null ) for (a=0; a<num_bytes; a++) {

        crc = sht75_crc_table[(ptr[a + offset]) ^ crc];
	}

	return crc;

}  /* crc_8 */

/*
 * uint8_t update_crc_8( unsigned char crc, unsigned char val );
 *
 * Given a databyte and the previous value of the CRC value, the function
 * update_crc_8() calculates and returns the new actual CRC value of the data
 * comming in.
 */

public byte update_crc_8( byte crc, byte val ) {

	return sht75_crc_table[val ^ crc];

}  /* update_crc_8 */


    }
}
