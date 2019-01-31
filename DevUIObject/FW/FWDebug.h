/*
 * FWDebug.h
 *
 *  Created on: Jan 15, 2019
 *      Author: tranvantoan
 */

#ifndef MIDDLEWARE_FW_FWDEBUG_H_
#define MIDDLEWARE_FW_FWDEBUG_H_
#ifdef WIN32
#define _CRTDBG_MAP_ALLOC  
#include <stdlib.h>  
#include <crtdbg.h>
#endif

#include "uart_console.h"
#include "assert.h"
#define PRINTF        SOS_DEBUG
#define NTPRINTF(a)   {SOS_DEBUG("Nt Debug: "); HWI_DEBUG(#a); HWI_DEBUG("\r\n");}
#define FWASSERT      assert
#endif /* MIDDLEWARE_FW_FWDEBUG_H_ */
