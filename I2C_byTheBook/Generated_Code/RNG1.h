/* ###################################################################
**     This component module is generated by Processor Expert. Do not modify it.
**     Filename    : RNG1.h
**     Project     : I2C_byTheBook
**     Processor   : MKL46Z256VMC4
**     Component   : RingBufferUInt8
**     Version     : Component 01.003, Driver 01.00, CPU db: 3.00.000
**     Compiler    : GNU C Compiler
**     Date/Time   : 2017-01-10, 18:27, # CodeGen: 2
**     Abstract    :
**
**     Settings    :
**
**     Contents    :
**         Put             - byte RNG1_Put(byte elem);
**         Get             - byte RNG1_Get(byte *elemP);
**         NofElements     - byte RNG1_NofElements(void);
**         NofFreeElements - byte RNG1_NofFreeElements(void);
**         Init            - void RNG1_Init(void);
**
**     License   :  Open Source (LGPL)
**     Copyright : (c) Copyright Erich Styger, 2012, all rights reserved.
**     This an open source software of an embedded component for Processor Expert.
**     This is a free software and is opened for education,  research  and commercial developments under license policy of following terms:
**     * This is a free software and there is NO WARRANTY.
**     * No restriction on use. You can use, modify and redistribute it for personal, non-profit or commercial product UNDER YOUR RESPONSIBILITY.
**     * Redistributions of source code must retain the above copyright notice.
** ###################################################################*/
/*!
** @file RNG1.h
** @version 01.00
** @brief
**
*/         
/*!
**  @addtogroup RNG1_module RNG1 module documentation
**  @{
*/         

#ifndef __RNG1_H
#define __RNG1_H

/* MODULE RNG1. */

/* Include shared modules, which are used for whole project */
#include "PE_Types.h"
#include "PE_Error.h"
#include "PE_Const.h"
#include "IO_Map.h"
/* Include inherited beans */

#include "Cpu.h"


#define RNG1_BUF_SIZE   64  /* number of elements in the buffer */


byte RNG1_Put(byte elem);
/*
** ===================================================================
**     Method      :  RNG1_Put (component RingBufferUInt8)
**     Description :
**         Puts a new element into the buffer
**     Parameters  :
**         NAME            - DESCRIPTION
**         elem            - New element to be put into the buffer
**     Returns     :
**         ---             - Error code
** ===================================================================
*/

byte RNG1_Get(byte *elemP);
/*
** ===================================================================
**     Method      :  RNG1_Get (component RingBufferUInt8)
**     Description :
**         Removes an element from the buffer
**     Parameters  :
**         NAME            - DESCRIPTION
**       * elemP           - Pointer to where to store the received
**                           element
**     Returns     :
**         ---             - Error code
** ===================================================================
*/

byte RNG1_NofElements(void);
/*
** ===================================================================
**     Method      :  RNG1_NofElements (component RingBufferUInt8)
**     Description :
**         Returns the actual number of elements in the buffer.
**     Parameters  : None
**     Returns     :
**         ---             - Number of elements in the buffer.
** ===================================================================
*/

void RNG1_Init(void);
/*
** ===================================================================
**     Method      :  RNG1_Init (component RingBufferUInt8)
**     Description :
**         Initializes the data structure
**     Parameters  : None
**     Returns     : Nothing
** ===================================================================
*/

byte RNG1_NofFreeElements(void);
/*
** ===================================================================
**     Method      :  RNG1_NofFreeElements (component RingBufferUInt8)
**     Description :
**         Returns the actual number of free elements/space in the
**         buffer.
**     Parameters  : None
**     Returns     :
**         ---             - Number of elements in the buffer.
** ===================================================================
*/

/* END RNG1. */

#endif
/* ifndef __RNG1_H */
/*!
** @}
*/
/*
** ###################################################################
**
**     This file was created by Processor Expert 10.3 [05.09]
**     for the Freescale Kinetis series of microcontrollers.
**
** ###################################################################
*/
