/*
 * gyro.h
 *
 *  Created on: Jan 10, 2017
 *      Author: Jan
 */

#ifndef GYRO_H_
#define GYRO_H_

#include "stdio.h"
#include "CsIO1.h"
#include "IO1.h"

typedef struct{
	int16_t x;
	int16_t y;
	int16_t z;
	int8_t id;
}MMA845X;

typedef enum{
	IDLE,
	TRANSMIT,
	RECEIVE
}MMA845_STATE;

#define MMA845X_DIVIDER		0x04
#define MMA845X_BUFFER_SIZE 0x06
#define MMA845X_CFG_VALUE	0x01
#define MMA845X_DEVICE_ID	0x0D

volatile bool DataRecivedFlg = FALSE;
volatile bool DataTransmittedFlg = FALSE;

uint8_t OutData[2] = {0x2A, 0x01}; // Inicjacja buforu wyjœciowego
uint8_t InData[MMA845X_BUFFER_SIZE];
LDD_TError Error;

LDD_TDeviceData *MyI2CPtr;
LDD_TDeviceData *MyTimerPtr;

MMA845X mma845x;
int16_t mma845_tmp;

volatile bool DataTransmittedFlg;
volatile bool DataReceivedFlg;
static MMA845_STATE measuring = IDLE;
static MMA845_STATE measuring_last = RECEIVE;

void Timer_Interrupt_CB(void)
{
  if(measuring == IDLE)
  {
    if(measuring_last == TRANSMIT)
      measuring = RECEIVE; 
    else if(measuring_last == RECEIVE)
      measuring = TRANSMIT;
  }
}

/*****************************************************************************
* Inicjacja I2C dla  MMA845x
******************************************************************************/
void MMA845X_Init(void)
{
  /* Configure I2C BUS device(e.g. RTC) - Write Operation */
  Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 2, LDD_I2C_NO_SEND_STOP); /* Send OutData (4 bytes) on the I2C bus and generates a stop condition to end transmission */
  while (!DataTransmittedFlg); 
  DataTransmittedFlg = FALSE;
  
  OutData[0] = MMA845X_DEVICE_ID; 

  Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 1, LDD_I2C_NO_SEND_STOP);
  while (!DataTransmittedFlg);  
  DataTransmittedFlg = FALSE;
  
  Error = CI2C1_MasterReceiveBlock(MyI2CPtr, &mma845x.id, 1, LDD_I2C_SEND_STOP);
  while (!DataReceivedFlg);
  DataReceivedFlg = FALSE;
}

/**************************************************************************//*!
*   MMA845x polling
******************************************************************************/
void MMA845X_Poll(void)
{
    if(measuring == TRANSMIT)
    {
      measuring = IDLE;
      measuring_last = TRANSMIT;
       
      OutData[0] = MMA845X_CFG_VALUE;
      Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 1, LDD_I2C_NO_SEND_STOP); /* Send OutData (4 bytes) on the I2C bus and generates a stop condition to end transmission */
      while (!DataTransmittedFlg); 
      DataTransmittedFlg = FALSE;   
    }
    else if(measuring == RECEIVE)
    {
      measuring = IDLE;
      measuring_last = RECEIVE;
      Error = CI2C1_MasterReceiveBlock(MyI2CPtr, &InData, MMA845X_BUFFER_SIZE, LDD_I2C_SEND_STOP);
      while (!DataReceivedFlg);
      DataReceivedFlg = FALSE;  

      mma845_tmp = InData[1] | (InData[0] << 8);
      mma845x.x = (mma845_tmp / MMA845X_DIVIDER);

      mma845_tmp = InData[3] | (InData[2] << 8);
      mma845x.y = (mma845_tmp / MMA845X_DIVIDER);

      mma845_tmp = InData[5] | (InData[4] << 8);     
      mma845x.z = (mma845_tmp / MMA845X_DIVIDER);   

      printf("x-axis %d \ny-axis %d \nz-axis %d \n", mma845x.x, mma845x.y, mma845x.z);
      printf("\n");
    }
}


#endif /* GYRO_H_ */
