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
#include "Bit1.h"
#include "Bit2.h"
#include "MPU.h"

typedef struct{
	int16_t x;
	int16_t y;
	int16_t z;
	int16_t Gx;
	int16_t Gy;
	int16_t Gz;
	int8_t id;
}MMA845X;

typedef enum{
	IDLE,
	TRANSMIT,
	RECEIVE
}MMA845_STATE;

#define MMA845X_DIVIDER		0x04
#define MPU_BUFFER_SIZE 14 //Measuerment data accel, temp, gyro

volatile bool DataRecivedFlg = FALSE;
volatile bool DataTransmittedFlg = FALSE;

uint8_t tmp=0;

uint8_t OutData[2] = {0x2A, 0x01}; // Inicjacja bufora wyjściowego
uint8_t InData[MPU_BUFFER_SIZE];
LDD_TError Error;

LDD_TDeviceData *MyI2CPtr;
LDD_TDeviceData *MyTimerPtr;

MMA845X mma845x;
int16_t mma845_tmp;

volatile bool DataTransmittedFlg;
volatile bool DataRecivedFlg;
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
void WhoAmI(void)
{

  OutData[0] = MPU6050_RA_WHO_AM_I; 

  Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 1, LDD_I2C_NO_SEND_STOP);
  while (!DataTransmittedFlg);  
  DataTransmittedFlg = FALSE;
  
  Error = CI2C1_MasterReceiveBlock(MyI2CPtr, &mma845x.id, 1, LDD_I2C_SEND_STOP);
  while (!DataRecivedFlg);
  DataRecivedFlg = FALSE;
  

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
       
      OutData[0] = MPU6050_RA_ACCEL_XOUT_H;
      Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 1, LDD_I2C_NO_SEND_STOP); /* Send OutData (4 bytes) on the I2C bus and generates a stop condition to end transmission */
      while (!DataTransmittedFlg); 
      DataTransmittedFlg = FALSE;   
    }
    else if(measuring == RECEIVE)
    {
      measuring = IDLE;
      measuring_last = RECEIVE; 
      Error = CI2C1_MasterReceiveBlock(MyI2CPtr, &InData, MPU_BUFFER_SIZE, LDD_I2C_SEND_STOP);
      while (!DataRecivedFlg);
      DataRecivedFlg = FALSE;  

      mma845_tmp = InData[1] | (InData[0] << 8);
      mma845x.x = (mma845_tmp / MMA845X_DIVIDER);

      mma845_tmp = InData[3] | (InData[2] << 8);
      mma845x.y = (mma845_tmp / MMA845X_DIVIDER);

      mma845_tmp = InData[5] | (InData[4] << 8);     
      mma845x.z = (mma845_tmp / MMA845X_DIVIDER);  
      
      mma845_tmp = InData[9] | (InData[8] << 8);     
      mma845x.Gx = (mma845_tmp / MMA845X_DIVIDER);
      
      mma845_tmp = InData[11] | (InData[10] << 8);     
      mma845x.Gy = (mma845_tmp / MMA845X_DIVIDER);
            
      mma845_tmp = InData[13] | (InData[12] << 8);     
      mma845x.Gz = (mma845_tmp / MMA845X_DIVIDER);

      printf("x %d;y %d;z %d;", mma845x.Gx, mma845x.Gy, mma845x.Gz);
      
      if(Bit1_GetVal(NULL)==0){
    	  printf("  b0");
      }
      else{
    	  printf("  b1");
      }
      printf(";F\n");
    }
}

void MPUinit(void){
	  OutData[0]=MPU6050_RA_SMPLRT_DIV;
	  OutData[1]=0x07;
	  
	  Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 2, LDD_I2C_NO_SEND_STOP); 
	  while (!DataTransmittedFlg); 
	  DataTransmittedFlg = FALSE;
	  
	  OutData[0]=MPU6050_RA_GYRO_CONFIG;
	  OutData[1]=0b00001000;
	  	  
	  Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 2, LDD_I2C_NO_SEND_STOP); 
	  while (!DataTransmittedFlg); 
	  DataTransmittedFlg = FALSE;
	  
	  OutData[0]=MPU6050_RA_PWR_MGMT_1;
	  OutData[1]=0b00000010;
		  	  
      Error = CI2C1_MasterSendBlock(MyI2CPtr, &OutData, 2, LDD_I2C_NO_SEND_STOP); 
	  while (!DataTransmittedFlg); 
	  DataTransmittedFlg = FALSE;
	  
	  
}


#endif /* GYRO_H_ */
