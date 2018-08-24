using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_BLE_SDK_PC_CSharp.Utils
{
    class BLE_Commands
    {
        public const byte BLE_OPEN_DOOR = 0x1A;                    //开门接口

        public const byte BLE_SET_LOCK_CONFIG = 0x18;              //设置智能锁配置

        public const byte BLE_QUERY_USER_DATA = 0x1b;              //27查询用户数据
        public const byte BLE_QUERY_USER_VALID_TIME = 0x1c;        //28查询用户有效时间
        public const byte BLE_SET_USER_VALID_TIME = 0x1d;          //29设置用户有效时间

        public const byte BLE_DELETE_GENERAL_USER = 0x1E;          //30删除普通用户(app用户)
        public const byte BLE_DELETE_ADMIN_USER = 0x21;            //删除智能锁

        public const byte BLE_DELETE_PWD_USER = 0x1F;              //31删除密码用户(指纹、卡用户)
        public const byte BLE_SYNC_FINISH = 0x20;                  //32同步完成


        public const byte BLE_STATE_EVENT_REPORT = 0x32;           //50 操作事件上报
        public const byte BLE_OPERATE_EVENT_REPORT = 0x33;         //51 操作事件上报
        public const byte BLE_CONFIG_EVENT_REPORT = 0x34;          //52 配置事件上报
        public const byte BLE_WARN_EVENT_REPORT = 0x35;            //53 报警事件上报
        public const byte BLE_FAULT_EVENT_REPORT = 0x36;           //54 故障事件上报

        public const byte BLE_OTA_READY = 0x25;                    //37 OTA升级准备命令
        public const byte BLE_OTA_DATA = 0x26;                     //38 OTA传输数据命令
        public const byte BLE_OTA_DATA_FINISH = 0x27;              //39 OTA数据传输结束命令
        public const byte BLE_OTA_START_PROGRAM = 0x28;            //40 OTA开始编程命令

        public const byte BLE_QUERY_LOCK_SENSOR = 0x16;            //查询智能锁传感器
        public const byte BLE_QUERY_LOCK_VERSION = 0x16;           //查询智能锁版本
    }
}
