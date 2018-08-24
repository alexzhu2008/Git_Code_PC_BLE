using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using SEL_BLE_SDK_PC_CSharp.Utils;
using wclBluetooth;
using wclCommon;

namespace SEL_BLE_SDK_PC_CSharp
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly Dictionary<string, wclBluetoothRadio> _devices = new Dictionary<string, wclBluetoothRadio>();
        private BluetoothClient _bluetoothClient = new BluetoothClient();
        private wclGattClient _client;

        private Dictionary<string, BluetoothAddress> _devicesAddresses = new Dictionary<string, BluetoothAddress>();

        private wclGattCharacteristic[] _fCharacteristics;
        private wclGattCharacteristic _txCharacteristic;
        private wclGattDescriptor[] _fDescriptors;
        private wclGattService[] _fServices;

        private wclBluetoothManager _manager;

        private readonly wclGattUuid _uuid;
        private ushort _txUuid = 0xFF01;
        private ushort _rxUuid = 0xFF02;

        #endregion
        
        public MainForm()
        {
            InitializeComponent();
            _uuid.ShortUuid = 0xFF00;
        }

        #region Event

        private void MainForm_Load(object sender, EventArgs e)
        {
            _manager = new wclBluetoothManager();
            _client = new wclGattClient();

            _manager.OnDeviceFound += Manager_OnDeviceFound;
            _manager.OnDiscoveringCompleted += Manager_OnDiscoveringCompleted;
            _manager.OnDiscoveringStarted += Manager_OnDiscoveringStarted;

            _client.OnCharacteristicChanged += Client_OnCharacteristicChanged;
            _client.OnConnect += Client_OnConnect;
            _client.OnDisconnect += Client_OnDisconnect;

            // In real application you should always analize the result code.
            // In this demo we assume that all is always OK.
            _manager.Open();

            Cleanup();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _client.Disconnect();
            _client = null;

            _manager.Close();
            _manager = null;

            Cleanup();
        }


        Byte[] val_GetRecord;
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            _client.Disconnect();
            //_client = null;

            //Cleanup();

            btSetTimeIcon.Enabled = false;
            btnGetRecord.Enabled = false;
        }

        private void btSetTime_Click(object sender, EventArgs e)
        {
            var package = BleProtocol.GetUpdateTimePackage();
            WriteCommand(package);
        }

        private void bleSearchBtn_Click(object sender, EventArgs e)
        {
            Cleanup();
            var radio = GetRadio();
            if (radio != null)
            {
                var res = radio.Discover(10, wclBluetoothDiscoverKind.dkBle);
                if (res != wclErrors.WCL_E_SUCCESS)
                    MessageBox.Show("Error starting discovering: 0x" + res.ToString("X8"),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bleConnect_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0) return;

            var item = lvDevices.SelectedItems[0];
            _client.Address = Convert.ToInt64(item.Text, 16);
            var radio = _devices[item.Text];
            var resConnect = _client.Connect(radio);
            if (resConnect != wclErrors.WCL_E_SUCCESS)
            {
                MessageBox.Show("连接失败");
                return;
            }

            btSetTimeIcon.Enabled = true;
            btnGetRecord.Enabled = true;
        }

        #endregion

        private void GetService()
        {
            _fServices = null;

            var resServices = _client.ReadServices(wclGattOperationFlag.goNone, out _fServices);
            if (resServices != wclErrors.WCL_E_SUCCESS)
            {
                MessageBox.Show("Error: 0x" + resServices.ToString("X8"), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                TraceEvent(_client.Address, "Services", "FF00", "Failed");
                _client.Disconnect();
                return;
            }

            TraceEvent(_client.Address, "Services", "FF00", "Success");
            if (_fServices == null) return;

            foreach (var service in _fServices)
            {
                if (service.Uuid.IsShortUuid)
                {
                    if (_uuid.ShortUuid == service.Uuid.ShortUuid)
                    {
                        var resChar = _client.ReadCharacteristics(service, wclGattOperationFlag.goNone,
                            out _fCharacteristics);
                        if (resChar != wclErrors.WCL_E_SUCCESS)
                        {
                            return;
                        }

                        foreach (var character in _fCharacteristics)
                        {
                            if (character.Uuid.ShortUuid == _rxUuid)
                            {
                                var resSubs = _client.Subscribe(character);
                                if (resSubs != wclErrors.WCL_E_SUCCESS)
                                {
                                    TraceEvent(_client.Address, "Subs", "RX", "Failed");
                                    return;
                                }
                                else
                                {
                                    TraceEvent(_client.Address, "Subs", "RX", "Success");
                                    var resReadDesc = _client.ReadDescriptors(character, wclGattOperationFlag.goNone,
                                        out _fDescriptors);
                                    if (resReadDesc != wclErrors.WCL_E_SUCCESS)
                                    {
                                        TraceEvent(_client.Address, "Subs", "RX", "Failed to get description");
                                        return;
                                    }
                                }
                            }
                            else if (character.Uuid.ShortUuid == _txUuid)
                            {
                                _txCharacteristic = character;
                            }
                        }
                    }
                }
            }
        }

        #region Radio
        private wclBluetoothRadio GetRadio()
        {
            // Look for first available radio.
            for (var i = 0; i < _manager.Count; i++)
                if (_manager[i].Available)
                    // Return first non MS.
                    return _manager[i];

            MessageBox.Show("No one Bluetooth Radio found.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        private void Client_OnDisconnect(object sender, int reason)
        {
            // Connection property is valid here.
            TraceEvent(((wclGattClient) sender).Address, "Disconnected", "Reason", "0x" + reason.ToString("X8"));

            //Cleanup();
        }

        private void Client_OnConnect(object sender, int error)
        {
            TraceEvent(((wclGattClient) sender).Address, "Connected", "Error", "0x" + error.ToString("X8"));

            GetService();
        }

        private void Client_OnCharacteristicChanged(object sender, ushort handle, byte[] value)
        {
            TraceEvent(((wclGattClient) sender).Address, "ValueChanged", "Handle", handle.ToString("X4"));
            if (value == null)
            {
                TraceEvent(0, "", "Value", "");
            }
            else if (value.Length == 0)
            {
                TraceEvent(0, "", "Value", "");
            }
            else
            {
                var str = "";

                for (var i = 0; i < value.Length; i++)
                    str = str + value[i].ToString("X2");

                BleProtocol.PackageAnalyze(value);
                if (BleProtocol.Record != null)
                {
                    var record = BleProtocol.Record;

                    string sOperType = "";
                    switch (record.OperationType)
                    {
                        case 1:
                            sOperType = "密码";
                            break;
                        case 2:
                            sOperType = "刷卡";
                            break;
                        case 3:
                            sOperType = "指纹";
                            break;
                        default:                            
                            break;
                    }                     

                    var item = lvOperationRecord.Items.Add(record.Date.ToString());
                    item.SubItems.Add(record.UserId.ToString());
                    item.SubItems.Add(sOperType);
                    item.SubItems.Add(record.UserType.ToString());
                    BleProtocol.Record = null;

                    WriteCommand(val_GetRecord);  //20180823 zy
                }

                TraceEvent(0, "", "Value", str);
            }
        }

        private void Manager_OnDiscoveringStarted(object sender, wclBluetoothRadio radio)
        {
            lvDevices.Items.Clear();
            TraceEvent(0, "Discovering started", "", "");
        }

        private void Manager_OnDiscoveringCompleted(object sender, wclBluetoothRadio radio, int error)
        {
            if (_devices.Count == 0)
                MessageBox.Show("No BLE devices were found.", "Discovering for BLE devices", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                // Here we can update found devices names.
                foreach (var key in _devices.Keys)
                {
                    var address = Convert.ToInt64(key, 16);

                    var item = lvDevices.Items.Add(address.ToString("X12"));

                    string devName;
                    var res = radio.GetRemoteName(address, out devName);
                    if (devName.Contains("SCH"))
                    {
                        if (res != wclErrors.WCL_E_SUCCESS)
                            item.SubItems.Add("Error: 0x" + res.ToString("X8"));
                        else
                            item.SubItems.Add(devName);
                    }
                    else
                    {
                        lvDevices.Items.Remove(item);
                    }
                }

            TraceEvent(0, "Discovering completed", "", "");
        }

        private void Manager_OnDeviceFound(object sender, wclBluetoothRadio radio, long address)
        {
            var devType = wclBluetoothDeviceType.dtMixed;
            var res = radio.GetRemoteDeviceType(address, out devType);

            _devices.Add(address.ToString("X12"), radio);

            TraceEvent(address, "Device found", "", "");
        }

        #endregion

        #region Function

        private void Cleanup()
        {
            _fCharacteristics = null;
            _fDescriptors = null;
            _fServices = null;

            _devices.Clear();
            _devicesAddresses.Clear();

            btSetTimeIcon.Enabled = false;
            btnGetRecord.Enabled = false;
        }

        private void TraceEvent(long address, string Event, string param, string value)
        {
            var s = "";
            if (address != 0)
                s = address.ToString("X12");
            var item = lvEvent.Items.Add(s);
            item.SubItems.Add(Event);
            item.SubItems.Add(param);
            item.SubItems.Add(value);

            lvEvent.Items[lvEvent.Items.Count - 1].EnsureVisible();
            
        }

        private void WriteCommand(byte[] package)
        {
            var str = "";
            for (var i = 0; i < package.Length; i++)
                str = str + package[i].ToString("X2");

            var resWrite = _client.WriteCharacteristicValue(_txCharacteristic, package);

            if (resWrite != wclErrors.WCL_E_SUCCESS)
            {
                TraceEvent(_client.Address, "TX", "Status", "Failed");
            }
            else
            {
                TraceEvent(_client.Address, "TX", "Data", str);
                TraceEvent(_client.Address, "TX", "Status", "Success");
            }
        }


        #endregion

        private void bleSearchBt2_Click(object sender, EventArgs e)
        {

        }

        private void btnGetRecord_Click(object sender, EventArgs e)
        {
            String str = "AA55000133FFFFFFFFFFFFFFFFFFFFFFFFFFFF4F";
            if (str.Length % 2 != 0)
                str = "0" + str;

            Byte[] val = new Byte[str.Length / 2];
            for (Int32 i = 0; i < val.Length; i++)
            {
                String b = str.Substring(i * 2, 2);
                val[i] = Convert.ToByte(b, 16);
            }

            val_GetRecord = val;

            WriteCommand(val);  //20180823 zy
        }
    }
}