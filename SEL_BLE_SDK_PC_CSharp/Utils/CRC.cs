using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_BLE_SDK_PC_CSharp.Utils
{
    static class CRC
    {
        public static byte Crc8(byte[] data)
        {
            var crc = 0;

            for (var i = 0; i < data.Length; i++)
            {
                crc = crc ^ data[i];

                for (var j = 0; j < 8; j++)
                {
                    if ((crc & 0x01) != 0)
                    {
                        crc = (crc >> 1) ^ 0x8c;
                    }
                    else
                    {
                        crc = crc >> 1;
                    }
                }
            }

            return (byte)crc;
        }
    }
}
