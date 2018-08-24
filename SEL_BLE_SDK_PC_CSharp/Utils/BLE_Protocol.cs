using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEL_BLE_SDK_PC_CSharp.Utils
{
    static class BleProtocol
    {

        public static OperationRecord Record { set; get; }

        /// <summary>
        /// This function is used to analyze the received package;
        /// </summary>
        /// <param name="data"></param>
        public static void PackageAnalyze(byte[] data)
        {
            var dest = new byte[data.Length - 3];

            for(int i = 2; i <(data.Length - 1); i++)
            {
                dest[i - 2] = data[i];
            }

            if ((data[0] == 0xAA) && (data[1] == 0x55))
            {
                var crcRead = data[data.Length- 1];

                var crcCalced = CRC.Crc8(dest);

                if (crcRead == crcCalced)
                {
                    CommandHandler((byte)(data[4] & 0x7F), data);
                }
            }
        }

        /// <summary>
        /// This will be called only when crc has been verified.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data"></param>
        static void CommandHandler(byte command, byte[] data)
        {
            switch (command)
            {
                case BLE_Commands.BLE_OPERATE_EVENT_REPORT:
                {
                    OperationRecordHandler(data);
                    break;
                }
                default:
                {
                    break;
                }
            }
        }


        static void OperationRecordHandler(byte[] data)
        {
            if (data[3] == 0x02)
            {
                switch (data[5])
                {
                    case 2:
                        break;
                    case 3:
                        MessageBox.Show("已上报所有开门记录");
                        break;
                    case 4:
                        MessageBox.Show("已上报所有操作记录");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Record = new OperationRecord();

                var year = Bcd2Int(data[10]);
                var month = Bcd2Int(data[9]);
                var day = Bcd2Int(data[8]);
                var hour = Bcd2Int(data[7]);
                var minute = Bcd2Int(data[6]);
                var second = Bcd2Int(data[5]);

                Record.Date = new DateTime(2000 + year, month, day, hour, minute, second);
                Record.UserId = data[11] + (data[12] << 8);
                Record.OperationType = data[13];
                Record.UserType = data[14];
            }
        }

        /// <summary>
        /// Get the current date and time. And package them.
        /// </summary>
        /// <returns></returns>
        public static byte[] GetUpdateTimePackage()
        {
            byte[] data = new byte[20];
            byte[] crcBytes = new byte[17];

            for (var i = 0; i < data.Length; i++)
            {
                data[i] = 0xFF;
            }

            data[0] = 0xAA;
            data[1] = 0x55;
            data[2] = 0x00;
            data[3] = 0x09;
            data[4] = 0x1A;
            data[5] = 0x00;
            var date = DateTime.Now;
            data[6] = Int2Bcd(date.Year);
            data[7] = Int2Bcd(date.Month);
            data[8] = Int2Bcd(date.Day);
            data[9] = Int2Bcd(date.Hour);
            data[10] = Int2Bcd(date.Minute);
            data[11] = Int2Bcd(date.Second);
            data[12] = Int2Bcd((int)date.DayOfWeek);

            for (var i = 0; i < crcBytes.Length; i++)
            {
                crcBytes[i] = data[i + 2];
            }

            data[19] = CRC.Crc8(crcBytes);

            return data;
        }

        /// <summary>
        /// Change the received BCD date/time to int.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Bcd2Int(byte b)
        {
            int res = ((b & 0xf0) >> 4) * 10;
            res += (b & 0x0f);
            return res;
        }

        /// <summary>
        /// Changet the int date/time to BCD for sync lock time.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        static byte Int2Bcd(int i)
        {
            i = i % 100;

            byte b = (byte)(((i / 10) & 0x0f) << 4);
            b += (byte) ((i % 10) & 0x0f);

            return b;
        }
    }
}
